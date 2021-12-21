using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PartTreeDTO = AkinaSpeedStars.DAL.Entities.PartTree;
using SchemeDTO = AkinaSpeedStars.DAL.Entities.Scheme;

namespace AkinaSpeedStars.BL.Models.Converters
{
    internal class PartTreeConverter
    {
        public static PartTreeDTO ToSource(PartTree partTree, SchemeDTO scheme)
        {
            return new PartTreeDTO()
            {
                Code = partTree.Code,
                Name = partTree.Name,
                Scheme = scheme
            };
        }
    }
}
