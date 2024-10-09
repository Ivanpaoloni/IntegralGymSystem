using IntegralGymSystem.Contracts.Dtos.Exercise;
using IntegralGymSystem.Domain.Interfaces;

namespace IntegralGymSystem.Contracts.Dtos.WorkoutRoutineExercise
{
    public class WorkoutRoutineExerciseDto : IBaseEntity<Guid>
    {
        public Guid Id { get; set; }
        public Guid WorkoutRoutineId { get; set; }
        public virtual WorkoutRoutineExerciseDto WorkoutRoutine { get; set; } = new WorkoutRoutineExerciseDto();
        public Guid ExerciseId { get; set; }
        public ExerciseDto Exercise { get; set; } = new ExerciseDto();
        public int Sets { get; set; }
        public int Reps { get; set; }
        public int RestTime { get; set; }
    }
}
