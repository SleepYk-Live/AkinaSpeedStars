using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkinaSpeedStars.DAL.Entities
{
    internal class PartSubgroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Scheme> Schemes { get; set; }
    }
}
