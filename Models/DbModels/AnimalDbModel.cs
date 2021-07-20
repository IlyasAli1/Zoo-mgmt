using System;
using Zoo.Models.Enums;

namespace Zoo.Models.DbModels
{
    public class AnimalDbModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfArrival { get; set; }
        public Sex Sex { get; set; }
        public SpeciesDbModel Species { get; set; }
    }
}
