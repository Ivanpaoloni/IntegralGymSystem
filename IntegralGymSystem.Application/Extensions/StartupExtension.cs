using IntegralGymSystem.Application.Managers;
using IntegralGymSystem.Contracts.Managers;
using Microsoft.Extensions.DependencyInjection;

namespace IntegralGymSystem.Application.Extensions
{
    public static class StartupExtension
    {
        public static void AddIntegralGymSystemApplicationManagers(this IServiceCollection services)
        {
            services.AddTransient<IUserManager, UserManager>();
        }
    }
}
