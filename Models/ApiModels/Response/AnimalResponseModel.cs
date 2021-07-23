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
        public EnclosureResponseModel Enclosure { get; set; }
        public ZookeeperResponseModel Zookeeper { get; set; }


        public AnimalResponseModel(AnimalDbModel animal, bool loadDependencies = false)
        {
            Id = animal.Id;
            Name = animal.Name;
            Age = new DateTime(DateTime.Now.Subtract(animal.DateOfBirth).Ticks).Year - 1;
            DateOfBirth = animal.DateOfBirth;
            DateOfArrival = animal.DateOfArrival;
            Classification = animal.Species.Classification;
            Sex = animal.Sex;
            Species = animal.Species.Type;
            if (loadDependencies)
            {
                Enclosure = new EnclosureResponseModel(animal.Enclosure);
                Zookeeper = new ZookeeperResponseModel(animal.Zookeeper);
            }
        }

        public AnimalResponseModel()
        {
        }
    }
}
