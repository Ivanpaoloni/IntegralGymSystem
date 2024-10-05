using IntegralGymSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace IntegralGymSystem.Infrastructure.EntityTypeConfigurations
{
    public class WorkoutRoutineConfiguration : IEntityTypeConfiguration<WorkoutRoutine>
    {
        public void Configure(EntityTypeBuilder<WorkoutRoutine> builder)
        {
            builder.ToTable("WorkoutRoutines", "dbo");

            builder.HasKey(w => w.Id);
            builder.Property(e => e.Name).IsRequired().HasColumnType("nvarchar(100)");
            builder.Property(e => e.Description).IsRequired().HasColumnType("nvarchar(200)");

            builder.HasOne(w => w.Gym)
                   .WithMany(g => g.WorkoutRoutines)
                   .HasForeignKey(w => w.GymId);
        }
    }
}
