using Mapster;
using Microsoft.EntityFrameworkCore;
using TelemetriaPCan.Domain.DTOs;
using TelemetriaPCan.Domain.Entities;
using TelemetriaPCan.Domain.Interfaces.Repositories;

namespace TelemetriaPCan.Infrastructure.Data.Repositories
{
    public class VehicleRepository : BaseRepository, IVehicleRepository
    {

        public VehicleRepository(AppDbContext context) : base(context) { }

        public async Task<Vehicle?> GetBySerialNumberOrVinAsync(string? serialNumber, string? vin)
        {
            if (string.IsNullOrWhiteSpace(serialNumber) && string.IsNullOrWhiteSpace(vin))
                return null;

            return await _context.Vehicle
                .AsNoTracking()
                .FirstOrDefaultAsync(v =>
                    (!string.IsNullOrWhiteSpace(serialNumber) && v.SerialNumber == serialNumber) ||
                    (!string.IsNullOrWhiteSpace(vin) && v.Vin == vin));
        }

        public async Task<Vehicle> CreateAsync(VehicleDTO dto)
        {
            var vehicleDB = dto.Adapt<Vehicle>();

            await _context.Vehicle.AddAsync(vehicleDB);

            await _context.SaveChangesAsync();

            await _context.Entry(vehicleDB).ReloadAsync();

            return vehicleDB;
        }
    }
}
