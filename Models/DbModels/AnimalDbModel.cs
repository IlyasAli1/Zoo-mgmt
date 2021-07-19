using System;

namespace Zoo.Models.DbModels
{
    public class AnimalDbModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfArrival { get; set; }
        public string Classification { get; set; }
        public string Sex { get; set; }
        public string Species { get; set; }
    }
}
