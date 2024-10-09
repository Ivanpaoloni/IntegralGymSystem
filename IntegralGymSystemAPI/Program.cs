using IntegralGymSystem.Application.Extensions;
using IntegralGymSystem.Domain.Enums;
using IntegralGymSystem.Infrastructure.Extensions;
using IntegralGymSystem.Services.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//Get connectionString of appsettings
string? connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection")
                         ?? builder.Configuration.GetConnectionString("DefaultConnection");

if (string.IsNullOrEmpty(connectionString)) throw new InvalidOperationException("La cadena de conexión no puede ser nula o vacía.");

// Configuración de JWT
var key = builder.Configuration["Jwt:Key"];
var issuer = builder.Configuration["Jwt:Issuer"];
var audience = builder.Configuration["Jwt:Audience"];

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = issuer,
            ValidAudience = audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
        };
    });
builder.Services.AddSwaggerGen(c =>
{
    // Define el esquema de seguridad para Swagger
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter 'Bearer' [space] and then your token in the text input below.\n\nExample: \"Bearer 12345abcdef\"",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
    });

    // Asegura que los endpoints usen el esquema de seguridad definido
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("SuperAdminOnly", policy => policy.RequireRole(RoleEnum.SuperAdmin.ToString()));
    options.AddPolicy("AdminOnly", policy => policy.RequireRole(RoleEnum.Admin.ToString()));
    options.AddPolicy("InstructorOnly", policy => policy.RequireRole(RoleEnum.Instructor.ToString()));
    options.AddPolicy("MemberOnly", policy => policy.RequireRole(RoleEnum.Member.ToString()));
});

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
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
