using AkinaSpeedStars.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkinaSpeedStars.DAL.Data
{
    /// <summary>
    /// Creates application database
    /// </summary>
    internal class AppContext : DbContext
    {
        private readonly string _connectionString;
        public DbSet<Car> Cars { get; set; }
        public DbSet<Kit> Kits { get; set; }
        public DbSet<ModelCode> ModelCodes { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<PartGroup> PartGroups { get; set; }
        public DbSet<PartSubgroup> PartSubgroups { get; set; }
        public DbSet<PartTree> PartTrees { get; set; }
        public DbSet<Scheme> Schemes { get; set; }

        public AppContext(string connectionString)
        {
            /// TODO: set connection string in configuration file (code smell)
            _connectionString = connectionString ?? @"Server=(localdb)\mssqllocaldb;Database=akinaappdb;Trusted_Connection=True;";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
