using Elevator.Interfaces;
using Elevator.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Elevator
{
    public class ElevatorHelper : IElevator
    {
        #region GetUserInput
        /// <summary>
        /// Receieves the users Input
        /// </summary>
        /// <param name="floorFrom"></param>
        /// <param name="floorTo"></param>
        /// <returns></returns>
        /// 
        public bool GetUserInput(int floorFrom, string floorTo, List<ElevatorDetails> elevatorDetails)
        {
            if (floorTo.ToLower().Trim() == "q")
            {
                Console.WriteLine(Environment.NewLine + "Good-Bye");
                return false;
            }
            else
            {
                var floorCollection = GetFloorCollection(floorFrom, floorTo);
                bool hasValidationPassed = ValidateFloorSelection(floorFrom, floorCollection);

                while (!hasValidationPassed)
                {
                    Console.WriteLine(Utilities.FloorLevelDisplayMessage(floorFrom));
                    floorTo = Console.ReadLine();
                    floorCollection = GetFloorCollection(floorFrom, floorTo);
                    hasValidationPassed = ValidateFloorSelection(floorFrom, floorCollection);
                }
                GetElevator(floorFrom, elevatorDetails);
                return true;
            }
        }
        #endregion

        #region GetFloorCollection
        /// <summary>
        /// Validates if the input is numeric and creates a collection if more than one floor has been selected
        /// </summary>
        /// <param name="floorFrom"></param>
        /// <param name="floorTo"></param>
        /// <returns></returns>
        public List<int> GetFloorCollection(int floorFrom, string floorTo)
        {
            List<int> floorCollection = new List<int>();
            int floorToValue;

            while (!int.TryParse(floorTo, out floorToValue))
            {
                Console.WriteLine(Environment.NewLine + "Only numeric values allowed!");
                Console.WriteLine(Utilities.FloorLevelDisplayMessage(floorFrom));
                floorTo = Console.ReadLine();
            }

            foreach (char c in floorTo)
            {
                floorCollection.Add(Int16.Parse(c.ToString()));
            }
            //Returns a distinct list should the user of entered the same number more than once  
            return floorCollection.Distinct().ToList();
        }
        #endregion

        #region ValidateFloorSelection
        /// <summary>
        /// Validates if the selection made by the is valid 
        /// </summary>
        /// <param name="floorFrom"></param>
        /// <param name="floorToCollection"></param>
        /// <returns></returns>
        public bool ValidateFloorSelection(int floorFrom, List<int> floorToCollection)
        {

            for (int i = 0; i < floorToCollection.Count(); i++)
            {
                if (floorFrom == floorToCollection[i])
                {
                    Console.WriteLine(Environment.NewLine + "You are already on the floor {0}", floorToCollection[i]);
                    return false;
                }
                else if (floorToCollection[i] > 3)
                {
                    Console.WriteLine(Environment.NewLine + "Invalid Selection, Incorrect floor selection: {0} does not exist!!", floorToCollection[i]);
                    return false;
                }
            }

            return true;
        }
        #endregion

        #region GetElevator
        /// <summary>
        /// Returns the closest Elevator to the user
        /// </summary>
        /// <param name="floorFrom"></param>
        /// <param name="elevatorDetails"></param>
        public void GetElevator(int floorFrom, List<ElevatorDetails> elevatorDetails)
        {
            //Returns the closest Elevator to the user that is available 
            var closestElevator = elevatorDetails?.Where(x => x.Status != "Occupied")
                                                ?.OrderBy(x => Math.Abs(floorFrom - x.Floor)).FirstOrDefault();

            //In the event there are no elevators available, the user is notified and the process continues until a elevator becomes available
            while (closestElevator == null)
            {
                Console.WriteLine("All Elevators are unavailble, please hold for an elevator be available");
                elevatorDetails = Utilities.DisplayElevatorDetails();
                closestElevator = elevatorDetails?.Where(x => x.Status != "Occupied")
                                                ?.OrderBy(x => Math.Abs(floorFrom - x.Floor)).FirstOrDefault();

            }
            if (closestElevator != null)
            {
                Console.WriteLine(Environment.NewLine + "The elevator has arrived.." + Environment.NewLine +
                                  "Name: {0}" + Environment.NewLine +
                                  "From Floor: {1}" + Environment.NewLine +
                                  "Amount of People: {2}" + Environment.NewLine,
                                   closestElevator.Name,
                                   closestElevator.Floor,
                                   closestElevator.AmountOfPeople);
                Console.WriteLine("Enjoy your ride on the {0}!!" + Environment.NewLine, closestElevator.Name);
            }
        }
        #endregion
    }
}
