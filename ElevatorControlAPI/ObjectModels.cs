namespace ElevatorControlAPI
{
    public class Elevator
    {
        public Guid Id { get; set; }
        public Floor currentFloor { get; set; }
        public Request[] FloorRequests { get; set; }
    }

    public class Floor
    {
        public Guid Id { get; set; }
        public string DisplayName { get; set; }
        public int LevelNumber { get; set; }
    }

    public class Request
    {
        public Guid Id { get; set; }
        public DateTime RequestTime { get; set; }
        public Elevator Elevator { get; set; }
        public Floor Floor { get; set; }
        public RequestStatus Status { get; set; }
    }

    public enum RequestStatus
    {        
        Pending,
        Cancelled,
        Fulfilled
    }

}