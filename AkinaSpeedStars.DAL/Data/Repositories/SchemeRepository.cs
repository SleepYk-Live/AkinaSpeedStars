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
    internal class SchemeRepository : IRepository<Scheme>
    {
        private readonly AppContext _db;

        public SchemeRepository(AppContext context) => _db = context;

        public void Create(Scheme scheme) => _db.Schemes.Add(scheme);

        public void Delete(int id)
        {
            Scheme scheme = _db.Schemes.Find(id);
            if (scheme != null)
                _db.Schemes.Remove(scheme);
        }

        public IEnumerable<Scheme> Find(Func<Scheme, bool> predicate) => _db.Schemes.Where(predicate).ToList();

        public Scheme Get(int id) => _db.Schemes.Find(id);

        // Using eager loading to get all data about Parts in scheme
        public IEnumerable<Scheme> GetAll() => _db.Schemes.Include(x => x.PartTrees);

        public void Update(Scheme scheme) => _db.Entry(scheme).State = EntityState.Modified;
    }
}
