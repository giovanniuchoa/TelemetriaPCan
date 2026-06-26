using Mapster;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TelemetriaPCan.Application.DTOs;
using TelemetriaPCan.Application.Interfaces.Services;
using TelemetriaPCan.Domain.Entities;
using TelemetriaPCan.Domain.Interfaces.Repositories;

namespace TelemetriaPCan.Application.Services
{
    public class TelemetryService : ITelemetryService
    {

        private readonly ITelemetryRepository _repository;
        private readonly IFrameTranslatorService _translator;
        private readonly IVehicleService _vehicle;

        public TelemetryService(ITelemetryRepository repository, IFrameTranslatorService translator, IVehicleService vehicle)
        {
            _repository = repository;
            _translator = translator;
            _vehicle = vehicle;
        }

        public async Task<bool> CreateAsync(TelemetryDTO dto)
        {

            dto.IdTelemetry = Guid.NewGuid().ToString("N");
            dto.CreatedAt = DateTime.Now;

            var telemetry = dto.Adapt<Telemetry>();

            var ret = await _repository.CreateAsync(telemetry);

            return ret;

        }

        public async Task<bool> ProcessFramesAsync(CanFrameDTO dto)
        {

            var vehicle = await _vehicle.GetOrCreateAsync(dto.Adapt<VehicleDTO>());

            var telemetry = _translator.TryTranslate(dto, vehicle.IdVehicle);

            await CreateAsync(telemetry);

            return true;
        }
    }
}
