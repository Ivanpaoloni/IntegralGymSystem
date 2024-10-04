using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using IntegralGymSystem.Infrastructure.Identity;
using IntegralGymSystem.Domain.Entities;

namespace IntegralGymSystem.Infrastructure
{
    public class IntegralGymSystemDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public IntegralGymSystemDbContext(DbContextOptions<IntegralGymSystemDbContext> options)
            : base(options)
        {
        }
        public DbSet<Gym> Gyms { get; set; }
        public DbSet<Membership> Memberships { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(IntegralGymSystemDbContext).Assembly);
        }
    }
}
