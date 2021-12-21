using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkinaSpeedStars.BL.Models
{
    internal class Car
    {
        public string Name { get; set; }
        public string ModelName { get; set; }
        public List<string> ModelCodes { get; set; }
        public List<string> ModelLinks { get; set; }
        public List<string> Start { get; set; }
        public List<string> End { get; set; }
        public List<string> Kits { get; set; }

        public Car() 
        {
            ModelCodes = new();
            ModelLinks = new();
            Start = new();
            End = new();
            Kits = new();
        }
    }
}
