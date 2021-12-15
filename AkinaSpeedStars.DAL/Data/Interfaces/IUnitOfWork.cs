using AkinaSpeedStars.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkinaSpeedStars.DAL.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Car> Cars { get; }
        IRepository<Kit> Kits { get; }
        IRepository<ModelCode> ModelCodes { get; }
        IRepository<Part> Parts { get; }
        IRepository<PartGroup> PartGroups { get; }
        IRepository<PartSubgroup> PartSubgroups { get; }
        IRepository<PartTree> PartTrees { get; }
        IRepository<Scheme> Scheme { get; }
        void Save();
    }
}
