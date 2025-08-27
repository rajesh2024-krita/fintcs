
using Fintcs.Data.Entities;

namespace Fintcs.Services;

public interface IUserService
{
    Task<IEnumerable<AppUser>> GetAllUsersAsync();
    Task<AppUser?> GetUserByIdAsync(Guid id);
    Task<AppUser> CreateUserAsync(AppUser user);
    Task<AppUser> UpdateUserAsync(AppUser user);
    Task DeleteUserAsync(Guid id);
    Task<IEnumerable<AppUser>> GetUsersBySocietyAsync(Guid societyId);
}
