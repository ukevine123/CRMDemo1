using Application.Interfaces;
using Microsoft.AspNetCore.Identity;
using Application.DTO;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Identity
{
    public class IdentityRepos : IIdentity
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;


        public IdentityRepos(ApplicationDbContext context, UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole<int>> roleManager)
        {
            _dbContext = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;

        }

        public async Task<bool> LoginAsync(LoginDTO dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null)
            {
                return false;
            }

            var result = await _signInManager.PasswordSignInAsync(
                user.UserName ?? dto.Email,
                dto.Password,
                dto.RememberMe,
                lockoutOnFailure: true
            );

            return result.Succeeded;
        }
        public async Task RegisterUser(RegisterUserDTO dto)
        {
            var newUser = new User()
            {
                FullName = dto.FullName,
                Phone = dto.Phone,
                Email = dto.Email,
                UserName = dto.UserName,
                PhoneNumber = dto.Phone,
                UserPassword = dto.UserPassword,
                EmailConfirmed = true,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };
            var result = await _userManager.CreateAsync(newUser, dto.UserPassword);
            
        }

        public async  Task<List<UserDetailDTO>> GetAllUsers()
        {
            var users = await _userManager.Users
            .OrderBy(u => u.Id)
            .ThenBy(u => u.FullName)
            .ToListAsync();

            return users.Select(u => new UserDetailDTO
            {
                Id = u.Id,
                FullName = u.FullName,
                Phone = u.Phone,
                Email = u.Email,
                UserName = u.UserName,
                EmailConfirmed = u.EmailConfirmed,
                CreatedAt = u.CreatedAt,
                UpdatedAt = u.UpdatedAt
            }).ToList();
        }
        public async Task<UserDetailDTO> GetUserById(int id)
        {
            var user = await _userManager.Users
            .FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
                return null;

            return new UserDetailDTO
            {
                Id = user.Id,
                FullName = user.FullName,
                Phone = user.Phone,
                UserName = user.UserName,
                EmailConfirmed = user.EmailConfirmed,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt
            };
        }
        public async Task UpdateUser(int id, UserUpdateDTO dto)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                throw new InvalidOperationException($"User with ID {id} not found.");
            }

            user.FullName = dto.FullName;
            user.Phone = dto.Phone;
            user.UserName = dto.UserName;
            user.UpdatedAt = DateTime.Now;

            var updateResult = await _userManager.UpdateAsync(user);

            if (!updateResult.Succeeded)
            {
                var errors = string.Join(", ", updateResult.Errors.Select(e => e.Description));
                throw new InvalidOperationException($"Failed to update user: {errors}");
            }
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}