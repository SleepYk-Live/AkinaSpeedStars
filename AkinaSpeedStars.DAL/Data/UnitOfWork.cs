using AkinaSpeedStars.DAL.Data.Interfaces;
using AkinaSpeedStars.DAL.Data.Repositories;
using AkinaSpeedStars.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkinaSpeedStars.DAL.Data
{
    /// <summary>
    /// Repository and UoW implementation to simplify database usage
    /// </summary>
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly AppContext _db;
        private CarRepository _carRepository;
        private KitRepository _kitRepository;
        private ModelCodeRepository _modelCodeRepository;
        private PartRepository _partRepository;
        private PartGroupRepository _partGroupRepository;
        private PartSubgroupRepository _partSubgroupRepository;
        private PartTreeRepository _partTreeRepository;
        private SchemeRepository _schemeRepository;

        public UnitOfWork(string connectionString) => _db = new AppContext(connectionString);

        public IRepository<Car> Cars => _carRepository ?? new CarRepository(_db);

        public IRepository<Kit> Kits => _kitRepository ?? new KitRepository(_db);

        public IRepository<ModelCode> ModelCodes => _modelCodeRepository ?? new ModelCodeRepository(_db);

        public IRepository<Part> Parts => _partRepository ?? new PartRepository(_db);

        public IRepository<PartGroup> PartGroups => _partGroupRepository ?? new PartGroupRepository(_db);

        public IRepository<PartSubgroup> PartSubgroups => _partSubgroupRepository ?? new PartSubgroupRepository(_db);

        public IRepository<PartTree> PartTrees => _partTreeRepository ?? new PartTreeRepository(_db);

        public IRepository<Scheme> Scheme => _schemeRepository ?? new SchemeRepository(_db);

        private bool _disposed = false;

        public void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                _disposed = true;
            }
        }

        public void Save() => _db.SaveChanges();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
