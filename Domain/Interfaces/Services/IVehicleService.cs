using TelemetriaPCan.Domain.DTOs;

namespace TelemetriaPCan.Domain.Interfaces.Services
{
    public interface IVehicleService
    {

        Task CreateAsync(VehicleDTO dto);

    }
}
