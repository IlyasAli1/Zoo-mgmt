using System;
using System.Collections.Generic;
using System.Linq;
using Zoo.Models.DbModels;
using Zoo.Models.Enums;

namespace Zoo.Data
{
    public class SampleTransfer
    {
        private static readonly IList<IList<string>> _data = new List<IList<string>>
        {
            new List<string> { "08/12/99" , "False" , "5", "London Zoo" },
            new List<string> { "08/12/19" , "False" , "6", "Death" },
            new List<string> { "18/08/2015" , "True" , "7", "London Zoo" },
            new List<string> { "24/10/2014" , "True" , "9", "Woburn Safari Park" },
            new List<string> { "10/10/20" , "False" , "17", "Death" },
            new List<string> { "15/12/19" , "True" , "1", "London Zoo" },
            new List<string> { "08/02/09" , "True" , "13", "Cincinnati Zoo" },
            new List<string> { "08/04/97" , "True" , "3", "Woburn Safari Park" },
            new List<string> { "08/03/95" , "False" , "2", "Death" },
            new List<string> { "08/10/19" , "False" , "8", "Cincinnati Zoo" },
        };

        public static IEnumerable<TransferDbModel> GetTransfers(List<AnimalDbModel> animals)
        {
            var locations = SampleLocation.GetLocation().ToList();
            return Enumerable.Range(0, _data.Count()).Select(i => CreateRandomTransfer(i, locations, animals));
        }


        private static TransferDbModel CreateRandomTransfer(
            int index, List<LocationDbModel> locations, List<AnimalDbModel> animals
        ) => new TransferDbModel
        {
            DateOfTransfer = DateTime.Parse(_data[index][0]),
            Inbound = bool.Parse(_data[index][1]),
            Animal = animals.Single(a => a.Id == int.Parse(_data[index][2])),
            Location = locations.Single(l => l.Name == _data[index][3])
        };
    }
}