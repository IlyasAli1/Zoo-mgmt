using System.Collections.Generic;
using System.Linq;
using Zoo.Models.DbModels;
using Zoo.Models.Enums;

namespace Zoo.Data
{
    public class SampleSpecies
    {
        public static int NumberOfSpecies = 100;

        private static readonly IList<IList<string>> _data = new List<IList<string>>
        {
            new List<string> { "Lion", "1" },
            new List<string> { "Wolf", "1" },
            new List<string> { "Snake", "2" },
            new List<string> { "Crocodile", "2" },
            new List<string> { "Cheetah", "1" },
            new List<string> { "Rabbit", "1" },
            new List<string> { "Turtle", "2" },
            new List<string> { "Chameleon", "2" },
            new List<string> { "Bullfinch", "3" },
            new List<string> { "Penguin", "3" },
            new List<string> { "Robin", "3" },
            new List<string> { "Ladybird", "4" },
            new List<string> { "Cockroach", "4" },
            new List<string> { "Dragonfly", "4" },
            new List<string> { "Cod", "5" },
            new List<string> { "Salmon", "5" },
            new List<string> { "Goldfish", "5" },
            new List<string> { "Starfish", "6" },
            new List<string> { "Scallop", "6" },
            new List<string> { "Jellyfish", "6" }
        };

        public static IEnumerable<SpeciesDbModel> GetSpecies() => Enumerable.Range(0, _data.Count()).Select(CreateRandomSpecies);

        private static SpeciesDbModel CreateRandomSpecies(int index)
        {
            return new SpeciesDbModel
            {
                Type = _data[index][0],
                Classification = (Classification)int.Parse(_data[index][1])
            };
        }
    }
}