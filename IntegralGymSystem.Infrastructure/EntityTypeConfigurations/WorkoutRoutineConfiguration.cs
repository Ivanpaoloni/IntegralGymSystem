using IntegralGymSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace IntegralGymSystem.Infrastructure.EntityTypeConfigurations
{
    public class WorkoutRoutineConfiguration : IEntityTypeConfiguration<WorkoutRoutine>
    {
        public void Configure(EntityTypeBuilder<WorkoutRoutine> builder)
        {
            builder.HasKey(w => w.Id);

            builder.HasOne(w => w.Gym)
                   .WithMany(g => g.WorkoutRoutines)
                   .HasForeignKey(w => w.GymId);
        }
    }
}
