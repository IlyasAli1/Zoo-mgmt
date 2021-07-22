using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

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
