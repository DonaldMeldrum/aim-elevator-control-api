namespace ElevatorControlAPI.Repositories
{
    public interface IElevatorRepository
    {
        void RequestFloor(Elevator elevator, Floor floor);
        FloorRequest[] GetFloorRequests(Elevator elevator);
        void RequestElevator(Floor floor);
        Floor GetNextFloor(Elevator elevator);
    }
}
