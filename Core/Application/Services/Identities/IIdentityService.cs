using Application.DTO;
using Domain.Entities;

namespace Application.Services.Identities
{
    public interface IIdentityService
    {
        Task<bool> LoginAsync(LoginDTO dto);
        Task RegisterUser(RegisterUserDTO dto);
        Task<List<UserDetailDTO>> GetAllUsers();
        Task<UserDetailDTO> GetUserById(int id);
        Task UpdateUser(int id, UserUpdateDTO dto);

    }
}