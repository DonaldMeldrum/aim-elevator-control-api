namespace ElevatorControlAPI.Repositories
{
    public interface IElevatorRepository
    {
        void AddFloorRequest(FloorRequest floorRequest);
        void AddElevatorRequest(ElevatorRequest elevatorRequest);
        Elevator[] GetElevators();
        FloorRequest[] GetFloorRequests(Guid elevatorId);
    }
}
