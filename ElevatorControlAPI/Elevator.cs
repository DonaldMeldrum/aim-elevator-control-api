namespace ElevatorControlAPI
{
    public class Elevator
    {
        public Guid Id { get; set; }
        public FloorRequest[] RequestArray { get; set; }
    }

    public class Floor
    {
        public Guid Id { get; set; }
        public string DisplayName { get; set; }
        public int LevelNumber { get; set; }
    }

    public class FloorRequest
    {
        public DateTime RequestTime { get; set; }
        public Floor? RequestedFloor { get; set; }
        public RequestStatus Status { get; set; }
    }

    public class ElevatorRequest
    {
        public DateTime RequestTime { get; set; }
        public Elevator? RequestedElevator { get; set; }
        public RequestStatus Status { get; set; }
    }

    public enum RequestStatus
    {        
        Pending,
        Cancelled,
        Fulfilled
    }

}