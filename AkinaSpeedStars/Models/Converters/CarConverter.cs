using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AkinaSpeedStars.BL.Models;
using CarDTO = AkinaSpeedStars.DAL.Entities.Car;

namespace AkinaSpeedStars.BL.Models.Converters
{
    internal static class CarConverter
    {
        public static CarDTO ToSource(Car car)
        {
            return new CarDTO()
            {
                Name = car.Name,
                ModelName = car.ModelName,
            };
        }
    }
}
