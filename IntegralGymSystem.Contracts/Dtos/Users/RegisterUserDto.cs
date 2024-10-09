using IntegralGymSystem.Domain.Enums;

namespace IntegralGymSystem.Contracts.Dtos.Users
{
    public class RegisterUserDto
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public RoleEnum Type { get; set; }
        public Guid? GymId { get; set; } // GymId opcional para SuperAdmin
    }

}
