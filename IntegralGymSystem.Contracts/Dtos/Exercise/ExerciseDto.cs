using IntegralGymSystem.Domain.Enums;
using IntegralGymSystem.Domain.Interfaces;

namespace IntegralGymSystem.Contracts.Dtos.Exercise
{
    public class ExerciseDto : IBaseEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public ExerciseGroupEnum Group { get; set; }
        public ExerciseSubGroupEnum SubGroup { get; set; }
    }
}
