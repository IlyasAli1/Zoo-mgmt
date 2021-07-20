using System.ComponentModel.DataAnnotations;
using Zoo.Models.Enums;

namespace Zoo.Models.ApiModels
{
    public class SpeciesRequestModel
    {
        [Required]
        public string Type;
        [Required]
        public Classification Classification;
    } 
}
