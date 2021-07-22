using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zoo.Models.DbModels;

namespace Zoo.Models.ApiModels
{
    public class ZookeeperResponseModel
    {
        public string Name;
        public int Id;
        public List<AnimalResponseModel> Animals;
        public List<EnclosureResponseModel> Enclosures;

        public ZookeeperResponseModel(ZookeeperDbModel zookeeper)
        {
            Name = zookeeper.Name;
            Id = zookeeper.Id;
            Animals = zookeeper.Animals.Select(a => new AnimalResponseModel(a)).ToList();
            Enclosures = zookeeper.Enclosures.Select(e => new EnclosureResponseModel(e)).ToList();
        }

        public ZookeeperResponseModel()
        {
        }
    }
}
