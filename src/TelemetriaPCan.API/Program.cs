using TelemetriaPCan.Application;
using TelemetriaPCan.API.HostedServices;
using TelemetriaPCan.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddHostedService<SourceConsumerHostedService>();

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
