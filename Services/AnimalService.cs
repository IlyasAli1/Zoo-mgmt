
using System.Collections.Generic;
using System.Linq;
using Zoo.Models.ApiModels;
using Zoo.Models.DbModels;

namespace Zoo.Services
{
    public interface IAnimalService
    {
        AnimalApiModel GetAnimalById(int id);
        void AddAnimalToDb(AnimalRequestModel animal);
    }

    public class AnimalService : IAnimalService
    {
        private readonly ZooDbContext _context;

        public AnimalService(ZooDbContext context)
        {
            _context = context;
        }

        public AnimalApiModel GetAnimalById(int id)
        {
            return new AnimalApiModel(_context.Animal.Find(id));
        }

        public void AddAnimalToDb(AnimalRequestModel animal)
        {
            _context.Animal.Add(new AnimalDbModel
            {
                Name = animal.Name,
                Age = animal.Age,
                DateOfBirth = animal.DateOfBirth,
                DateOfArrival = animal.DateOfArrival,
                Classification = animal.Classification,
                Sex = animal.Sex,
                Species = animal.Species
            });

            _context.SaveChanges();
        }
}
}