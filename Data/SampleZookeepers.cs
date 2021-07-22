using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Zoo.Models.DbModels;
using Zoo.Models.Enums;

namespace Zoo.Data
{
    public class SampleZookeepers
    {
        private static readonly IList<IList<string>> _data = new List<IList<string>>
        {
            new List<string> { "Oskar Williams" },
            new List<string> { "Sasha B" },
            new List<string> { "Sophia Lin" },
        };

        public static IEnumerable<ZookeeperDbModel> GetInitialZookeepers() => Enumerable.Range(0, _data.Count()).Select(CreateRandomInitialZookeepers);

        private static ZookeeperDbModel CreateRandomInitialZookeepers(int index)
        {
            return new ZookeeperDbModel
            {
                Name = _data[index][0],
            };
        }

        public static List<ZookeeperDbModel> UpdateZookeepers(
            List<ZookeeperDbModel> zookeepers, List<AnimalDbModel> animals
        )
        {
            foreach (var zookeeper in zookeepers)
            {
                zookeeper.Enclosures = animals
                    .Where(a => a.Zookeeper.Name == zookeeper.Name)
                    .Select(a => a.Enclosure)
                    .Distinct()
                    .ToList();
            }
            return zookeepers;
        }
    }
}