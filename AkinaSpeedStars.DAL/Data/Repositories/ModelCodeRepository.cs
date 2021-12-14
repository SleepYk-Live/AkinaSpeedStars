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
    internal class ModelCodeRepository : IRepository<ModelCode>
    {
        private readonly AppContext _db;

        public ModelCodeRepository(AppContext context) => _db = context;

        public void Create(ModelCode item) => _db.ModelCodes.Add(item);

        public void Delete(int id)
        {
            ModelCode code = _db.ModelCodes.Find(id);
            if (code != null)
                _db.ModelCodes.Remove(code);
        }

        public IEnumerable<ModelCode> Find(Func<ModelCode, bool> predicate) => _db.ModelCodes.Where(predicate).ToList();

        public ModelCode Get(int id) => _db.ModelCodes.Find(id);

        public IEnumerable<ModelCode> GetAll() => _db.ModelCodes;

        public void Update(ModelCode item) => _db.Entry(item).State = EntityState.Modified;
    }
}
