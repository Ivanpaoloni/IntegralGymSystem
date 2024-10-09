using IntegralGymSystem.Domain.Interfaces;

namespace IntegralGymSystem.Domain.Entities
{
    public class Customer : IBaseEntity<Guid>, IBaseGym<Guid>
    {
        public Guid Id { get; set; }
        public Guid GymId {  get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public int DNI { get; set; }
        public string? EmergencyContactName { get; set; }
        public string? EmergencyContactPhoneNumber { get; set; }
        public virtual Gym Gym { get; set; } = new Gym();
        public ICollection<WorkoutRoutine> Workouts { get; set; } = new List<WorkoutRoutine>();
        public ICollection<Membership> Memberships { get; set; } = new List<Membership>();
    }
}
