using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using IntegralGymSystem.Infrastructure.Identity;

namespace IntegralGymSystem.Infrastructure.EntityTypeConfigurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            //Primary key 
            builder.HasKey(u => u.Id);

            //Properties
            builder.Property(u => u.GymId).IsRequired(false); // null for SuperAdmin

            builder.HasMany(u => u.Memberships)
            .WithOne() // No Membership navigation property
            .HasForeignKey(m => m.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
