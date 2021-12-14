using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KitDTO = AkinaSpeedStars.DAL.Entities.Kit;
using ModelCodeDTO = AkinaSpeedStars.DAL.Entities.ModelCode;

namespace AkinaSpeedStars.Models.Converters
{
    internal class KitConverter
    {
        public static KitDTO ToSource(Kit kit, ModelCodeDTO modelCode)
        {
            DAL.Enums.Destination destination;
            Enum.TryParse(kit.Destination, out destination);
            DAL.Enums.Destination addtionalDestination;
            Enum.TryParse(kit.AdditionalDestination, out addtionalDestination);

            return new KitDTO()
            {
                Name = kit.Name,
                Engine = kit.Engine,
                Body = kit.Body,
                Grade = kit.Grade,
                IsATM = kit.Transmission == "ATM",
                IsDriverPositionLeft = kit.DriverPosition == "Left",
                GearShiftType = kit.GearShiftType,
                NumberOfDoors = Int32.Parse(kit.NumberOfDoors),
                Destination = destination,
                AdditionalDestination = addtionalDestination,
                ModelCode = modelCode
            };
        }
    }
}
