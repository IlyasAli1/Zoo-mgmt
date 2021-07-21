using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zoo.Models.DbModels;

namespace Zoo.Services
{
    public interface IEnclosureService
    {
        EnclosureDbModel GetEnclosureById(int id);
        bool CheckEnclosureHasCapacity(int id);
    }

    public class EnclosureService : IEnclosureService
    {
        private readonly ZooDbContext _context;

        public EnclosureService(ZooDbContext context)
        {
            _context = context;
        }

        public EnclosureDbModel GetEnclosureById(int id)
        {
            return _context.Enclosure
                .Include(enclosure => enclosure.Animals)
                .Single(enclosure => enclosure.Id == id);
        }

        public bool CheckEnclosureHasCapacity(int id)
        {
            var enclosure = GetEnclosureById(id);

            return enclosure.Capacity > enclosure.Animals.Count();
        }
    }
}
