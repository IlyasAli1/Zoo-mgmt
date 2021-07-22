using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Zoo.Models.ApiModels;
using Zoo.Services;

namespace Zoo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ZookeeperController : ControllerBase
    {
        private readonly ILogger<ZookeeperController> _logger;
        private readonly IZookeeperService _zookeeper;
        

        public ZookeeperController(ILogger<ZookeeperController> logger, IZookeeperService zookeeper)
        {
            _logger = logger;
            _zookeeper = zookeeper;
        }

        [HttpGet]
        [Route("{id}")]
        public ZookeeperResponseModel Get(int id) => _zookeeper.GetZookeeperById(id);

        //GetZookeeperById
        //AddZookeeper

        // [HttpPost]
        // [Route("create")]
       // public IActionResult Add([FromBody] ZookeeperRequestModel zookeeper)
        // {
            //var enclosure = _enclosure.GetEnclosureById(animal.EnclosureId);
            //var newAnimal = _animals.AddAnimalToDb(animal, enclosure);
        //    return Created(Url.Action("Get", new { id = newAnimal.Id }), newAnimal);
       // }
    }

}
