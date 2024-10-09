using IntegralGymSystem.Domain.Interfaces;

namespace IntegralGymSystem.Domain.Entities
{
    public class WorkoutRoutine : IBaseEntity<Guid>, IBaseGym<Guid>
    {
        public Guid Id { get; set; } // GUID como ID
        public Guid GymId { get; set; } // Gym como TenantId
        public virtual Gym Gym { get; set; } = new Gym();
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public virtual ICollection<Customer> Customer { get; set; } = new List<Customer>();
        public virtual ICollection<WorkoutRoutineExercise> WorkoutRoutineExercises { get; set; } = new List<WorkoutRoutineExercise>();
    }
}
