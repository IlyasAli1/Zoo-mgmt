using System;
using Zoo.Models.DbModels;
using Zoo.Models.Enums;

namespace Zoo.Models.ApiModels
{
    public class AnimalResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfArrival { get; set; }
        public Classification Classification { get; set; }
        public Sex Sex { get; set; }
        public string Species { get; set; }

        public AnimalResponseModel(AnimalDbModel animal)
        {
            Id = animal.Id;
            Name = animal.Name;
            Age = animal.Age;
            DateOfBirth = animal.DateOfBirth;
            DateOfArrival = animal.DateOfArrival;
            Classification = animal.Species.Classification;
            Sex = animal.Sex;
            Species = animal.Species.Type;
        }

        public AnimalResponseModel()
        {
        }
    }
}
