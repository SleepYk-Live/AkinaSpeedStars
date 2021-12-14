using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PartGroupDTO = AkinaSpeedStars.DAL.Entities.PartGroup;

namespace AkinaSpeedStars.Models.Converters
{
    internal class PartGroupConverter
    {
        public static PartGroupDTO ToSource(PartGroup partGroup)
        {
            return new PartGroupDTO()
            {
                Name = partGroup.Name
            };
        }
    }
}
