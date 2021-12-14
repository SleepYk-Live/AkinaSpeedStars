using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PartSubgroupDTO = AkinaSpeedStars.DAL.Entities.PartSubgroup;
using PartGroupDTO = AkinaSpeedStars.DAL.Entities.PartGroup;
using SchemeDTO = AkinaSpeedStars.DAL.Entities.Scheme;

namespace AkinaSpeedStars.Models.Converters
{
    internal class PartSubgroupConverter
    {
        public static PartSubgroupDTO ToSource(PartSubgroup partSubgroup, PartGroupDTO partGroup, SchemeDTO scheme)
        {
            return new PartSubgroupDTO()
            {
                Name = partSubgroup.Name,
                PartGroup = partGroup,
                Scheme = scheme
            };
        }
    }
}
