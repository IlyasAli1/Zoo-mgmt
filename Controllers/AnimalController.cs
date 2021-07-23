using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
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
        private readonly IEnclosureService _enclosure;

        public AnimalController(ILogger<AnimalController> logger, IAnimalService animals, IEnclosureService enclosure)
        {
            _logger = logger;
            _animals = animals;
            _enclosure = enclosure;
        }

        [HttpGet]
        [Route("{id}")]
        public ObjectResult Get(int id)
        {
            try
            {
                return StatusCode(200, _animals.GetAnimalById(id));
            }
            catch (InvalidOperationException)
            {
                return StatusCode(404, "Id not recognized");
            }
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Add([FromBody] AnimalRequestModel animal)
        {
            if (!_enclosure.CheckEnclosureHasCapacity(animal.EnclosureId))
            {
                return BadRequest("Animal enclosure is full");
            }
            var enclosure = _enclosure.GetEnclosureById(animal.EnclosureId);
            var newAnimal = _animals.AddAnimalToDb(animal, enclosure);
            return Created(Url.Action("Get", new { id = newAnimal.Id }), newAnimal);

        }

        [HttpPost]
        [Route("search")]
        public List<AnimalResponseModel> Search([FromQuery] SearchRequestModel search) => _animals.Search(search);
    }
}
