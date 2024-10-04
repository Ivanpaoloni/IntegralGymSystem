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

        public virtual ICollection<Membership> Memberships { get; set; } = new List<Membership>();
        public virtual ICollection<WorkoutRoutine> WorkoutRoutines { get; set; } = new List<WorkoutRoutine>();
    }
}
