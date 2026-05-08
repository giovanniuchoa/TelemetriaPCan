using TelemetriaPCan.Domain.DTOs;

namespace TelemetriaPCan.Domain.Interfaces.Repositories
{
    public interface IVehicleRepository
    {

        Task CreateAsync(VehicleDTO dto);

    }
}
