using IntegralGymSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace IntegralGymSystem.Infrastructure.EntityTypeConfigurations
{
    public class MembershipConfiguration : IEntityTypeConfiguration<Membership>
    {
        public void Configure(EntityTypeBuilder<Membership> builder)
        {
            builder.ToTable("Memberships", "dbo");

            //Primary key 
            builder.HasKey(m => m.Id);

            //Properties
            builder.Property(m => m.GymId).IsRequired();
            builder.Property(m => m.UserId).IsRequired();
            builder.Property(m => m.Type).IsRequired().HasColumnType("smallint");

            builder.HasOne(m => m.Gym)
                   .WithMany(g => g.Memberships)
                   .HasForeignKey(m => m.GymId);
        }
    }

}
