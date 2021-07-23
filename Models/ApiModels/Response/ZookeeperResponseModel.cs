using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zoo.Models.DbModels;

namespace Zoo.Models.ApiModels
{
    public class ZookeeperResponseModel
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public List<AnimalResponseModel> Animals { get; set; }
        public List<EnclosureResponseModel> Enclosures { get; set; }

        public ZookeeperResponseModel(ZookeeperDbModel zookeeper, bool loadDependencies = false)
        {
            Name = zookeeper.Name;
            Id = zookeeper.Id;

            if (loadDependencies)
            {
                Animals = zookeeper.Animals?.Select(a => new AnimalResponseModel(a)).ToList();
                Enclosures = zookeeper.Enclosures.Select(e => new EnclosureResponseModel(e)).ToList();
            }
        }
    }
}
