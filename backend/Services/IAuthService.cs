
using Fintcs.DTOs;

namespace Fintcs.Services;

public interface IAuthService
{
    Task<LoginResponseDto> LoginAsync(LoginRequestDto request);
    Task SeedDefaultDataAsync();
}
