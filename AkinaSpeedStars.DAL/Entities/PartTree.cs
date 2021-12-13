using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkinaSpeedStars.DAL.Entities
{
    /// <summary>
    /// PartTree to Scheme - many to 1
    /// PartTree to Part - 1 to many
    /// In that case I purpose that Parts cant be in many PartTrees
    /// </summary>
    internal class PartTree
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public int SchemeId { get; set; }
        public Scheme Scheme { get; set; }

        public List<Part> Parts { get; set; }
    }
}
