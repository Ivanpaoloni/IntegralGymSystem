using IntegralGymSystem.Contracts.Dtos.Gym;
using IntegralGymSystem.Domain.Interfaces;

namespace IntegralGymSystem.Contracts.Dtos.GymPricing
{
    public class GymPricingDto : IBaseEntity<Guid>
    {
        public Guid Id { get; set; }
        public Guid GymId { get; set; }
        public GymDto Gym { get; set; } = new GymDto();

        public decimal DayPassPrice { get; set; }
        public decimal ThreeDaysPerWeekPrice { get; set; }
        public decimal UnlimitedPassPrice { get; set; }
        public decimal FunctionalTrainingPrice { get; set; }
    }
}
