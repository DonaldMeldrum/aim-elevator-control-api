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

        [HttpPost]
        [Route("RequestElevator")]
        /// Request an elevator from a given floor.
        public void RequestElevator([FromQuery(Name = "floorId")] string floorId)
        {   
            try
            {
                bll.RequestElevator(floorId);
                Results.Ok(true);
            }
            catch (Exception ex)
            {
                Results.Problem(floorId, ex.Message);
            }
        }

        [HttpPost]
        [Route("RequestFloor")]
        /// Requests a floor from a given elevator (i.e. person presses button inside elevator).
        public void RequestFloor([FromQuery(Name = "elevatorId")] string elevatorId, [FromQuery(Name = "floorId")] string floorId)
        {
            try
            {
                bll.RequestFloor(elevatorId, floorId);
                Results.Ok(true);
            }
            catch (Exception ex)
            {
                Results.Problem(floorId, ex.Message);
            }
        }


    }
}