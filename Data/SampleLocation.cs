using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Zoo.Models.DbModels;
using Zoo.Models.Enums;

namespace Zoo.Data
{
    public class SampleLocation
    {
        private static readonly IList<IList<string>> _data = new List<IList<string>>
        {
            new List<string> { "Death", "" },
            new List<string> { "London Zoo", "Regents Park" },
            new List<string> { "Woburn Safari Park", "Woburn" },
            new List<string> { "Cincinnati Zoo", "USA" }
        };

        public static IEnumerable<LocationDbModel> GetLocation() => Enumerable.Range(0, _data.Count()).Select(CreateRandomLocation);

        private static LocationDbModel CreateRandomLocation(int index)
        {
            return new LocationDbModel
            {
                Name = _data[index][0],
                Address = _data[index][1]
            };
        }
    }
}