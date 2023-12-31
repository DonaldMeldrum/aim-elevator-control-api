﻿using ElevatorControlAPI.Controllers;
using ElevatorControlAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Xml.Linq;

namespace ElevatorControlAPI.BusinessLogic
{
    public class ElevatorBusiness
    {

        private readonly ILogger<ElevatorController> _logger;

        public ElevatorBusiness(ILogger<ElevatorController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Gets a list of the floors that have been requested (i.e. which buttons should light up).
        /// </summary>
        /// <param name="elevatorId"></param>
        /// <returns></returns>
        public IEnumerable<Floor> GetRequestedFloors(string elevatorId)
        {
            Guid guid = ValidateGuid(elevatorId);
            ElevatorRepository repository = new ElevatorRepository();
            var requestedFloors = repository.GetFloorRequests(guid);
            return (IEnumerable<Floor>)requestedFloors.Select(req => req.Floor).ToList();
        }

        /// <summary>
        /// Get the next floor to be serviced for given elevator.
        /// </summary>
        /// <param name="elevatorId"></param>
        /// <returns>Next floor to be serviced, or null for no requested floors</returns>
        public Floor? GetNextFloor(string elevatorId)
        {
            Guid guid = ValidateGuid(elevatorId);
            ElevatorRepository repository = new ElevatorRepository();
            var elevator = repository.GetElevator(guid);

            if (elevator.FloorRequests.Length > 0)
            {
                //get closest requested floor to current floor
                var floorReq = elevator.FloorRequests.MinBy(req => FloorDistance(req.Floor, elevator.currentFloor));
                if (floorReq != null)
                {
                    return floorReq.Floor;
                }
                else
                {
                    var errorMessage = String.Format("FloorRequest contains a null floor value, elevatorId: {0}", elevator.Id);
                    _logger.LogError(errorMessage);
                    throw new Exception(errorMessage);
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Request an elevator from a given floor. Elevator with fewest floor requests is assigned the request.
        /// </summary>
        /// <param name="floorId"></param>
        public Elevator RequestElevator(string floorId)
        {
            var floorGuid = ValidateGuid(floorId);
            ElevatorRepository repository = new ElevatorRepository();
            var floor = repository.GetFloor(floorGuid);
            var elevators = repository.GetElevators();
            if (elevators.Length > 0) {
                var elevatorCandidate = elevators.MinBy(e => e.FloorRequests.Length);

                repository.AddRequest(new Request()
                {
                    //Guid will be generated by data source
                    Elevator = elevatorCandidate,
                    Floor = floor,
                    RequestTime = DateTime.Now,
                    Status = RequestStatus.Pending
                });
                return elevatorCandidate;
            }
            else
            {
                var errorMessage = String.Format("No elevators found");
                _logger.LogError(errorMessage);
                throw new Exception(errorMessage);
            }
        }

        /// <summary>
        /// Requests a floor from a given elevator (i.e. person presses button inside elevator).
        /// </summary>
        /// <param name="elevatorId"></param>
        /// <param name="floorId"></param>
        public Floor RequestFloor(string elevatorId, string floorId)
        {
            var floorGuid = ValidateGuid(floorId);
            var elevatorGuid = ValidateGuid(elevatorId);
            ElevatorRepository repository = new ElevatorRepository();
            var floor = repository.GetFloor(floorGuid);
            var elevator = repository.GetElevator(elevatorGuid);
            //null values will be thrown from repository layer
            repository.AddRequest(new Request()
            {
                Elevator = elevator,
                Floor = floor,
                RequestTime = DateTime.Now,
                Status = RequestStatus.Pending
            });
            return floor;
        }

        private Guid ValidateGuid(string guidString)
        {
            Guid guid;
            if (Guid.TryParse(guidString, out guid))
            {
                return guid;
            }
            throw new Exception(String.Format("String not recognized as a valid Guid format: {0}", guidString));
        }

        private int FloorDistance(Floor a, Floor b)
        {
            return Math.Abs(a.LevelNumber - b.LevelNumber);
        }
    }
}
