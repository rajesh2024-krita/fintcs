
using Fintcs.Data.Entities;

namespace Fintcs.Services;

public interface IDemandService
{
    Task<IEnumerable<MonthlyDemandHeader>> GetAllDemandsAsync();
    Task<MonthlyDemandHeader?> GetDemandByIdAsync(Guid id);
    Task<MonthlyDemandHeader> CreateDemandAsync(MonthlyDemandHeader demand);
    Task<MonthlyDemandHeader> UpdateDemandAsync(MonthlyDemandHeader demand);
    Task DeleteDemandAsync(Guid id);
    Task<IEnumerable<MonthlyDemandHeader>> GetDemandsBySocietyAsync(Guid societyId);
}
