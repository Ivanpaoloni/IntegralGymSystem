using IntegralGymSystem.Contracts.Dtos.Gym;
using IntegralGymSystem.Contracts.Managers;
using IntegralGymSystem.Contracts.Services;
using IntegralGymSystem.Contracts.UnitOfWork;
using IntegralGymSystem.Domain.Entities;

namespace IntegralGymSystem.Services.Services
{
    public class GymService : IGymService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GymService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Gym>> GetAllAsync()
        {
            var gyms = await _unitOfWork.Gyms.GetAllAsync();
            return gyms;
        }

        public async Task<Gym> GetById(Guid id)
        {
            var gym = await _unitOfWork.Gyms.GetByIdAsync(id);
            if (gym == null) throw new ArgumentException("Gym no encontrado");

            return gym;
        }

        public async Task<Guid> CreateGymAsync(Gym gym, bool saveChanges = false)
        {
            gym.Id = Guid.NewGuid();

            await _unitOfWork.Gyms.AddAsync(gym);
            if (saveChanges) await _unitOfWork.SaveAsync(); // Guardar cambios en la base de datos

            return gym.Id;
        }

        public async Task UpdateGymAsync(GymDto dto, bool saveChanges = false)
        {
            await UpdateGymAsync(new Gym
            {
                Address = dto.Address,
                City = dto.City,
                Country = dto.Country,
                Id = dto.Id,
                Name = dto.Name,
                Phone = dto.Phone
            }, false);

            if(saveChanges) await _unitOfWork.SaveAsync();
        }

        public async Task Delete(Guid id)
        {
            await _unitOfWork.Gyms.DeleteAsync(id);
        }

        internal async Task<Gym> FindGymById(Guid id)
        {
            var result = await _unitOfWork.Gyms.GetByIdAsync(id);

            if (result == null) throw new ArgumentException("Gym no encontrado");

            return result;
        }

        internal async Task UpdateGymAsync(Gym gym, bool saveChanges = false)
        {
            var oldGym = await FindGymById(gym.Id);

            oldGym.Address = gym.Address;
            oldGym.Name = gym.Name;
            oldGym.City = gym.City;
            oldGym.Country = gym.Country;
            oldGym.Phone = gym.Phone;

            await _unitOfWork.Gyms.UpdateAsync(oldGym);
            if (saveChanges) await _unitOfWork.SaveAsync();
        }
    }
}
