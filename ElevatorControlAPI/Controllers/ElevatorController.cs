using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
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
        /// Gets a list of the floors that have been requested (i.e. which buttons should light up).
        public ActionResult<IEnumerable<Floor>> GetRequestedFloors([FromQuery(Name = "elevatorId")] string elevatorId)
        {
            Console.WriteLine(elevatorId);
            return Enumerable.Range(1, 5).Select(index => new Floor
            {
                DisplayName = "F" + new Random().Next(0, 10),
                LevelNumber = new Random().Next(0, 10)
            }).ToArray();
        }

        [HttpGet("get-next-floor")]
        /// Get the next floor to be serviced for given elevator.
        public ActionResult<Floor> GetNextFloor([FromQuery(Name = "elevatorId")] string elevatorId) 
        {

            Console.WriteLine(elevatorId);
            return new Floor()
            {
                DisplayName = "F1",
                LevelNumber = 1
            };
        }

        [HttpPost]
        [Route("request-elevator")]
        /// Request an elevator from a given floor.
        public void RequestElevator([FromQuery(Name = "floorId")] string floorId)
        {
            Console.WriteLine(floorId);
        }

        [HttpPost]
        [Route("request-floor")]
        /// Requests a floor from a given elevator (i.e. person presses button inside elevator).
        public void RequestFloor([FromQuery(Name = "elevatorId")] string elevatorId, [FromQuery(Name = "floorId")] string floorId)
        {
            Console.WriteLine(elevatorId);
            Console.WriteLine(floorId);
        }


    }
}