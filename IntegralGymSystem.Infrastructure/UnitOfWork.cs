using IntegralGymSystem.Contracts.Repository;
using IntegralGymSystem.Contracts.UnitOfWork;
using IntegralGymSystem.Domain.Entities;

namespace IntegralGymSystem.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IntegralGymSystemDbContext _context;

        public UnitOfWork(IntegralGymSystemDbContext context)
        {
            _context = context;
        }

        private IRepository<Gym> _gyms;
        public IRepository<Gym> Gyms => _gyms ??= new IntegralGymSystemRepository<Gym>(_context);

        private IRepository<Membership> _memberships;
        public IRepository<Membership> Memberships => _memberships ??= new IntegralGymSystemRepository<Membership>(_context);

        private IRepository<Exercise> _exercises;
        public IRepository<Exercise> Exercises => _exercises ??= new IntegralGymSystemRepository<Exercise>(_context);

        private IRepository<WorkoutRoutine> _workoutRoutines;
        public IRepository<WorkoutRoutine> WorkoutRoutines => _workoutRoutines ??= new IntegralGymSystemRepository<WorkoutRoutine>(_context);

        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();
    }
}
