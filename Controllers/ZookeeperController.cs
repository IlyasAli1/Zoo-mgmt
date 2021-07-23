using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Zoo.Models.ApiModels;
using Zoo.Models.DbModels;
using Zoo.Services;

namespace Zoo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ZookeeperController : ControllerBase
    {
        private readonly ILogger<ZookeeperController> _logger;
        private readonly IZookeeperService _zookeeper;
        private readonly IEnclosureService _enclosure;


        public ZookeeperController(ILogger<ZookeeperController> logger, IZookeeperService zookeeper, IEnclosureService enclosure)
        {
            _logger = logger;
            _zookeeper = zookeeper;
            _enclosure = enclosure;
        }

        [HttpGet]
        [Route("{id}")]
        public ObjectResult Get(int id)
        {
            try
            {
                return StatusCode(200, _zookeeper.GetZookeeperById(id));
            }
            catch (InvalidOperationException)
            {
                return StatusCode(404, "Id is not valid.");
            }

        }

        [HttpPost]
        [Route("create")]
        public IActionResult Add([FromBody] ZookeeperRequestModel zookeeper)
        {
            foreach (var id in zookeeper.EnclosureIds.Split(","))
            {
                if (int.Parse(id) < 1 || int.Parse(id) > 5)
                {
                    return BadRequest("Enclosure is invalid.");
                }
            }

            var enclosures = _enclosure.GetEnclosuresByIds(zookeeper.EnclosureIds);

            var newZookeeper = _zookeeper.AddZookeeperToDatabase(zookeeper, enclosures);
            return Created(Url.Action("Get", new { id = newZookeeper.Id }), newZookeeper);
        }
    }
}
