using Elevator.Models;
using System;
using System.Collections.Generic;

namespace Elevator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                bool isContinue = true;
                List<ElevatorDetails> elevatorDeatils = new List<ElevatorDetails>();
                Random rnd = new Random();
                ElevatorHelper el = new ElevatorHelper();

                while (isContinue)
                {
                    Console.WriteLine("Welcome!!" + Environment.NewLine +
                                "This building has 3 Floors, operated by 3 Elevators." + Environment.NewLine +
                                "Please see available Elevators below." + Environment.NewLine);

                    var floorFrom = rnd.Next(1, 4);
                    elevatorDeatils = Utilities.DisplayElevatorDetails();
                    Console.WriteLine(Utilities.FloorLevelDisplayMessage(floorFrom));
                    var floorTo = Console.ReadLine();
                    isContinue = el.GetUserInput(floorFrom, floorTo, elevatorDeatils);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
