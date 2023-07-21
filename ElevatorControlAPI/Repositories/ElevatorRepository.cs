using System;

namespace ElevatorControlAPI.Repositories
{
    public class ElevatorRepository : IElevatorRepository
    {
        public ElevatorRepository()
        {
            //Use some type of data binding framework to pull elevator(s) state data from backend datasource
        }

        /// <summary>
        /// Submit elevator request for a given floor. Note that requests can originate from a floor or inside the elevator.
        /// </summary>
        /// <param name="request"></param>
        public void AddRequest(Request request)
        {
            ///TODO: Submit request to data layer
        }

        public Elevator GetElevator(Guid elevatorId)
        {
            ///TODO: Replace dummy data with call to data layer
            return new Elevator
            {
                Id = elevatorId,
                FloorRequests = Enumerable.Range(4, 13).Select(index => new Request
                {
                    Id = Guid.NewGuid(),
                    Floor = GetFloor(Guid.NewGuid()),
                    RequestTime = DateTime.Now,
                    Status = RequestStatus.Pending
                }).ToArray(),
                currentFloor = new Floor()
                {
                    Id = Guid.NewGuid(),
                    DisplayName = "F16",
                    LevelNumber = 16,
                }
            };
        }

        public Floor GetFloor(Guid floorId)
        {
            ///TODO: Replace dummy data with call to data layer
            return new Floor
            {
                Id = floorId,
                DisplayName = "F15",
                LevelNumber = 15
            };
        }

        /// <summary>
        /// Get all elevators
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Elevator[] GetElevators()
        {
            ///TODO: Replace dummy data with call to data layer
            return Enumerable.Range(1, 1).Select(index => new Elevator
            {
                Id = Guid.NewGuid(),
                FloorRequests = Enumerable.Range(4, 13).Select(index => new Request
                {
                    Id = Guid.NewGuid(),
                    Floor = GetFloor(Guid.NewGuid()),
                    RequestTime = DateTime.Now,
                    Status = RequestStatus.Pending
                }).ToArray(),
                currentFloor = new Floor()
                {
                    Id = Guid.NewGuid(),
                    DisplayName = "F7",
                    LevelNumber = 7,
                }
            }).ToArray();
        }

        /// <summary>
        /// Get all floor requests for a given elevator id
        /// </summary>
        /// <param name="elevatorId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Request[] GetFloorRequests(Guid elevatorId)
        {
            ///TODO: Replace dummy data with call to data layer
            return Enumerable.Range(1, 8).Select(index => new Request
            {
                Id = Guid.NewGuid(),
                Elevator = GetElevator(Guid.NewGuid()),
                Floor = GetFloor(Guid.NewGuid()),
                RequestTime = DateTime.Now,
                Status = RequestStatus.Pending
            }).ToArray();
        }
    }
}
