using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkinaSpeedStars.DAL.Entities
{
    /// <summary>
    /// PartTree to Part - 1 to many
    /// </summary>
    public class Part
    {
        [Key]
        public long Code { get; set; } 
        public int Count { get; set; }
        public DateTime ProductionStart { get; set; }
        public DateTime? ProductionEnd { get; set; }
        public string Info { get; set; }

        public int PartTreeId { get; set; }
        public PartTree PartTree { get; set; }
    }
}
