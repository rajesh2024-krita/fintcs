
using Fintcs.Data.Entities;

namespace Fintcs.Repositories;

public interface IAuthRepository
{
    Task<SuperAdmin?> GetSuperAdminByUsernameAsync(string username);
    Task<AppUser?> GetUserByUsernameAsync(string username);
    Task<SuperAdmin> CreateSuperAdminAsync(SuperAdmin admin);
    Task SeedDefaultDataAsync();
}
