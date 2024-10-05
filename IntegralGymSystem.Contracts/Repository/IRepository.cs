using IntegralGymSystem.Domain.Interfaces;

namespace IntegralGymSystem.Contracts.Repository
{
    public interface IRepository<T> where T : class, IBaseEntity<Guid>
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
    }
}
