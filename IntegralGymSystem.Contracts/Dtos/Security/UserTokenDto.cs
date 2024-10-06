using IntegralGymSystem.Contracts.Dtos.Users;

namespace IntegralGymSystem.Contracts.Dtos.Security
{
    public class UserTokenDto
    {
        public string Token { get; set; } = string.Empty;
        public UserDto User { get; set; } = new UserDto();
    }
}
