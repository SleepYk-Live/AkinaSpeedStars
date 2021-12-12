using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkinaSpeedStars.DAL.Entities
{
    internal class Part
    {
        public long Code { get; set; } // pk
        public int Count { get; set; }
        public DateTime ProductionStart { get; set; }
        public DateTime ProductionEnd { get; set; }
        public string Info { get; set; }
    }
}
