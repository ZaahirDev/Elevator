using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator.Models
{
    public class ElevatorDetails
    {
        public string Name { get; set; }
        public int Floor { get; set; }
        public int FloorTo { get; set; }
        public string Direction { get; set; }
        public int AmountOfPeople { get; set; }
        public string Status { get; set; }

    }
}
