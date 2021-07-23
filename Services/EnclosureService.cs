using Microsoft.EntityFrameworkCore;
using System.Linq;
using Zoo.Models.Enums;

namespace Zoo.Services
{
    public interface IEnclosureService
    {
        bool CheckEnclosureHasCapacity(int id);
    }

    public class EnclosureService : IEnclosureService
    {
        private readonly ZooDbContext _context;

        public EnclosureService(ZooDbContext context)
        {
            _context = context;
        }

        public bool CheckEnclosureHasCapacity(int id)
        {
            var enclosure = _context.Enclosure
                .Include(enclosure => enclosure.Animals)
                .Single(enclosure => enclosure.Id == id);

            return enclosure.Capacity > enclosure.Animals.Count;
        }
    }
}
