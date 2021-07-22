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
        public static int NumberOfEnclosure = 100;

        private static readonly IList<IList<string>> _data = new List<IList<string>>
        {
            new List<string> { "Lion Enclosure", "10" },
            new List<string> { "Aviary", "50" },
            new List<string> { "Reptile House", "40" },
            new List<string> { "Giraffe Enclosure", "6" },
            new List<string> { "Hippo Enclosure", "10" }
        };

        public static IEnumerable<EnclosureDbModel> GetEnclosure() => Enumerable.Range(0, _data.Count()).Select(CreateRandomEnclosure);

        private static ZookeeperDbModel CreateRandomZookeepers(int index)
        {
            return new ZookeeperDbModel
            {
                Name = _data[index][0],
                Animals = 
                Enclosures
            };
        }
    }
}