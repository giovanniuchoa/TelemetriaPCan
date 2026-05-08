using TelemetriaPCan.Domain.DTOs;
using TelemetriaPCan.Domain.Interfaces.Repositories;
using TelemetriaPCan.Domain.Interfaces.Services;

namespace TelemetriaPCan.Infrastructure.Services
{
    public class VehicleService : IVehicleService
    {

        private readonly IVehicleRepository _repository;

        public VehicleService(IVehicleRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateAsync(VehicleDTO dto)
            => await _repository.CreateAsync(dto);
    }
}
