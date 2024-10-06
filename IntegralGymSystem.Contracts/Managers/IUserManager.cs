using IntegralGymSystem.Contracts.Dtos.Users;

namespace IntegralGymSystem.Contracts.Managers
{
    public interface IUserManager
    {
        Task<UserDto> GetUserById(Guid id);
        Task<IEnumerable<UserDto>> GetUsers();
        Task<UserDto> Login(LoginDto dto);
        Task<Guid> Register(RegisterUserDto dto);
    }
}
