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
        ZookeeperResponseModel AddZookeeperToDatabase(ZookeeperRequestModel zookeeper, List<EnclosureDbModel> enclosure);
    }

    public class ZookeeperService : IZookeeperService
    {
        private readonly ZooDbContext _context;
        // private readonly EnclosureService _service;

        public ZookeeperService(ZooDbContext context)
        {
            _context = context;
            // _service = service;
        }

        public ZookeeperResponseModel GetZookeeperById(int id)
        {
            var zookeeperDbModel = _context.Zookeeper
                .Include(z => z.Enclosures)
                .Include(z => z.Animals)
                .ThenInclude(a => a.Species)
                .Single(z => z.Id == id);
            return new ZookeeperResponseModel(zookeeperDbModel, true);
        }

        public ZookeeperResponseModel AddZookeeperToDatabase(ZookeeperRequestModel zookeeper, List<EnclosureDbModel> enclosures)
        {
            var newZookeeper = new ZookeeperDbModel
            {
                 Name = zookeeper.Name,
                 Enclosures = enclosures
            };
            _context.Zookeeper.Add(newZookeeper);
            _context.SaveChanges();

            return new ZookeeperResponseModel(newZookeeper);
        }
    }
}
