using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkinaSpeedStars.DAL.Entities
{
    /// <summary>
    /// Car to ModelCode - 1 to many
    /// ModelCode to Kits - 1 to many
    /// </summary>
    public class ModelCode
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public DateTime ProductionStart { get; set; }
        public DateTime ProductionEnd { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }

        public List<Kit> Kits { get; set; }
    }
}
