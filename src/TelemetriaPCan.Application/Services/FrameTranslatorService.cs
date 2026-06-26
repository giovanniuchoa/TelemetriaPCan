using TelemetriaPCan.Application.DTOs;
using TelemetriaPCan.Application.Interfaces.Services;

namespace TelemetriaPCan.Application.Services
{
    public class FrameTranslatorService : IFrameTranslatorService
    {

        //private const uint FuelLevelFrameId = 0x100;
        private const int FuelLevelByteIndex = 0;

        public TelemetryDTO TryTranslate(CanFrameDTO frame, int? idVehicle)
        {      

            var fuelLevel = frame.Data[FuelLevelByteIndex];

            var telemetry = new TelemetryDTO
            {
                IdVehicle = idVehicle,
                FuelLevel = fuelLevel
            };

            return telemetry;
        }

    }
}
