using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zoo.Models.ApiModels;
using Zoo.Models.DbModels;
using Zoo.Models.Enums;

namespace Zoo.Services
{
    public interface IZookeeperService
    {
        ZookeeperResponseModel GetZookeeperById(int id);
    }

    public class ZookeeperService : IZookeeperService
    {
        private readonly ZooDbContext _context;

        public ZookeeperService(ZooDbContext context)
        {
            _context = context;
        }

        public ZookeeperResponseModel GetZookeeperById(int id)
        {
            return new ZookeeperResponseModel(
                _context.Zookeeper
                .Include(z => z.Enclosures)
                .Include(z => z.Animals)
                .Single(z => z.Id == id)
                );
        }

        //public bool Add(d)
        //{
        //    var enclosure = GetEnclosureById(id);

        //    return enclosure.Capacity > enclosure.Animals.Count();
        //}
    }
}
