using IntegralGymSystem.Contracts.Dtos.Users;
using IntegralGymSystem.Contracts.Managers;
using IntegralGymSystem.Contracts.Services;
using System;
using System.Threading.Tasks;

namespace IntegralGymSystem.Application.Managers
{
    public class UserManager : IUserManager
    {
        private readonly IUserService _userService;

        public UserManager(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<Guid> Register(RegisterUserDto dto)
        {
            try
            {
                return await _userService.RegisterUserAsync(dto);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al registrar el usuario.", ex.Message);
            }
        }

        public async Task<UserDto> Login(LoginDto dto)
        {
            try
            {
                return await _userService.AuthenticateUserAsync(dto);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al autenticar el usuario.", ex);
            }
        }

        public async Task<UserDto> GetUserById(Guid id)
        {
            try
            {
                return await _userService.GetUserById(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al obtener el usuario.", ex);
            }
        }

        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            try
            {
                return await _userService.GetUsers();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al obtener los usuarios.", ex);
            }
        }
    }
}
