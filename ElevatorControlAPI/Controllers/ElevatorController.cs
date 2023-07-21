using ElevatorControlAPI.BusinessLogic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.Drawing;
using System.Text.Json.Nodes;

namespace ElevatorControlAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ElevatorController : ControllerBase
    { 
        private readonly ILogger<ElevatorController> _logger;
        private ElevatorBusiness bll;

        public ElevatorController(ILogger<ElevatorController> logger)
        {
            _logger = logger;
            bll = new ElevatorBusiness(_logger);
        }

        [HttpGet("GetRequestedFloors")]
        /// Gets a list of the floors that have been requested (i.e. which buttons should light up).
        public IResult GetRequestedFloors([FromQuery(Name = "elevatorId")] string elevatorId)
        {
            var requestedFloors = bll.GetRequestedFloors(elevatorId);
            return requestedFloors == null ? Results.NotFound() : Results.Ok(requestedFloors);
        }

        [HttpGet("GetNextFloor")]
        /// Get the next floor to be serviced for given elevator.
        public IResult GetNextFloor([FromQuery(Name = "elevatorId")] string elevatorId) 
        {
            var floor = bll.GetNextFloor(elevatorId);
            return floor == null ? Results.NotFound() : Results.Ok(floor);
        }

        [HttpGet("RequestElevator")]
        /// Request an elevator from a given floor.
        public IResult RequestElevator([FromQuery(Name = "floorId")] string floorId)
        {
            Elevator elevator = null;
            try
            {
                elevator = bll.RequestElevator(floorId);
            }
            catch (Exception ex)
            {
                Results.Problem(floorId, ex.Message);
            }
            return elevator == null ? Results.NotFound() : Results.Ok(String.Format("Sucessfully requested Elevator {0} from Floor {1}", elevator.Id, floorId));
        }

        [HttpGet("RequestFloor")]
        /// Requests a floor from a given elevator (i.e. person presses button inside elevator).
        public IResult RequestFloor([FromQuery(Name = "elevatorId")] string elevatorId, [FromQuery(Name = "floorId")] string floorId)
        {
            Floor floor = null;
            try
            {
                floor = bll.RequestFloor(elevatorId, floorId);
            }
            catch (Exception ex)
            {
                Results.Problem(floorId, ex.Message);
            }
            return floor == null ? Results.NotFound() : Results.Ok(String.Format("Sucessfully requested Floor {0} from Elevator {1}", floor.Id, elevatorId));
        }


    }
}