using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TelemetriaPCan.Domain.Entities;

namespace TelemetriaPCan.Infrastructure.Data.Configurations
{
    public class TelemetryConfiguration : IEntityTypeConfiguration<Telemetry>
    {

        public void Configure(EntityTypeBuilder<Telemetry> builder)
        {
            builder.ToTable("Telemetry");

            builder.HasKey(x => x.IdTelemetry);

            builder.Property(x => x.IdTelemetry)
                .HasColumnType("VARCHAR(40)")
                .IsRequired()
                .ValueGeneratedNever();

            builder.Property(x => x.IdVehicle)
                .IsRequired();

            builder.Property(x => x.FuelLevel)
                .HasColumnType("DECIMAL(5,2)")
                .IsRequired();

            builder.HasOne<Vehicle>()
                .WithMany()
                .HasForeignKey(x => x.IdVehicle)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => x.IdVehicle);
        }

    }
}
