using IntegralGymSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntegralGymSystem.Infrastructure.EntityTypeConfigurations
{
    public class GymConfiguration : IEntityTypeConfiguration<Gym>
    {
        public void Configure(EntityTypeBuilder<Gym> builder)
        {
            builder.ToTable("Gyms", "dbo");

            //Primary key 
            builder.HasKey(e => e.Id);

            //Properties
            builder.Property(e => e.Name).IsRequired().HasColumnType("nvarchar(100)");
            builder.Property(e => e.City).IsRequired().HasColumnType("nvarchar(100)");
            builder.Property(e => e.Country).IsRequired().HasColumnType("nvarchar(100)");
            builder.Property(e => e.Phone).IsRequired().HasColumnType("nvarchar(20)");

            builder.HasMany(e => e.Memberships)
                .WithOne(m => m.Gym)
                .HasForeignKey(m => m.GymId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}