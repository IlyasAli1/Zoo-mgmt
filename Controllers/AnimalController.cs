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

        public AnimalController(ILogger<AnimalController> logger, IAnimalService animals)
        {
            _logger = logger;
            _animals = animals;
        }

        [HttpGet]
        [Route("{id}")]
        public AnimalResponseModel Get(int id)
        {
            return _animals.GetAnimalById(id);
        }

        [HttpPost]
        [Route("create")]
        public void Add([FromBody] AnimalRequestModel animal)
        {
            _animals.AddAnimalToDb(animal);
        }
    }
}
