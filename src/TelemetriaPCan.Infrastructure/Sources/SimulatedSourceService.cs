using Microsoft.Extensions.Configuration;
using TelemetriaPCan.Application.DTOs;
using TelemetriaPCan.Application.Interfaces.Services;

namespace TelemetriaPCan.Infrastructure.Sources
{
    public class SimulatedSourceService : ISourceService
    {

        public async Task<CanFrameDTO> ReadAsync(CancellationToken cancellationToken = default)
        {
            await Task.Delay(TimeSpan.FromSeconds(5), cancellationToken);

            return CreateFrame();
        }

        private static CanFrameDTO CreateFrame()
        {
            var data = new byte[8];
            Random.Shared.NextBytes(data);

            return new CanFrameDTO
            {
                Id = (uint)Random.Shared.Next(0x100, 0x800),
                Data = data,
                Timestamp = DateTimeOffset.UtcNow,
                IsExtendedFrame = false,
                SerialNumber = $"SIM-{Random.Shared.Next(1000, 9999)}",
                Vin = Guid.NewGuid().ToString("N")[..17].ToUpper()
            };
        }

    }
}
