using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AkinaSpeedStars.Models;
using CarDTO = AkinaSpeedStars.DAL.Entities.Car;

namespace AkinaSpeedStars.Models.Converters
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
