using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Zoo.Models.Enums;

namespace Zoo.Models.ApiModels
{
    public class AnimalRequestModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public DateTime DateOfArrival { get; set; }
        [Required]
        public Classification Classification { get; set; }
        [Required]
        public Sex Sex { get; set; }
        [Required]
        public string Species { get; set; }
    }
}
