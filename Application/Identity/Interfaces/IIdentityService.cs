using Application.Identity.Dtos;
using Application.Shared.Dtos;

namespace Application.Identity.Interfaces
{
    public interface IIdentityService
    {
        Task<AuthDto> RegisterAsync(RegisterDto model);
        Task<AuthDto> GetTokenAsync(LoginDto model);
        Task<bool> AddRoleAsync(AddRoleToUserDto model);
        Task<string> RemoveRoleAsync(AddRoleToUserDto model);
        Task<PagedResponse<UserDto>> GetUsersAsync(int pageNumber = 1, int pageSize = 20);
    }
}
