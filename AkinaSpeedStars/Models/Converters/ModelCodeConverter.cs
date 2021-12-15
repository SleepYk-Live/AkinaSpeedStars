using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelCodeDTO = AkinaSpeedStars.DAL.Entities.ModelCode;
using CarDTO = AkinaSpeedStars.DAL.Entities.Car;

namespace AkinaSpeedStars.Models.Converters
{
    public class ModelCodeConverter
    {
        public static ModelCodeDTO ToSource(CarDTO car, string code)
        {
            return new ModelCodeDTO()
            {
                Code = code, 
                Car = car
            };
        }
    }
}
