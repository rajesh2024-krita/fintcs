
using Fintcs.Data.Entities;

namespace Fintcs.Repositories;

public interface IUserRepository
{
    Task<IEnumerable<AppUser>> GetAllAsync();
    Task<AppUser?> GetByIdAsync(Guid id);
    Task<AppUser> CreateAsync(AppUser user);
    Task<AppUser> UpdateAsync(AppUser user);
    Task DeleteAsync(Guid id);
    Task<bool> ExistsAsync(Guid id);
    Task<IEnumerable<AppUser>> GetBySocietyIdAsync(Guid societyId);
}
