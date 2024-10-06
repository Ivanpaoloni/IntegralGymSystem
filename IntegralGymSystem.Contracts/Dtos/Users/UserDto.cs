namespace IntegralGymSystem.Contracts.Dtos.Users
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string? UserName { get; set; }
        public Guid? GymId { get; set; }
        public IEnumerable<string> Roles { get; set; } = [];
    }
}
