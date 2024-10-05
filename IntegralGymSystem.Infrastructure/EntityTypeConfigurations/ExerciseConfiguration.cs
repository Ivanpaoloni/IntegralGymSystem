using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using IntegralGymSystem.Domain.Entities;

namespace IntegralGymSystem.Infrastructure.EntityTypeConfigurations
{
    public class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> builder)
        {
            builder.ToTable("Exercises", "dbo");

            //Primary Key
            builder.HasKey(e => e.Id);

            //Properties
            builder.Property(e => e.Name).IsRequired().HasColumnType("nvarchar(100)");

            builder.Property(e => e.Description).HasColumnType("nvarchar(500)");

            builder.Property(e => e.Group).IsRequired().HasColumnType("smallint");

            builder.Property(e => e.SubGroup).IsRequired().HasColumnType("smallint");

        }
    }

}
