
using Fintcs.Data.Entities;

namespace Fintcs.Services;

public interface ISocietyService
{
    Task<IEnumerable<Society>> GetAllSocietiesAsync();
    Task<Society?> GetSocietyByIdAsync(Guid id);
    Task<Society> CreateSocietyAsync(Society society);
    Task<Society> UpdateSocietyAsync(Society society);
    Task DeleteSocietyAsync(Guid id);
}
