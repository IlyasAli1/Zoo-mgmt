using System;
using System.ComponentModel.DataAnnotations;
using Zoo.Models.Enums;

namespace Zoo.Models.ApiModels
{
    public class AnimalRequestModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public DateTime DateOfArrival { get; set; }
        [Required]
        public Sex Sex { get; set; }
        [Required]
        public int SpeciesId { get; set; }
        [Required]
        public Enclosure EnclosureId { get; set; }
    }
}
