using IntegralGymSystem.Contracts.UnitOfWork;
using IntegralGymSystem.Infrastructure; // Asegúrate de tener el espacio de nombres correcto
using IntegralGymSystem.Services.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configura el DbContext
builder.Services.AddDbContext<IntegralGymSystemDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); // Cambia "DefaultConnection" por tu cadena de conexión real

// Add services to the container.
builder.Services.AddIntegralGymSystemServices();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(); // Reemplaza 'UnitOfWork' con el nombre real de tu clase


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
