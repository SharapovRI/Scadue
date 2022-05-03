using Microsoft.EntityFrameworkCore;
using Scadue.Data.Models;
using Scadue.Data.ModelsConfigurations;

namespace Scadue.Data
{
    public class NpgsqlContext : DbContext
    {
        public DbSet<AdministrativeUnitEntity> AdministrativeUnits { get; set; }
        public DbSet<UnitCoordinatesEntity> UnitCoordinates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=ScadueAPI_DB;Username=postgres;Password=PostgreSQL");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AdministrativeUnitEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UnitCoordinatesEntityConfiguration());
        }
    }
}
