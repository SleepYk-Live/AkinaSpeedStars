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
    internal class PartGroupRepository : IRepository<PartGroup>
    {
        private readonly AppContext _db;

        public PartGroupRepository(AppContext context) => _db = context;

        public void Create(PartGroup item) => _db.PartGroups.Add(item);

        public void Delete(int id)
        {
            PartGroup item = _db.PartGroups.Find(id);
            if (item != null)
                _db.PartGroups.Remove(item);
        }

        public IEnumerable<PartGroup> Find(Func<PartGroup, bool> predicate) => _db.PartGroups.Where(predicate).ToList();

        public PartGroup Get(int id) => _db.PartGroups.Find(id);

        public IEnumerable<PartGroup> GetAll() => _db.PartGroups;

        public void Update(PartGroup item) => _db.Entry(item).State = EntityState.Modified;
    }
}
