using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TelemetriaPCan.Domain.Interfaces.Repositories;
using TelemetriaPCan.Infrastructure.Data;
using TelemetriaPCan.Infrastructure.Data.Repositories;

namespace TelemetriaPCan.Infrastructure
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("PC_Campos");

            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

            services.AddTransient<IVehicleRepository, VehicleRepository>();

            return services;
        }

    }
}
