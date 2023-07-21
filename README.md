# aim-elevator-control-api
Elevator Control API

To run the API from windows command line: 

..\aim-elevator-control-api\ElevatorControlAPI>dotnet run --environment Development

To test the following scenarios:
1. A person requests an elevator be sent to their current floor
- http://localhost:8080/elevator/RequestElevator?floorId=[[guid]]

2. A person requests that they be brought to a floor
- http://localhost:8080/elevator/RequestFloor?elevatorId=[[guid]]&floorId=[[guid]]

3. An elevator car requests all floors that it’s current passengers are servicing (e.g. to light up the buttons that show which floors the car is going to)
- http://localhost:8080/elevator/GetRequestedFloors?elevatorId=[[guid]]

4. An elevator car requests the next floor it needs to service
- http://localhost:8080/elevator/GetNextFloor?elevatorId=[[guid]]

The Repository layer is using dummy data, so use any valid Guid for elevatorId and floorId.
- e.g. http://localhost:8080/elevator/RequestFloor?elevatorId=1499e33d-4b87-4cb2-8ed5-aa767c515be0&floorId=1499e33d-4b87-4cb2-8ed5-aa767c515be0
