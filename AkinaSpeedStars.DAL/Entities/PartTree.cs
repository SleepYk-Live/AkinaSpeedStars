using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkinaSpeedStars.DAL.Entities
{
    internal class PartTree
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public IEnumerable<Part> Parts { get; set; }
    }
}
