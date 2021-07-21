using System.Collections.Generic;
using System.Linq;
using Zoo.Models.DbModels;
using Zoo.Models.Enums;

namespace Zoo.Data
{
    public class SampleEnclosure
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

        private static EnclosureDbModel CreateRandomEnclosure(int index)
        {
            return new EnclosureDbModel
            {
                Name = _data[index][0],
                Capacity = int.Parse(_data[index][1])
            };
        }
    }
}