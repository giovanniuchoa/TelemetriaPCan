using TelemetriaPCan.Application.DTOs;

namespace TelemetriaPCan.Application.Interfaces.Services
{
    public interface IVehicleService
    {

        Task<VehicleDTO> GetOrCreateAsync(VehicleDTO dto);

    }
}
