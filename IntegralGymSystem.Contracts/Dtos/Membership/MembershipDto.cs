using IntegralGymSystem.Contracts.Dtos.Gym;
using IntegralGymSystem.Domain.Enums;

namespace IntegralGymSystem.Contracts.Dtos.Membership
{
    public class MembershipDto
    {
        public Guid Id { get; set; }
        public Guid GymId { get; set; }
        public Guid UserId { get; set; }
        public RoleEnum Type { get; set; }
        public virtual GymDto Gym { get; set; }
    }
}
