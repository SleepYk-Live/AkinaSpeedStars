using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkinaSpeedStars.BL.Models
{
    internal class PartTree
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public List<Part> Parts { get; set; }
    }
}
