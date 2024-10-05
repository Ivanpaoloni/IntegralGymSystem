using IntegralGymSystem.Contracts.Repository;
using IntegralGymSystem.Domain.Entities;

namespace IntegralGymSystem.Contracts.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Gym> Gyms { get; }
        IRepository<Membership> Memberships { get; }
        IRepository<Exercise> Exercises { get; }
        IRepository<WorkoutRoutine> WorkoutRoutines { get; }
        Task<int> SaveAsync();
    }
}
