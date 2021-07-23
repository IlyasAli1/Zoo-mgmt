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
        private readonly IAnimalService _animals;
        private readonly IEnclosureService _enclosure;

        public AnimalController(IAnimalService animals, IEnclosureService enclosure)
        {
            _animals = animals;
            _enclosure = enclosure;
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<AnimalResponseModel> Get(int id)
        {
            try
            {
                return _animals.GetAnimalById(id);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
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
            var newAnimal = _animals.AddAnimalToDb(animal);
            return Created(Url.Action("Get", new { id = newAnimal.Id }), newAnimal);

        }

        [HttpPost]
        [Route("search")]
        public List<AnimalResponseModel> Search([FromQuery] SearchRequestModel search) => _animals.Search(search);
    }
}
