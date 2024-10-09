using IntegralGymSystem.Domain.Interfaces;

namespace IntegralGymSystem.Domain.Entities
{
    public class Gym : IBaseEntity<Guid>
    {
        public Guid Id { get; set; } // GUID como ID
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<WorkoutRoutine> WorkoutRoutines { get; set; } = new List<WorkoutRoutine>();
        public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
        public ICollection<GymPricing> GymPricings { get; set; } = new List<GymPricing>();
    }
}
