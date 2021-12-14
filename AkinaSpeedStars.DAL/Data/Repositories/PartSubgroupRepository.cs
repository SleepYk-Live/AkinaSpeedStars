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
    internal class PartSubgroupRepository : IRepository<PartSubgroup>
    {
        private readonly AppContext _db;

        public PartSubgroupRepository(AppContext context) => _db = context;

        public void Create(PartSubgroup item) => _db.PartSubgroups.Add(item);

        public void Delete(int id)
        {
            PartSubgroup item = _db.PartSubgroups.Find(id);
            if (item != null)
                _db.PartSubgroups.Remove(item);
        }

        public IEnumerable<PartSubgroup> Find(Func<PartSubgroup, bool> predicate) => _db.PartSubgroups.Where(predicate).ToList();

        public PartSubgroup Get(int id) => _db.PartSubgroups.Find(id);

        public IEnumerable<PartSubgroup> GetAll() => _db.PartSubgroups;

        public void Update(PartSubgroup item) => _db.Entry(item).State = EntityState.Modified;
    }
}
