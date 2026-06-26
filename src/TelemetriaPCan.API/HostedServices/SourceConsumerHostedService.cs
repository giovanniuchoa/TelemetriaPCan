using Mapster;
using TelemetriaPCan.Application.DTOs;
using TelemetriaPCan.Application.Interfaces.Services;

namespace TelemetriaPCan.API.HostedServices
{
    public class SourceConsumerHostedService : BackgroundService
    {        

        private readonly ISourceService _sourceService;
        private readonly IServiceScopeFactory _scope; // p criar um scope pra cada chamada

        public SourceConsumerHostedService(ISourceService sourceService, IServiceScopeFactory scope)
        {
            _sourceService = sourceService;
            _scope = scope; 
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var frame = await _sourceService.ReadAsync(stoppingToken);

                    using (var scope = _scope.CreateScope())
                    {

                        var _telemetry = scope.ServiceProvider.GetRequiredService<ITelemetryService>();

                        await _telemetry.ProcessFramesAsync(frame);

                    }                                           

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

    }
}
