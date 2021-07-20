using Zoo.Models.Enums;

namespace Zoo.Models.DbModels
{
    public class SpeciesDbModel
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public Classification Classification { get; set; }
    }
}
