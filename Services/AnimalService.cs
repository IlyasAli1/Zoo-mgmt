using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Zoo.Models.ApiModels;
using Zoo.Models.DbModels;

namespace Zoo.Services
{
    public interface IAnimalService
    {
        AnimalResponseModel GetAnimalById(int id);
        AnimalResponseModel AddAnimalToDb(AnimalRequestModel animal);
        SpeciesResponseModel GetSpeciesById(int id);
        void AddSpeciesToDb(SpeciesRequestModel animal);
        SpeciesDbModel GetDbModelSpeciesById(int id);
        List<AnimalResponseModel> Search(SearchRequestModel search);
        IEnumerable<AnimalDbModel> OrderResponse(IEnumerable<AnimalDbModel> response, SearchRequestModel search);
        TransferResponseModel AddNewTransfer(TransferRequestModel transfer);
    }

    public class AnimalService : IAnimalService
    {
        private readonly ZooDbContext _context;

        public AnimalService(ZooDbContext context)
        {
            _context = context;
        }

        public AnimalResponseModel GetAnimalById(int id)
        {
            return new AnimalResponseModel(
                _context.Animal
                    .Include(animal => animal.Species)
                    .Include(animal => animal.Enclosure)
                    .Include(animal => animal.Zookeeper)
                    .Include(animal => animal.Transfers)
                    .ThenInclude(t => t.Location)
                    .Single(animal => animal.Id == id)
                , true
            );
        }

        public AnimalResponseModel AddAnimalToDb(AnimalRequestModel animal)
        {
            var enclosure = _context.Enclosure.FromSqlInterpolated(@$"SELECT [e].[Id], [e].[Type], [e].[Capacity], [e].[Name] FROM [Enclosure] AS [e] WHERE [e].[Id] = {animal.EnclosureId}")
                .Single();

            var newAnimal = new AnimalDbModel
            {
                Name = animal.Name,
                DateOfBirth = animal.DateOfBirth,
                DateOfArrival = animal.DateOfArrival,
                Sex = animal.Sex,
                Species = GetDbModelSpeciesById(animal.SpeciesId),
                Enclosure = enclosure
            };
            _context.Animal.Add(newAnimal);
            _context.SaveChanges();

            return new AnimalResponseModel(newAnimal);
        }

        public SpeciesResponseModel GetSpeciesById(int id) => new SpeciesResponseModel(GetDbModelSpeciesById(id));

        public SpeciesDbModel GetDbModelSpeciesById(int id)
        {
            return _context.Species
            .Single(species => species.Id == id);
        }

        public void AddSpeciesToDb(SpeciesRequestModel species)
        {
            _context.Species.Add(new SpeciesDbModel
            {
                Type = species.Type,
                Classification = species.Classification
            });

            _context.SaveChanges();
        }

        public List<AnimalResponseModel> Search(SearchRequestModel search)
        {
            var mostRecentBirthday = DateTime.Today.AddYears(-search.Age);
            var earliestBirthday = mostRecentBirthday.AddYears(-1);

            var unorderedResponse = _context.Animal
                .Include(a => a.Species)
                .Include(a => a.Enclosure)
                .Include(a => a.Zookeeper)
                .Where(a => search.Classification == null || a.Species.Classification == search.Classification)
                .Where(a => search.Type == "all" || a.Species.Type == search.Type)
                .Where(a => search.Age == 0 || a.DateOfBirth > earliestBirthday && a.DateOfBirth <= mostRecentBirthday)
                .Where(a => search.Name == null || a.Name == search.Name)
                .Where(a => search.DateAcquired == default(DateTime) || a.DateOfArrival == search.DateAcquired)
                .Where(a => search.Enclosure == "all" || a.Enclosure.Name == search.Enclosure);

            return OrderResponse(unorderedResponse, search)
                .Skip((search.Page - 1) * search.PageSize)
                .Take(search.PageSize)
                .Select(a => new AnimalResponseModel(a, true))
                .ToList();
        }

        public IEnumerable<AnimalDbModel> OrderResponse(IEnumerable<AnimalDbModel> response, SearchRequestModel search)
        {
            switch (search.OrderBy)
            {
                case (Models.Enums.OrderBy)0:
                    response = response.OrderBy(a => a.Species.Type);
                    break;
                case (Models.Enums.OrderBy)1:
                    response = response.OrderBy(a => a.Species.Classification);
                    break;
                case (Models.Enums.OrderBy)2:
                    response = response.OrderBy(a => a.DateOfBirth);
                    break;
                case (Models.Enums.OrderBy)3:
                    response = response.OrderBy(a => a.Name);
                    break;
                case (Models.Enums.OrderBy)4:
                    response = response.OrderBy(a => a.DateOfArrival);
                    break;
                case (Models.Enums.OrderBy)5:
                    response = response.OrderBy(a => a.Enclosure.Type).ThenBy(a => a.Enclosure.Id).ThenBy(a => a.Name);
                    break;
                default:
                    response = response.OrderBy(a => a.Species);
                    break;
            }
            return response;
        }

        public TransferResponseModel AddNewTransfer(TransferRequestModel transfer)
        {
            var transferDb = new TransferDbModel
            {
                DateOfTransfer = transfer.DateOfTransfer,
                Inbound = transfer.Inbound,
                Animal = _context.Animal.Single(animal => animal.Id == transfer.AnimalId),
                Location = _context.Location.Single(l => l.Id == transfer.LocationId)
            };
            _context.Transfer.Add(transferDb);
            _context.SaveChanges();

            return new TransferResponseModel(transferDb);
        }
    }
}
