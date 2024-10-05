using IntegralGymSystem.Domain.Entities;

namespace IntegralGymSystem.Contracts.Services
{
    public interface IGymService
    {
        Task<Guid> CreateGymAsync(Gym gym, bool saveChanges = false);
        Task<IEnumerable<Gym>> GetAllAsync();
        Task<Gym> GetById(Guid id);
    }
}
