using Mapster;
using TelemetriaPCan.Domain.DTOs;
using TelemetriaPCan.Domain.Entities;
using TelemetriaPCan.Domain.Interfaces.Repositories;

namespace TelemetriaPCan.Infrastructure.Data.Repositories
{
    public class VehicleRepository : BaseRepository, IVehicleRepository
    {

        public VehicleRepository(AppDbContext context) : base(context) { }

        public async Task CreateAsync(VehicleDTO dto)
        {

            try
            {

                var vehicleDB = dto.Adapt<Vehicle>();

                await _context.Vehicle.AddAsync(vehicleDB);

                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {

            }

        }
    }
}
