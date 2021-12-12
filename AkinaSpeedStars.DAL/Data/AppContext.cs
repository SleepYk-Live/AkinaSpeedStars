using AkinaSpeedStars.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkinaSpeedStars.DAL.Data
{
    internal class AppContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Kit> Kits { get; set; }
        public DbSet<ModelCode> ModelCodes { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<PartGroup> PartGroups { get; set; }
        public DbSet<PartSubgroup> PartSubgroups { get; set; }
        public DbSet<PartTree> PartTrees { get; set; }
        public DbSet<Scheme> Schemes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\AkinaSpeedStars;Initial Catalog=AppDB;");
        }
    }
}
