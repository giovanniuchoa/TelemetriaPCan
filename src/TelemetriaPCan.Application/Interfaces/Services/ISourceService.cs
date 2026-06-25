using TelemetriaPCan.Application.DTOs;

namespace TelemetriaPCan.Application.Interfaces.Services
{
    public interface ISourceService
    {

        Task<CanFrameDTO> ReadAsync(CancellationToken cancellationToken = default);

    }
}
