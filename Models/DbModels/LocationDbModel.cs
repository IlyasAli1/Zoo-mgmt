using System;
using System.Collections.Generic;
using Zoo.Models.Enums;

namespace Zoo.Models.DbModels
{
    public class LocationDbModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<TransferDbModel> Transfers { get; set; }
    }
}
