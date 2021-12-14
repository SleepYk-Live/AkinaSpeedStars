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
    internal class KitRepository : IRepository<Kit>
    {
        private readonly AppContext _db;

        public KitRepository(AppContext context) => _db = context;

        public void Create(Kit kit) => _db.Kits.Add(kit);

        public void Delete(int id)
        {
            Kit kit = _db.Kits.Find(id);
            if (kit != null)
                _db.Kits.Remove(kit);
        }

        public IEnumerable<Kit> Find(Func<Kit, bool> predicate) => _db.Kits.Where(predicate).ToList();

        public Kit Get(int id) => _db.Kits.Find(id);

        public IEnumerable<Kit> GetAll() => _db.Kits;

        public void Update(Kit kit) => _db.Entry(kit).State = EntityState.Modified;
    }
}
