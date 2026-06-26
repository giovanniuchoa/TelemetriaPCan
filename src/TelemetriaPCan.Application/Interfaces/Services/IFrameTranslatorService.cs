using TelemetriaPCan.Application.DTOs;

namespace TelemetriaPCan.Application.Interfaces.Services
{
    public interface IFrameTranslatorService
    {

        TelemetryDTO TryTranslate(CanFrameDTO frame, int? idVehicle);

    }
}
