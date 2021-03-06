using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkinaSpeedStars.DAL.Entities
{
    /// <summary>
    /// Kit to PartGroup - many to many
    /// PartGroup to Subgroup - 1 to many
    /// </summary>
    public class PartGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Kit> Kits { get; set; }

        public List<PartSubgroup> Subgroups { get; set; }
    }
}
