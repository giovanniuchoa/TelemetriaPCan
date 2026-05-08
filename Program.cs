using Microsoft.EntityFrameworkCore;
using TelemetriaPCan.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

#region DataBase

var connectionString = builder.Configuration.GetConnectionString("PC_Campos");

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connectionString));

#endregion

var app = builder.Build();

app.Run();
