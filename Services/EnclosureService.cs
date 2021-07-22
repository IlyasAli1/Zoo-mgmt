using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zoo.Models.DbModels;
using Zoo.Models.Enums;

namespace Zoo.Services
{
    public interface IEnclosureService
    {
        EnclosureDbModel GetEnclosureById(Enclosure id);
        bool CheckEnclosureHasCapacity(Enclosure id);
    }

    public class EnclosureService : IEnclosureService
    {
        private readonly ZooDbContext _context;

        public EnclosureService(ZooDbContext context)
        {
            _context = context;
        }

        public EnclosureDbModel GetEnclosureById(Enclosure id)
        {
            return _context.Enclosure
                .Include(enclosure => enclosure.Animals)
                .Single(enclosure => enclosure.Id == id);
        }

        public bool CheckEnclosureHasCapacity(Enclosure id)
        {
            var enclosure = GetEnclosureById(id);

            return enclosure.Capacity > enclosure.Animals.Count();
        }
    }
}
