using IntegralGymSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace IntegralGymSystem.Infrastructure.EntityTypeConfigurations
{
    public class WorkoutRoutineExerciseConfiguration : IEntityTypeConfiguration<WorkoutRoutineExercise>
    {
        public void Configure(EntityTypeBuilder<WorkoutRoutineExercise> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.WorkoutRoutine)
                   .WithMany(r => r.Exercises)
                   .HasForeignKey(e => e.WorkoutRoutineId)
                   .OnDelete(DeleteBehavior.Cascade); // Cuando se elimina una rutina, se eliminan sus ejercicios.

            builder.Property(e => e.ExerciseName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(e => e.Sets)
                   .IsRequired();

            builder.Property(e => e.Reps)
                   .IsRequired();

            builder.Property(e => e.RestTime)
                   .IsRequired();
        }
    }

}
