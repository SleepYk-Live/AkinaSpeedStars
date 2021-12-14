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
    internal class PartRepository : IRepository<Part>
    {
        private readonly AppContext _db;

        public PartRepository(AppContext context) => _db = context;

        public void Create(Part part) => _db.Parts.Add(part);

        public void Delete(int id)
        {
            Part part = _db.Parts.Find(id);
            if (part != null)
                _db.Parts.Remove(part);
        }

        public IEnumerable<Part> Find(Func<Part, bool> predicate) => _db.Parts.Where(predicate).ToList();

        public Part Get(int id) => _db.Parts.Find(id);

        public IEnumerable<Part> GetAll() => _db.Parts;

        public void Update(Part part) => _db.Entry(part).State = EntityState.Modified;
    }
}
