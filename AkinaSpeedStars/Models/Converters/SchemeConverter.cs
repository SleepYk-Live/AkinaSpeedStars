using AkinaSpeedStars.ApplicationServices.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchemeDTO = AkinaSpeedStars.DAL.Entities.Scheme;
using PartSubgroupDTO = AkinaSpeedStars.DAL.Entities.PartSubgroup;

namespace AkinaSpeedStars.Models.Converters
{
    internal class SchemeConverter
    {
        public static SchemeDTO ToSource(Scheme scheme, PartSubgroupDTO partSubgroup, IFileManager manager)
        {
            return new SchemeDTO()
            {
                Image = manager.GetImage(scheme.ImageUrl),
                PartSubgroup = partSubgroup
            };
        }
    }
}
