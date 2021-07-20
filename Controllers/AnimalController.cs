using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Zoo.Models.ApiModels;
using Zoo.Services;

namespace Zoo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnimalController : ControllerBase
    {
        private readonly ILogger<AnimalController> _logger;
        private readonly IAnimalService _animals;
        private readonly ISpeciesService _species;

        public AnimalController(ILogger<AnimalController> logger, IAnimalService animals, ISpeciesService _species)
        {
            _logger = logger;
            _animals = animals;
            _species = species;
        }

        [HttpGet]
        [Route("{id}")]
        public AnimalApiModel Get(int id)
        {
            return _animals.GetAnimalById(id);
        }

        [HttpPost]
        [Route("create")]
        public void Add([FromBody] AnimalRequestModel animal)
        {
            var species =  _species.GetSpeciesById(animal.SpeciesId);
            _animals.AddAnimalToDb(animal, species);
        }
    }
}
