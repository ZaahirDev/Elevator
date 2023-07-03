using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Elevator.Models;

namespace Elevator.Tests
{
    [TestClass()]
    public class ElevatorHelperTests
    {
        [TestMethod()]
        public void GetUserInputTest()
        {
            var elevatorHelper = new ElevatorHelper();
            List<ElevatorDetails> elevatorDetailsList = new List<ElevatorDetails>();
            ElevatorDetails elevatorDeatails = new ElevatorDetails
            {
                AmountOfPeople = 3,
                Direction = "Down",
                Floor = 3,
                FloorTo = 1,
                Name = "The Voyager",
                Status = "Occupied"
            };
            elevatorDetailsList.Add(elevatorDeatails);

            var outcome = elevatorHelper.GetUserInput(1, "2", elevatorDetailsList);
            Assert.AreEqual(true, outcome);
        }

        [TestMethod()]
        public void GetFloorCollectionTest()
        {
            var elevatorHelper = new ElevatorHelper();
            int floorFrom = 1;
            var floorTo = "2";
            var outcome = elevatorHelper.GetFloorCollection(floorFrom, floorTo);

            List<int> floorCollection = new List<int>
            {
                short.Parse(floorTo.ToString())
            };

            Assert.IsTrue(floorCollection.SequenceEqual(outcome));
        }

        [TestMethod()]
        public void ValidateFloorSelectionTest()
        {
            var elevatorHelper = new ElevatorHelper();
            int floorFrom = 1;
            var floorTo = "2";

            List<int> floorCollection = new List<int>
            {
                short.Parse(floorTo.ToString())
            };

            var outcome = elevatorHelper.ValidateFloorSelection(floorFrom, floorCollection);
            Assert.AreEqual(true, outcome);
        }
    }
}