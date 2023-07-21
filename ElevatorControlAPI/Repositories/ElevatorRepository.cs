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
        /// Submit elevator request from a given floor
        /// </summary>
        /// <param name="elevatorRequest"></param>
        public void AddElevatorRequest(ElevatorRequest elevatorRequest)
        {
            ///TODO: Submit request to data layer
        }

        /// <summary>
        /// Submit floor request from a given elevator
        /// </summary>
        /// <param name="floorRequest"></param>
        public void AddFloorRequest(FloorRequest floorRequest)
        {
            ///TODO: Submit request to data layer
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
                RequestArray = Enumerable.Range(1, 6).Select(index => new FloorRequest
                {
                    RequestedFloor = new Floor() { Id = Guid.NewGuid(), DisplayName = "F" + index, LevelNumber = index },
                    RequestTime = DateTime.Now,
                    Status = RequestStatus.Pending
                }).ToArray()                
            }).ToArray();
        }

        /// <summary>
        /// Get all floor requests for a given elevator id
        /// </summary>
        /// <param name="elevatorId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public FloorRequest[] GetFloorRequests(Guid elevatorId)
        {
            ///TODO: Replace dummy data with call to data layer
            return Enumerable.Range(1, 8).Select(index => new FloorRequest
            {
                RequestedFloor = new Floor() { Id = Guid.NewGuid(), DisplayName = "F" + index, LevelNumber = index },
                RequestTime = DateTime.Now,
                Status = RequestStatus.Pending
            }).ToArray();
        }
    }
}
