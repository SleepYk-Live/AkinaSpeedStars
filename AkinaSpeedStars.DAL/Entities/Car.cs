using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkinaSpeedStars.DAL.Entities
{
    /// <summary>
    /// Entity which has 1 to many relationship to ModelCode entity
    /// </summary>
    internal class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ModelName { get; set; }

        public IEnumerable<ModelCode> ModelCodes { get; set; }
    }
}
