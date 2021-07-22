using System.Collections.Generic;
using System.Linq;
using Zoo.Models.DbModels;
using Zoo.Models.Enums;

namespace Zoo.Models.ApiModels
{
    public class EnclosureResponseModel
    {
        public Enclosure Id { get; set; }
        public int Capacity { get; set; }
        public string Name { get; set; }
        public List<AnimalResponseModel> Animals { get; set; }
        public List<ZookeeperResponseModel> Zookeepers { get; set; }

        public EnclosureResponseModel(EnclosureDbModel enclosure)
        {
            Id = enclosure.Id;
            Capacity = enclosure.Capacity;
            Name = enclosure.Name;
            Animals = enclosure.Animals.Select(a => new AnimalResponseModel(a)).ToList();
            Zookeepers = enclosure.Zookeepers.Select(a => new ZookeeperResponseModel(a)).ToList();
        }

        public EnclosureResponseModel()
        {
        }
    }
}
