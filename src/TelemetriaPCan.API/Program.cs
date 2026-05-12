using TelemetriaPCan.Application;
using TelemetriaPCan.Application.Interfaces.Services;
using TelemetriaPCan.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

#region TESTE

//using (var scope = app.Services.CreateScope())
//{
//    var vehicle = scope.ServiceProvider.GetRequiredService<IVehicleService>();

//    var dto = new TelemetriaPCan.Application.DTOs.VehicleDTO
//    {
//        SerialNumber = "2019"
//    };

//    await vehicle.GetOrCreateAsync(dto);
//}

#endregion

app.Run();
