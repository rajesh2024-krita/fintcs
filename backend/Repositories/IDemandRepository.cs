
using Fintcs.Data.Entities;

namespace Fintcs.Repositories;

public interface IDemandRepository
{
    Task<IEnumerable<MonthlyDemandHeader>> GetAllAsync();
    Task<MonthlyDemandHeader?> GetByIdAsync(Guid id);
    Task<MonthlyDemandHeader> CreateAsync(MonthlyDemandHeader demand);
    Task<MonthlyDemandHeader> UpdateAsync(MonthlyDemandHeader demand);
    Task DeleteAsync(Guid id);
    Task<bool> ExistsAsync(Guid id);
    Task<IEnumerable<MonthlyDemandHeader>> GetBySocietyIdAsync(Guid societyId);
}
