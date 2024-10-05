﻿using IntegralGymSystem.Contracts.Services;
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
            if(saveChanges) await _unitOfWork.SaveAsync(); // Guardar cambios en la base de datos

            return gym.Id;
        }
    }
}
