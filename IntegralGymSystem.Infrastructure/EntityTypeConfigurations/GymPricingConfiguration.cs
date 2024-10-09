using IntegralGymSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntegralGymSystem.Infrastructure.EntityTypeConfigurations
{
    public class GymPricingConfiguration : IEntityTypeConfiguration<GymPricing>
    {
        public void Configure(EntityTypeBuilder<GymPricing> builder)
        {
            // Table configurations
            builder.ToTable("GymPricings", "dbo");
            builder.HasKey(gp => gp.Id);

            // Properties
            builder.Property(gp => gp.DayPassPrice).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(gp => gp.ThreeDaysPerWeekPrice).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(gp => gp.UnlimitedPassPrice).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(gp => gp.FunctionalTrainingPrice).IsRequired().HasColumnType("decimal(18,2)");

            // Relationships
            builder.HasOne(gp => gp.Gym)
                .WithMany(g => g.GymPricings)
                .HasForeignKey(gp => gp.GymId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
