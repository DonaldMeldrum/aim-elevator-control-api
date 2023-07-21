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
        /// <exception cref="NotImplementedException"></exception>
        public void AddElevatorRequest(ElevatorRequest elevatorRequest)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Submit floor request from a given elevator
        /// </summary>
        /// <param name="floorRequest"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void AddFloorRequest(FloorRequest floorRequest)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get all elevators
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Elevator[] GetElevators()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get all floor requests for a given elevator id
        /// </summary>
        /// <param name="elevatorId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public FloorRequest[] GetFloorRequests(Guid elevatorId)
        {
            throw new NotImplementedException();
        }
    }
}
