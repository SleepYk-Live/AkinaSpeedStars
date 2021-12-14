using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PartDTO = AkinaSpeedStars.DAL.Entities.Part;
using PartTreeDTO = AkinaSpeedStars.DAL.Entities.PartTree;

namespace AkinaSpeedStars.Models.Converters
{
    internal class PartConverter
    {
        public static PartDTO ToSource(Part part, PartTreeDTO partTree)
        {
            var range = part.ProductionRange.Split('-');

            return new PartDTO()
            {
                Code = Int64.Parse(part.Code),
                Count = Int32.Parse(part.Count),
                ProductionStart = DateTime.Parse(range.First()), // TODO: check if it is necessary to convert into utc
                ProductionEnd = range.Length == 2 ? DateTime.Parse(range.Last()) : null, // // TODO: check if it is necessary to convert into utc
                Info = part.Info,
                PartTree = partTree
            };
        }
    }
}
