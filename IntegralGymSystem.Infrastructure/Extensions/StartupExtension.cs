using IntegralGymSystem.Contracts.Services;
using IntegralGymSystem.Contracts.UnitOfWork;
using IntegralGymSystem.Infrastructure.Identity;
using IntegralGymSystem.Infrastructure.Identity.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IntegralGymSystem.Infrastructure.Extensions
{
    public static class StartupExtension
    {
        public static void AddIntegralGymSystemRepository(this IServiceCollection services, string connectionString)
        {

            // Configura el DbContext
            services.AddDbContext<IntegralGymSystemDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddTransient<IUserService, UserService>();

            services.AddIdentity<ApplicationUser, IdentityRole<Guid>>()
                .AddEntityFrameworkStores<IntegralGymSystemDbContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddScoped<RoleManager<IdentityRole<Guid>>>();
        }
    }
}
