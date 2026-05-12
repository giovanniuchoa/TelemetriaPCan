using Mapster;
using TelemetriaPCan.Application.DTOs;
using TelemetriaPCan.Application.Interfaces.Services;
using TelemetriaPCan.Domain.Entities;
using TelemetriaPCan.Domain.Interfaces.Repositories;

namespace TelemetriaPCan.Application.Services
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

            var toCreate = new Vehicle
            {
                SerialNumber = dto.SerialNumber,
                Vin = dto.Vin
            };

            var created = await _repository.CreateAsync(toCreate);

            return created.Adapt<VehicleDTO>();
        }
    }
}
