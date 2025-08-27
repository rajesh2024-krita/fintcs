
using Fintcs.Data.Entities;
using Fintcs.Repositories;

namespace Fintcs.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<AppUser>> GetAllUsersAsync()
    {
        return await _userRepository.GetAllAsync();
    }

    public async Task<AppUser?> GetUserByIdAsync(Guid id)
    {
        return await _userRepository.GetByIdAsync(id);
    }

    public async Task<AppUser> CreateUserAsync(AppUser user)
    {
        user.Id = Guid.NewGuid();
        user.CreatedAt = DateTime.UtcNow;
        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
        return await _userRepository.CreateAsync(user);
    }

    public async Task<AppUser> UpdateUserAsync(AppUser user)
    {
        return await _userRepository.UpdateAsync(user);
    }

    public async Task DeleteUserAsync(Guid id)
    {
        await _userRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<AppUser>> GetUsersBySocietyAsync(Guid societyId)
    {
        return await _userRepository.GetBySocietyIdAsync(societyId);
    }
}
