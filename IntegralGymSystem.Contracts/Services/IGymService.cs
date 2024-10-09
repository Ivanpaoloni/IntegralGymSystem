using IntegralGymSystem.Contracts.Dtos.Gym;
using IntegralGymSystem.Domain.Entities;

namespace IntegralGymSystem.Contracts.Services
{
    public interface IGymService
    {
        Task<Gym> GetById(Guid id);
        Task<IEnumerable<Gym>> GetAllAsync();
        Task<Guid> CreateGymAsync(Gym gym, bool saveChanges = false);
        Task UpdateGymAsync(GymDto dto, bool saveChanges = false);
        Task Delete(Guid id);
    }
}
