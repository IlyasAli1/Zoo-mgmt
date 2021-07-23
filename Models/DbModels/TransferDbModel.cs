using System;
using Zoo.Models.Enums;

namespace Zoo.Models.DbModels
{
    public class TransferDbModel
    {
        public int Id { get; set; }
        public DateTime DateOfTransfer { get; set; }
        public bool Inbound { get; set; }
        public AnimalDbModel Animal { get; set; }
        public LocationDbModel Location { get; set; }
    }
}
