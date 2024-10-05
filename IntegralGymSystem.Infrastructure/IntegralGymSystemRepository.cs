using IntegralGymSystem.Contracts.Repository;
using IntegralGymSystem.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IntegralGymSystem.Infrastructure
{
    internal class IntegralGymSystemRepository<T> : IRepository<T> where T : class, IBaseEntity<Guid> // Aquí se agregó la restricción 'class'
    {
        private readonly IntegralGymSystemDbContext _context;
        private readonly DbSet<T> _dbSet;

        public IntegralGymSystemRepository(IntegralGymSystemDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T> GetByIdAsync(Guid id) => await _dbSet.FindAsync(id);

        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

        public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);

        public async Task UpdateAsync(T entity) => _dbSet.Update(entity);

        public async Task DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null) _dbSet.Remove(entity);
        }
    }
}
