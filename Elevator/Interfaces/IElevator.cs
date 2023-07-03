using Elevator.Models;
using System.Collections.Generic;

namespace Elevator.Interfaces
{
    public interface IElevator
    {
        bool GetUserInput(int floorFrom, string floorTo, List<ElevatorDetails> elevatorDeatils);
        List<int> GetFloorCollection(int floorFrom, string floorTo);
        bool ValidateFloorSelection(int floorFrom, List<int> floorToCollection);
        void GetElevator(int floorFrom, List<ElevatorDetails> elevatorDetails);
    }
}
