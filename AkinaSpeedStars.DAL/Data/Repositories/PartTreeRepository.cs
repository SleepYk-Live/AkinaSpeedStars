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
    internal class PartTreeRepository : IRepository<PartTree>
    {
        private readonly AppContext _db;

        public PartTreeRepository(AppContext context) => _db = context;

        public void Create(PartTree item) => _db.PartTrees.Add(item);

        public void Delete(int id)
        {
            PartTree item = _db.PartTrees.Find(id);
            if (item != null)
                _db.PartTrees.Remove(item);
        }

        public IEnumerable<PartTree> Find(Func<PartTree, bool> predicate) => _db.PartTrees.Where(predicate).ToList();

        public PartTree Get(int id) => _db.PartTrees.Find(id);

        public IEnumerable<PartTree> GetAll() => _db.PartTrees;

        public void Update(PartTree item) => _db.Entry(item).State = EntityState.Modified;
    }
}
