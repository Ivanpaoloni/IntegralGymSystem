using IntegralGymSystem.Application.Extensions;
using IntegralGymSystem.Infrastructure.Extensions;
using IntegralGymSystem.Services.Extensions;

var builder = WebApplication.CreateBuilder(args);

//Get connectionString of appsettings
string? connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection")
                         ?? builder.Configuration.GetConnectionString("DefaultConnection");

if (string.IsNullOrEmpty(connectionString)) throw new InvalidOperationException("La cadena de conexión no puede ser nula o vacía.");

builder.Services.AddIntegralGymSystemRepository(connectionString);

// Add services to the container.
builder.Services.AddIntegralGymSystemServices();
builder.Services.AddIntegralGymSystemApplicationManagers();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure Roles
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await services.ConfigureRoles();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();

app.Run();
