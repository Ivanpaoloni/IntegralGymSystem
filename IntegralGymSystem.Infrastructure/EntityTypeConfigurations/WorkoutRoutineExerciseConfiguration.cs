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

            // Relación con WorkoutRoutine (una rutina puede tener varios ejercicios)
            builder.HasOne(wre => wre.WorkoutRoutine)
                .WithMany(wr => wr.WorkoutRoutineExercises)
                .HasForeignKey(wre => wre.WorkoutRoutineId)
                .OnDelete(DeleteBehavior.Restrict); // Evita la eliminación en cascada


            builder.HasOne(wre => wre.Exercise)
            .WithMany() // No necesitamos la navegación inversa aquí
            .HasForeignKey(wre => wre.ExerciseId)
            .OnDelete(DeleteBehavior.Restrict); // Eliminar un Exercise no elimina los WorkoutRoutineExercises


            builder.Property(e => e.Sets)
                   .IsRequired();

            builder.Property(e => e.Reps)
                   .IsRequired();

            builder.Property(e => e.RestTime)
                   .IsRequired();
        }
    }

}
