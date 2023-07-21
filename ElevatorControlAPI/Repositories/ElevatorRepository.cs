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
        /// Gets a list of the floors that have been requested (i.e. which buttons should light up).
        /// </summary>
        /// <param name="elevator"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public FloorRequest[] GetFloorRequests(Elevator elevator)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get the next floor to be serviced for given elevator.
        /// </summary>
        /// <param name="elevator"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Floor GetNextFloor(Elevator elevator)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Request an elevator from a given floor.
        /// </summary>
        /// <param name="floor"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void RequestElevator(Floor floor)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Requests a floor from a given elevator (i.e. person presses button inside elevator).
        /// </summary>
        /// <param name="elevator"></param>
        /// <param name="floor"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void RequestFloor(Elevator elevator, Floor floor)
        {
            throw new NotImplementedException();
        }
    }
}
