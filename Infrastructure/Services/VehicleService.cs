using Mapster;
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

        public async Task<VehicleDTO> GetOrCreateAsync(VehicleDTO dto)
        {
            var existing = await _repository.GetBySerialNumberOrVinAsync(dto.SerialNumber, dto.Vin);

            if (existing is not null)
                return existing.Adapt<VehicleDTO>();

            var created = await _repository.CreateAsync(dto);

            return created.Adapt<VehicleDTO>();
        }
    }
}
