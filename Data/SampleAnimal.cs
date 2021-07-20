using System;
using System.Collections.Generic;
using System.Linq;
using Zoo.Models.DbModels;
using Zoo.Models.Enums;

namespace Zoo.Data
{
    public class SampleAnimal
    {
        private static readonly IList<IList<string>> _data = new List<IList<string>>
        {
            new List<string> { "Mufasa", "08/12/99" , "01/04/08" , "0" , "Lion" },
            new List<string> { "Alpha", "09/12/04" , "01/04/08" , "0" , "Wolf" },
            new List<string> { "Samantha", "22/12/09" , "01/04/14" , "1" ,"Snake" },
            new List<string> { "Doris", "30/12/15" , "01/09/20" , "1" , "Crocodile" },
            new List<string> { "Kim", "10/11/10" , "04/10/13" , "1" , "Cheetah" },
            new List<string> { "Kai", "09/12/20" , "01/04/21" , "0" , "Rabbit" },
            new List<string> { "Don", "09/12/10" , "24/11/18" , "0" , "Turtle" },
            new List<string> { "Harold", "03/11/2010", "11/04/2016", "0", "Chameleon"},
            new List<string> { "Betty", "13/01/2002", "11/04/2017", "1", "Bullfinch"},
            new List<string> { "Pingu", "03/11/2012", "11/04/2018", "0", "Penguin"},
            new List<string> { "Robin", "21/10/2020", "11/04/2019", "1", "Robin"},
            new List<string> { "Dave", "03/11/2012", "11/04/2020", "0", "Ladybird"},
            new List<string> { "Richard", "08/01/1992", "11/04/2021", "0", "Cockroach"},
            new List<string> { "Drogon", "23/11/2012", "11/04/2013", "1", "Dragonfly"},
            new List<string> { "Nemo", "06/05/2017", "25/06/2017", "1", "Cod" },
            new List<string> { "Swimmy","06/05/2017", "25/06/2017", "0", "Salmon" },
            new List<string> { "Otto", "06/05/2017", "25/06/2017", "1", "Goldfish" },
            new List<string> { "Wanda", "06/05/2017", "25/06/2017", "0", "Starfish" },
            new List<string> { "Bait", "06/05/2017", "25/06/2017", "1", "Scallop" },
            new List<string> { "Cthulhu", "06/05/2017", "25/06/2017", "0", "Jellyfish" }
        };

        public static IEnumerable<AnimalDbModel> GetAnimals()
        {
            var species = SampleSpecies.GetSpecies().ToList();
            return Enumerable.Range(0, _data.Count()).Select(i => CreateRandomAnimal(i, species));
        }

        private static AnimalDbModel CreateRandomAnimal(int index, List<SpeciesDbModel> species) => new AnimalDbModel
        {
            Name = _data[index][0],
            DateOfBirth = DateTime.Parse(_data[index][1]),
            DateOfArrival = DateTime.Parse(_data[index][2]),
            Sex = (Sex)int.Parse(_data[index][3]),
            Species = species.Single(s => s.Type == _data[index][4])
        };
    }
}