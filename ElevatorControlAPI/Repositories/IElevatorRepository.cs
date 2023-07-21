namespace ElevatorControlAPI.Repositories
{
    public interface IElevatorRepository
    {
        void AddRequest(Request request);
        Elevator[] GetElevators();
        Elevator GetElevator(Guid elevatorId);
        Floor GetFloor(Guid floorId);
        Request[] GetFloorRequests(Guid elevatorId);
    }
}
