using TelemetriaPCan.Application.DTOs;
using TelemetriaPCan.Application.Interfaces.Services;

namespace TelemetriaPCan.API.HostedServices
{
    public class SourceConsumerHostedService : BackgroundService
    {        

        private readonly IServiceScopeFactory _scopeFactory; // p criar um scope pra cada chamada
        private readonly ISourceService _sourceService;

        public SourceConsumerHostedService(IServiceScopeFactory scopeFactory, ISourceService sourceService)
        {
            _scopeFactory = scopeFactory;
            _sourceService = sourceService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var frame = await _sourceService.ReadAsync(stoppingToken);

                    var vehicleDTO = new VehicleDTO
                    {
                        SerialNumber = frame.SerialNumber,
                        Vin = frame.Vin
                    };

                    await GetOrCreateVehicleAsync(vehicleDTO);
                }
                catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
                {
                    break;
                }
                catch (Exception)
                {
                    await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
                }
            }

        }

        private async Task GetOrCreateVehicleAsync(VehicleDTO vehicleDTO)
        {

            using var scope = _scopeFactory.CreateScope();
            var vehicleService = scope.ServiceProvider.GetRequiredService<IVehicleService>();

            var vehicle = await vehicleService.GetOrCreateAsync(vehicleDTO);

        }

    }
}
