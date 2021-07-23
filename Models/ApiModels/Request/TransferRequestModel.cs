using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Zoo.Models.DbModels;

namespace Zoo.Models.ApiModels
{
    public class TransferRequestModel
    {
        [Required]
        public DateTime DateOfTransfer { get; set; }
        [Required]
        public bool Inbound { get; set; }
        [Required]
        public int AnimalId { get; set; }
        [Required]
        public int LocationId { get; set; }
    }
}
