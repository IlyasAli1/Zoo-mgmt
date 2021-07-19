using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Zoo.Services;
using Zoo.Models.ApiModels;

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
        public IEnumerable<AnimalApiModel> Get(int id)
        {
            // call animal service

        }
    }
}
