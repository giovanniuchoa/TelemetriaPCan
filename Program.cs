using Microsoft.EntityFrameworkCore;
using TelemetriaPCan.Domain.DTOs;
using TelemetriaPCan.Domain.Interfaces.Repositories;
using TelemetriaPCan.Domain.Interfaces.Services;
using TelemetriaPCan.Infrastructure.Data;
using TelemetriaPCan.Infrastructure.Data.Repositories;
using TelemetriaPCan.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

#region DataBase

var connectionString = builder.Configuration.GetConnectionString("PC_Campos");

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connectionString));

#endregion

builder.Services.AddTransient<IVehicleRepository, VehicleRepository>();
builder.Services.AddTransient<IVehicleService, VehicleService>();

var app = builder.Build();

#region TESTE

//using (var scope = app.Services.CreateScope())
//{
//    var vehicle = scope.ServiceProvider.GetRequiredService<IVehicleService>();

//    var dto = new VehicleDTO
//    {
//        SerialNumber = "2019"
//    };

//    await vehicle.GetOrCreateAsync(dto);
//}

#endregion

app.Run();