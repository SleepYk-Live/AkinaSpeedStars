using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkinaSpeedStars.DAL.Entities
{
    /// <summary>
    /// PartGroup to PartSubgroup - 1 to many
    /// Scheme to PartSubgroup - 1 to 1
    /// </summary>
    public class PartSubgroup
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int PartGroupId { get; set; }
        public PartGroup PartGroup { get; set; }

        public Scheme Scheme { get; set; }
    }
}
