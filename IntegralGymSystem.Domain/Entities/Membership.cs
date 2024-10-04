using IntegralGymSystem.Domain.Interfaces;

namespace IntegralGymSystem.Domain.Entities
{
    public class Membership : IBaseEntity<Guid>, IBaseGym<Guid>
    {
        public Guid Id { get; set; }
        public Guid GymId { get; set; }
        public Guid UserId { get; set; }
        public MembershipTypeEnum Type { get; set; }
        public virtual Gym Gym { get; set; }
    }
}
