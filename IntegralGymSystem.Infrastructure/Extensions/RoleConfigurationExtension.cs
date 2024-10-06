using IntegralGymSystem.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

public static class RoleConfigurationExtensions
{
    public static async Task ConfigureRoles(this IServiceProvider serviceProvider)
    {
        var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();
        foreach (var roleName in Enum.GetNames(typeof(MembershipTypeEnum)))
        {
            var roleExist = await RoleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                await RoleManager.CreateAsync(new IdentityRole<Guid> { Name = roleName });
            }
        }
    }
}
