using IntegralGymSystem.Domain.Enums;
using IntegralGymSystem.Domain.Interfaces;

namespace IntegralGymSystem.Domain.Entities
{
    public class Membership : IBaseEntity<Guid>, IBaseGym<Guid>
    {
        public Guid Id { get; set; }
        public Guid GymId { get; set; }
        public Guid UserId { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Amount { get; set; }
        public virtual Customer Customer { get; set; } = new Customer();
        public virtual Gym Gym { get; set; } = new Gym();
    }
}
