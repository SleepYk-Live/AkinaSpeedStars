using AkinaSpeedStars.DAL.Data.Interfaces;
using AkinaSpeedStars.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkinaSpeedStars.DAL.Data.Repositories
{
    internal class CarRepository : IRepository<Car>
    {
        private readonly AppContext _db;

        public CarRepository(AppContext context) => _db = context;

        public void Create(Car car) => _db.Cars.Add(car);

        public void Delete(int id)
        {
            Car car = _db.Cars.Find(id);
            if (car != null)
                _db.Cars.Remove(car);
        }

        public IEnumerable<Car> Find(Func<Car, bool> predicate) => _db.Cars.Where(predicate).ToList();

        public Car Get(int id) => _db.Cars.Find(id);

        public IEnumerable<Car> GetAll() => _db.Cars;

        public void Update(Car car) => _db.Entry(car).State = EntityState.Modified;
    }
}
