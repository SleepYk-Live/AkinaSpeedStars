using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkinaSpeedStars.Models
{
    internal class Scheme
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public List<PartTree> PartTrees { get; set; }
    }
}
