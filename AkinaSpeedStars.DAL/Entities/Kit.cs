using AkinaSpeedStars.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkinaSpeedStars.DAL.Entities
{
    /// <summary>
    /// Kit to ModelCode - 1 to many
    /// Kit to PartGroups - many to many
    /// </summary>
    public class Kit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Engine { get; set; }
        public string Body { get; set; }
        public string Grade { get; set; } 
        public bool IsATM { get; set; }
        public string GearShiftType { get; set; }
        public bool IsDriverPositionLeft { get; set; }
        public int NumberOfDoors { get; set; }
        public Destination Destination { get; set; } 
        public Destination AdditionalDestination { get; set; }

        public int ModelId { get; set; }
        public ModelCode ModelCode { get; set; }

        public List<PartGroup> PartGroups { get; set; }
    }
}
