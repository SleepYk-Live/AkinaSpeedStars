using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkinaSpeedStars.DAL.Entities
{
    /// <summary>
    /// Scheme to PartSubgroup - 1 to 1
    /// Scheme to PartTree - 1 to many
    /// </summary>
    internal class Scheme
    {
        public int Id { get; set; }
        public string Image { get; set; }

        public int PartSubgroupId { get; set; }
        public PartSubgroup PartSubgroup { get; set; }

        public List<PartTree> PartTrees { get; set; }
    }
}
