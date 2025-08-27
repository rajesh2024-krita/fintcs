
using Fintcs.Data.Entities;

namespace Fintcs.Repositories;

public interface ISocietyRepository
{
    Task<IEnumerable<Society>> GetAllAsync();
    Task<Society?> GetByIdAsync(Guid id);
    Task<Society> CreateAsync(Society society);
    Task<Society> UpdateAsync(Society society);
    Task DeleteAsync(Guid id);
    Task<bool> ExistsAsync(Guid id);
}
