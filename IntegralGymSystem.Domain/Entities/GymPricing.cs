using IntegralGymSystem.Domain.Interfaces;

namespace IntegralGymSystem.Domain.Entities
{
    public class GymPricing : IBaseEntity<Guid>
    {
        public Guid Id { get; set; }
        public Guid GymId { get; set; }
        public Gym Gym { get; set; } = new Gym();

        public decimal DayPassPrice { get; set; }
        public decimal ThreeDaysPerWeekPrice { get; set; }
        public decimal UnlimitedPassPrice { get; set; }
        public decimal FunctionalTrainingPrice { get; set; }
    }
}