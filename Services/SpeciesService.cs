using Microsoft.EntityFrameworkCore;
using System.Linq;
using Zoo.Models.ApiModels;
using Zoo.Models.DbModels;

namespace Zoo.Services
{
    public interface ISpeciesService
    {
        SpeciesResponseModel GetSpeciesById(int id);
        void AddSpeciesToDb(SpeciesRequestModel animal);
        SpeciesDbModel GetDbModelSpeciesById(int id);
    }

    public class SpeciesService : ISpeciesService
    {
        private readonly ZooDbContext _context;

        public SpeciesService(ZooDbContext context)
        {
            _context = context;
        }

        public SpeciesResponseModel GetSpeciesById(int id)
        {
            return new SpeciesResponseModel(
                _context.Species
                .Single(species => species.Id == id)
            );
        }

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
    }
}