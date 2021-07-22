using Zoo.Models.DbModels;
using Zoo.Models.Enums;

namespace Zoo.Models.ApiModels
{
    public class SpeciesResponseModel
    {
        public string Type { get; set; }
        public Classification Classification { get; set; }
        public int Id { get; set; }

        public SpeciesResponseModel(SpeciesDbModel species)
        {
            Type = species.Type;
            Classification = species.Classification;
            Id = species.Id;
        }
    }
}
