
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Fintcs.DTOs;
using Fintcs.Repositories;

namespace Fintcs.Services;

public class AuthService : IAuthService
{
    private readonly IAuthRepository _authRepository;
    private readonly IConfiguration _configuration;

    public AuthService(IAuthRepository authRepository, IConfiguration configuration)
    {
        _authRepository = authRepository;
        _configuration = configuration;
    }

    public async Task<LoginResponseDto> LoginAsync(LoginRequestDto request)
    {
        // First try SuperAdmin
        var superAdmin = await _authRepository.GetSuperAdminByUsernameAsync(request.Username);
        if (superAdmin != null && BCrypt.Net.BCrypt.Verify(request.Password, superAdmin.PasswordHash))
        {
            var token = GenerateJwtToken(superAdmin.Id.ToString(), superAdmin.Username, "SuperAdmin", superAdmin.Name);
            return new LoginResponseDto
            {
                Token = token,
                User = new UserDto
                {
                    Id = superAdmin.Id.ToString(),
                    Username = superAdmin.Username,
                    Role = "SuperAdmin",
                    Name = superAdmin.Name
                }
            };
        }

        // Try AppUser
        var appUser = await _authRepository.GetUserByUsernameAsync(request.Username);
        if (appUser != null && BCrypt.Net.BCrypt.Verify(request.Password, appUser.PasswordHash))
        {
            var token = GenerateJwtToken(appUser.Id.ToString(), appUser.Username, appUser.Role, appUser.Name, appUser.SocietyId?.ToString());
            return new LoginResponseDto
            {
                Token = token,
                User = new UserDto
                {
                    Id = appUser.Id.ToString(),
                    Username = appUser.Username,
                    Role = appUser.Role,
                    Name = appUser.Name,
                    SocietyId = appUser.SocietyId?.ToString()
                }
            };
        }

        throw new UnauthorizedAccessException("Invalid username or password");
    }

    public async Task SeedDefaultDataAsync()
    {
        await _authRepository.SeedDefaultDataAsync();
    }

    private string GenerateJwtToken(string userId, string username, string role, string name, string? societyId = null)
    {
        var jwtSettings = _configuration.GetSection("JwtSettings");
        var secretKey = jwtSettings.GetValue<string>("SecretKey") ?? "your-super-secret-key-that-is-at-least-32-characters-long";
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, userId),
            new(ClaimTypes.Name, username),
            new(ClaimTypes.Role, role),
            new("name", name)
        };

        if (!string.IsNullOrEmpty(societyId))
        {
            claims.Add(new Claim("societyId", societyId));
        }

        var token = new JwtSecurityToken(
            issuer: jwtSettings.GetValue<string>("Issuer") ?? "FintcsAPI",
            audience: jwtSettings.GetValue<string>("Audience") ?? "FintcsClient",
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(jwtSettings.GetValue<int>("ExpiryMinutes")),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
