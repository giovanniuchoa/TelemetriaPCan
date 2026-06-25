using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TelemetriaPCan.Application.Interfaces.Services;
using TelemetriaPCan.Domain.Interfaces.Repositories;
using TelemetriaPCan.Infrastructure.Data;
using TelemetriaPCan.Infrastructure.Data.Repositories;
using TelemetriaPCan.Infrastructure.Sources;

namespace TelemetriaPCan.Infrastructure
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("PC_Campos");

            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

            services.AddTransient<IVehicleRepository, VehicleRepository>();

            AddSource(services, configuration);

            return services;
        }

        private static void AddSource(IServiceCollection services, IConfiguration configuration)
        {
            var sourceType = configuration["Source:Type"] ?? "SIMULATION";

            switch (sourceType?.Trim().ToLowerInvariant())
            {
                case "simulation":
                case "simulated":
                case "fake":
                    services.AddSingleton<ISourceService, SimulatedSourceService>();
                    break;

                default:
                    throw new InvalidOperationException($"Source type '{sourceType}' is not supported yet.");
            }
        }

    }
}
