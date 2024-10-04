namespace IntegralGymSystem.Domain.Interfaces
{
    public interface IBaseGym<KeyType>
    {
        KeyType GymId { get; set; } // Gym ID para multitenancy
    }
}
