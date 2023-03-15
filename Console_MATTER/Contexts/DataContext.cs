using Console_MATTER.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_MATTER.Contexts
{
    internal class DataContext : DbContext
    {

        private readonly string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\simon\source\repos\Console_MATTER\Console_MATTER\Contexts\Sql_db.mdf;Integrated Security=True;Connect Timeout=30";

        #region constructor
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        #endregion

        #region overrides
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(_connectionString);
        }
        #endregion


        public DbSet<UserEntity> Users { get; set; } = null!;
        public DbSet<MatterEntity> Matters { get; set; } = null!;
        public DbSet<ClosedMatterEntity> Closed { get; set; } = null!;

    }
}
