using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkinaSpeedStars.DAL.Entities
{
    internal class PartGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<PartSubgroup> Subgroups { get; set; }
    }
}
