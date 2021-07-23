using Microsoft.EntityFrameworkCore;
using System.Linq;
using Zoo.Models.Enums;

namespace Zoo.Services
{
    public interface IEnclosureService
    {
        bool CheckEnclosureHasCapacity(Enclosure id);
    }

    public class EnclosureService : IEnclosureService
    {
        private readonly ZooDbContext _context;

        public EnclosureService(ZooDbContext context)
        {
            _context = context;
        }

        public bool CheckEnclosureHasCapacity(Enclosure id)
        {
            var enclosure = _context.Enclosure
                .Include(enclosure => enclosure.Animals)
                .Single(enclosure => enclosure.Id == id);

            return enclosure.Capacity > enclosure.Animals.Count;
        }
    }
}
