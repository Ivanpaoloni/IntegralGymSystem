using IntegralGymSystem.Domain.Enums;
using IntegralGymSystem.Domain.Interfaces;

namespace IntegralGymSystem.Domain.Entities
{
    public class Exercise : IBaseEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public ExerciseGroupEnum Group { get; set; }
        public ExerciseSubGroupEnum SubGroup { get; set; }
    }
}
