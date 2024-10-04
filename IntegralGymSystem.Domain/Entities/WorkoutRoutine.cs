using IntegralGymSystem.Domain.Interfaces;

namespace IntegralGymSystem.Domain.Entities
{
    public class WorkoutRoutine : IBaseEntity<Guid>
    {
        public Guid Id { get; set; } // GUID como ID
        public Guid GymId { get; set; } // Gym como TenantId
        public virtual Gym Gym { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<WorkoutRoutineExercise> Exercises { get; set; } = new List<WorkoutRoutineExercise>();
    }

}
