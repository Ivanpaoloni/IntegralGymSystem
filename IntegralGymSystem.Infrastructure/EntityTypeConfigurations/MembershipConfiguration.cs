using IntegralGymSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace IntegralGymSystem.Infrastructure.EntityTypeConfigurations
{
    public class MembershipConfiguration : IEntityTypeConfiguration<Membership>
    {
        public void Configure(EntityTypeBuilder<Membership> builder)
        {
            // Table
            builder.ToTable("Memberships", "dbo");

            // Primary Key
            builder.HasKey(m => m.Id);

            // Properties
            builder.Property(m => m.PaymentDate).IsRequired().HasColumnType("datetime2");
            builder.Property(m => m.StartDate).IsRequired().HasColumnType("datetime2");
            builder.Property(m => m.EndDate).IsRequired().HasColumnType("datetime2");
            builder.Property(m => m.Amount).IsRequired().HasColumnType("decimal(18,2)");

            builder.HasOne(m => m.Customer)
                   .WithMany(c => c.Memberships)
                   .HasForeignKey(m => m.CustomerId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
