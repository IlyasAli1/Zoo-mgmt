using Zoo.Models.DbModels;
using Zoo.Models.Enums;

namespace Zoo.Models.ApiModels
{
    public class SpeciesResponseModel
    {
        public string Type;
        public Classification Classification;
        public int Id;

        public SpeciesResponseModel(SpeciesDbModel species)
        {
            Type = species.Type;
            Classification = species.Classification;
            Id = species.Id;
        }

        public SpeciesResponseModel()
        {
        }
    }
}
