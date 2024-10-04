namespace IntegralGymSystem.Domain.Interfaces
{
    public interface IBaseEntity<KeyType>
    {
        KeyType Id { get; set; } // ID será manejado por el servicio
    }
}
