using AkinaSpeedStars.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkinaSpeedStars.DAL.Entities
{
    internal class Kit
    {
        public int Id { get; set; }
        public string Engine { get; set; }
        public string Body { get; set; }
        public string Grade { get; set; } 
        public bool IsATM { get; set; }
        public string GearShiftType { get; set; }
        public bool IsDriverPositionLeft { get; set; }
        public int NumberOfDoors { get; set; }
        public Destination Destination { get; set; } 
        public Destination AdditionalDestination { get; set; }
        public IEnumerable<PartGroup> PartGroups { get; set; }
    }
}
