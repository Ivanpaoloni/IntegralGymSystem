using IntegralGymSystem.Contracts.Dtos.Customer;
using IntegralGymSystem.Contracts.Dtos.GymPricing;
using IntegralGymSystem.Contracts.Dtos.WorkoutRoutine;
using IntegralGymSystem.Domain.Interfaces;

namespace IntegralGymSystem.Contracts.Dtos.Gym
{
    public class GymDto : IBaseEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<WorkoutRoutineDto> WorkoutRoutines { get; set; } = new List<WorkoutRoutineDto>();
        public virtual ICollection<CustomerDto> Customers { get; set; } = new List<CustomerDto>();
        public ICollection<GymPricingDto> GymPricings { get; set; } = new List<GymPricingDto>();
    }
}
