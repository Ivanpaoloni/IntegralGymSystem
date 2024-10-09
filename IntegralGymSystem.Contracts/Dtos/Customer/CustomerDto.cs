using IntegralGymSystem.Contracts.Dtos.Gym;
using IntegralGymSystem.Contracts.Dtos.Membership;
using IntegralGymSystem.Contracts.Dtos.WorkoutRoutine;
using IntegralGymSystem.Domain.Interfaces;

namespace IntegralGymSystem.Contracts.Dtos.Customer
{
    public class CustomerDto : IBaseEntity<Guid>, IBaseGym<Guid>
    {
        public Guid Id { get; set; }
        public Guid GymId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public int DNI { get; set; }
        public string? EmergencyContactName { get; set; }
        public string? EmergencyContactPhoneNumber { get; set; }
        public virtual GymDto Gym { get; set; } = new GymDto();
        public ICollection<WorkoutRoutineDto> WorkoutRoutines { get; set; } = new List<WorkoutRoutineDto>();
        public ICollection<MembershipDto> Memberships { get; set; } = new List<MembershipDto>();
    }
}
