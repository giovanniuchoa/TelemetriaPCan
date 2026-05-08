using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TelemetriaPCan.Domain.Entities;

namespace TelemetriaPCan.Infrastructure.Data.Configurations
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {

        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable("Vehicle");

            builder.HasKey(x => x.IdVehicle);

            builder.Property(x => x.IdVehicle)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.CreatedAt)
                .HasColumnType("DATETIME")
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            builder.Property(x => x.SerialNumber)
                .HasColumnType("VARCHAR(200)");

            builder.Property(x => x.Vin)
                .HasColumnType("VARCHAR(200)");
        }

    }
}
