using IntegralGymSystem.Contracts.Dtos.Users;

namespace IntegralGymSystem.Contracts.Services
{
    public interface IUserService
    {
        Task<UserDto> AuthenticateUserAsync(LoginDto dto);
        Task<IEnumerable<string>> GetRolesByUserId(Guid id);
        Task<UserDto> GetUserByEmail(string email);
        Task<UserDto> GetUserById(Guid id);
        Task<IEnumerable<UserDto>> GetUsers();
        Task<Guid> RegisterUserAsync(RegisterUserDto registerDto);
    }
}
