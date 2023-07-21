using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Text.Json.Nodes;

namespace ElevatorControlAPI.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ElevatorController : ControllerBase
    { 
        private readonly ILogger<ElevatorController> _logger;

        public ElevatorController(ILogger<ElevatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetRequestedFloors")]
        public ActionResult<IEnumerable<Floor>> GetRequestedFloors()
        {
            return Enumerable.Range(1, 5).Select(index => new Floor
            {
                DisplayName = "F" + new Random().Next(0, 10),
                LevelNumber = new Random().Next(0, 10)
            }).ToArray();
        }

        [HttpGet("GetNextFloor")]
        public ActionResult<Floor> GetNextFloor() 
        {
            return new Floor()
            {
                DisplayName = "F1",
                LevelNumber = 1
            };
        }

        [HttpPost]
        [Route("request-elevator")]
        public void RequestElevator([FromBody] Floor floor)
        {
            Console.WriteLine(floor.ToString());
        }

        [HttpPost]
        [Route("request-floor")]
        public void RequestFloor([FromBody] Floor floor)
        {
            Console.WriteLine(floor.ToString());
        }


    }
}