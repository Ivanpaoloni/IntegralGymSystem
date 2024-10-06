using IntegralGymSystem.Contracts.Dtos.Users;
using IntegralGymSystem.Contracts.Services;
using IntegralGymSystem.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IntegralGymSystem.Infrastructure.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            var users = _userManager.Users.ToList();
            var usersDto = new List<UserDto>();
            foreach (var user in users)
            {
                usersDto.Add(new UserDto
                {
                    UserName = user.UserName,
                    Email = user.Email!,
                    GymId = user.GymId,
                    Id = user.Id,
                    Roles = await GetRolesByUserId(user.Id)
                });
            }
            return usersDto;
        }
        public async Task<UserDto> GetUserById(Guid id)
        {
            var user = await FindUserById(id);

            var dto = new UserDto
            {
                Id = user.Id,
                Email = user.Email!,
                GymId = user.GymId,
                UserName = user.UserName!,
                Roles = await GetRolesByUser(user)
            };

            return dto;
        }

        public async Task<UserDto> GetUserByEmail(string email)
        {
            var user = await FindUserByEmail(email);

            var dto = new UserDto
            {
                Id = user.Id,
                Email = user.Email!,
                GymId = user.GymId,
                UserName = user.UserName!,
                Roles = await GetRolesByUser(user)
            };

            return dto;
        }

        public async Task<IEnumerable<string>> GetRolesByUserId(Guid id)
        {
            var user = await FindUserById(id);
            var roles = await GetRolesByUser(user);

            return roles;
        }

        public async Task<Guid> RegisterUserAsync(RegisterUserDto registerDto)
        {
            var user = new ApplicationUser
            {
                Id = Guid.NewGuid(),
                UserName = registerDto.Email,
                Email = registerDto.Email,
                GymId = registerDto.GymId
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded)
            {
                throw new ArgumentException(result.Errors.ToString());
            }

            await _userManager.AddToRoleAsync(user, registerDto.Type.ToString());

            return user.Id;
        }

        public async Task<UserDto> AuthenticateUserAsync(LoginDto dto)
        {
            var result = await _signInManager.PasswordSignInAsync(dto.Email, dto.Password, false, false);

            if (!result.Succeeded) throw new ArgumentException("Error de autenticacion");

            var user = await FindUserByEmail(dto.Email);
            var role = await GetRolesByUser(user);

            return new UserDto
            {
                Id = user.Id,
                Email = user!.Email!,
                UserName = user.UserName,
                GymId = user.GymId
            };
        }

        internal async Task<ApplicationUser> FindUserByEmail(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null) throw new ArgumentException($"{email} no está registrado.");

            return user;
        }

        internal async Task<ApplicationUser> FindUserById(Guid id)
        {
            var result = await _userManager.FindByIdAsync(id.ToString());

            if (result == null) throw new ArgumentException("Usuario no encontrado");

            return result;
        }

        internal async Task<IList<string>> GetRolesByUser(ApplicationUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            if (roles == null) roles = [];
            return roles;
        }
    }

}
