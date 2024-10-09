using IntegralGymSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace IntegralGymSystem.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public Guid? GymId { get; set; } // Gym como TenantId, puede ser nulo para SuperAdmin.
        public virtual Gym Gym { get; set; }

    }
}
