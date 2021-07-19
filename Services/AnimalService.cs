
using System.Collections.Generic;
using System.Linq;

namespace Zoo.Services
{
    public interface IAnimalService
    {

    }
      
    public class AnimalService : IAnimalService
    {
        private readonly ZooDbContext _context;

        public AnimalService(ZooDbContext context)
        {
            _context = context;
        }

       
    }
}