using Microsoft.Extensions.DependencyInjection;
using TelemetriaPCan.Application.Interfaces.Services;
using TelemetriaPCan.Application.Services;

namespace TelemetriaPCan.Application
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IVehicleService, VehicleService>();
            services.AddTransient<ITelemetryService, TelemetryService>();
            services.AddSingleton<IFrameTranslatorService, FrameTranslatorService>();

            return services;
        }

    }
}
