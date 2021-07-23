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
        List<EnclosureDbModel> GetEnclosuresByIds(string enclosure);
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

        public List<EnclosureDbModel> GetEnclosuresByIds(string enclosure)
        {
            var enclosures = new List<EnclosureDbModel>();
            foreach (var id in enclosure.Split(','))
            {
                enclosures.Add(GetEnclosureById((Enclosure)int.Parse(id)));
            }
            return enclosures;
        }
    }
}
