using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using TelemetriaPCan.Domain.Entities;

namespace TelemetriaPCan.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {

        public DbSet<Vehicle> Vehicle { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt) { }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Conventions.Remove(typeof(TableNameFromDbSetConvention));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(AppDbContext).Assembly);
        }

    }
}
