using IntegralGymSystem.Domain.Interfaces;

namespace IntegralGymSystem.Domain.Entities
{
    public class WorkoutRoutineExercise : IBaseEntity<Guid>
    {
        public Guid Id { get; set; } // GUID como ID
        public Guid WorkoutRoutineId { get; set; }
        public virtual WorkoutRoutine WorkoutRoutine { get; set; } 
        public Guid ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public int RestTime { get; set; } // Descanso en segundos
    }

}
