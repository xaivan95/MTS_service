using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTS_service.Model
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Categorye> Categoryes { get; set; } = null!;
        public DbSet<Client> Clients { get; set; } = null!;
        public DbSet<Package> Packages { get; set; } = null!;
        public DbSet<Rate> Rates { get; set; } = null!;
        public DbSet<Rate_categorye> Rate_Categoryes { get; set; } = null!;
        public DbSet<Sim_card> Sim_Cards { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Rate_type> Rate_types { get; set; } = null!;
        public DbSet<Conection> Conections { get; set; } = null!;
        public DbSet<Packages_on_connection> Packages_on_connections { get; set; } = null!;
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "/Data/MTS_DB.db");
        }
    }
}
