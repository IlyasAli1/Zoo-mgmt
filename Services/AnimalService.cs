using Microsoft.EntityFrameworkCore;
using System.Linq;
using Zoo.Models.ApiModels;
using Zoo.Models.DbModels;

namespace Zoo.Services
{
    public interface IAnimalService
    {
        AnimalResponseModel GetAnimalById(int id);
        void AddAnimalToDb(AnimalRequestModel animal, SpeciesDbModel species);
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
                .Single(animal => animal.Id == id)
            );
        }

        public void AddAnimalToDb(AnimalRequestModel animal, SpeciesDbModel species)
        {
            _context.Animal.Add(new AnimalDbModel
            {
                Name = animal.Name,
                Age = animal.Age,
                DateOfBirth = animal.DateOfBirth,
                DateOfArrival = animal.DateOfArrival,
                Sex = animal.Sex,
                Species = species
            });

            _context.SaveChanges();
        }
    }
}