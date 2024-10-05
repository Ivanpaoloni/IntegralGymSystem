using IntegralGymSystem.Contracts.Services;
using IntegralGymSystem.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace IntegralGymSystem.Services.Extensions
{
    public static class StartupExtension
    {
        public static void AddIntegralGymSystemServices(this IServiceCollection services)
        {
            services.AddTransient<IGymService, GymService>();
        }
    }
}
