using TelemetriaPCan.Domain.DTOs;
using TelemetriaPCan.Domain.Entities;

namespace TelemetriaPCan.Domain.Interfaces.Repositories
{
    public interface IVehicleRepository
    {

        Task<Vehicle?> GetBySerialNumberOrVinAsync(string? serialNumber, string? vin);

        Task<Vehicle> CreateAsync(VehicleDTO dto);

    }
}
