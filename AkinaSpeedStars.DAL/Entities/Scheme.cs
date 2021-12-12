using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkinaSpeedStars.DAL.Entities
{
    internal class Scheme
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public IEnumerable<PartTree> PartTree { get; set; }
    }
}
