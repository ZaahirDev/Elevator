using ConsoleTables;
using Elevator.Models;
using System;
using System.Collections.Generic;

namespace Elevator
{
    public class Utilities
    {
        #region DisplayElevatorDetails
        /// <summary>
        /// Creates a display screen of the actitivity for each elevator
        /// 1. Name
        /// 2. Floor (Current floor the Elevator is on)
        /// 3. FloorTo (The floor to which the elevator is going to)
        /// 4. Direction (In which direction the elevator is moving)
        /// 5. AmountOfPeople (The amount of people on the Elevator)
        /// 6. status (Status of the Elevator)
        /// </summary>
        /// <returns></returns>
        public static List<ElevatorDetails> DisplayElevatorDetails()
        {
            List<ElevatorDetails> elevatorDetails = new List<ElevatorDetails>();
            Random rndAmountOfPeople = new Random();
            Random rnd = new Random();
            string[] status = { "Available", "Occupied" };
            string[] elevatorNames = { "Battlestar Galactica", "The Voyager", "Genesis" };
            string[] elevatorDirection = { "Up", "Down" };


            for (int i = 0; i < 3; i++)
            {
                ElevatorDetails ed = new ElevatorDetails
                {
                    AmountOfPeople = rnd.Next(1, 5),
                    Status = status[rnd.Next(0, 2)],
                    Floor = rnd.Next(1, 4)
                };

                if (ed.Status.Equals("Available"))
                {
                    ed.Direction = "Not Moving";
                    ed.FloorTo = ed.Floor;
                }
                else if (ed.Status.Equals("Occupied") && ed.Floor == 1)
                {
                    ed.Direction = "Up";
                    ed.FloorTo = rnd.Next(2, 4);
                }
                else if (ed.Status.Equals("Occupied") && ed.Floor == 2)
                {
                    ed.Direction = elevatorDirection[rnd.Next(0, 2)];
                    ed.FloorTo = ed.Direction.Equals("Up") ? 3 : 1;
                }
                else if (ed.Status.Equals("Occupied") && ed.Floor == 3)
                {
                    ed.Direction = "Down";
                    ed.FloorTo = rnd.Next(1, 3);
                }
                ed.Name = elevatorNames[i];

                elevatorDetails.Add(ed);
            }

            ConsoleTable.From(elevatorDetails)
                        .Configure(o => o.NumberAlignment = Alignment.Right)
                        .Write(Format.Alternative);

            return elevatorDetails;
        }
        #endregion

        #region FloorLevelDisplayMessage
        /// <summary>
        /// Generic Method to be used to display the floor level message
        /// </summary>
        /// <returns></returns>
        public static string FloorLevelDisplayMessage(int floorFrom)
        {
            var message = string.Empty;
            if (floorFrom == 1)
            {
                message = "You are on Floor: " + floorFrom + Environment.NewLine + "These are the available floors to select from 2 and/or 3 press q to exit the elevator";
            }
            else if (floorFrom == 2)
            {
                message = "You are on Floor: " + floorFrom + Environment.NewLine + "These are the available floors to select from 1 and/or 3 press q to exit the elevator";
            }
            else if (floorFrom == 3)
            {
                message = "You are on Floor: " + floorFrom + Environment.NewLine + "These are the available floors to select from 1 and/or 2 press q to exit the elevator";
            }
            return message;
        }
        #endregion
    }
}
