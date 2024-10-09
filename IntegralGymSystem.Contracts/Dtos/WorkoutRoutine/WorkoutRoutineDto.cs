using IntegralGymSystem.Contracts.Dtos.Customer;
using IntegralGymSystem.Contracts.Dtos.Gym;
using IntegralGymSystem.Contracts.Dtos.WorkoutRoutineExercise;
using IntegralGymSystem.Domain.Interfaces;

namespace IntegralGymSystem.Contracts.Dtos.WorkoutRoutine
{
    public class WorkoutRoutineDto : IBaseEntity<Guid>, IBaseGym<Guid>
    {
        public Guid Id { get; set; } // GUID como ID
        public Guid GymId { get; set; } // Gym como TenantId
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public virtual GymDto Gym { get; set; } = new GymDto(); 
        public virtual ICollection<CustomerDto> Customer { get; set; } = new List<CustomerDto>();
        public virtual ICollection<WorkoutRoutineExerciseDto> WorkoutRoutineExercises { get; set; } = new List<WorkoutRoutineExerciseDto>();
    }
}
