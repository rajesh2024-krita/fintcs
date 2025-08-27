
using Fintcs.Data.Entities;
using Fintcs.Repositories;

namespace Fintcs.Services;

public class DemandService : IDemandService
{
    private readonly IDemandRepository _demandRepository;

    public DemandService(IDemandRepository demandRepository)
    {
        _demandRepository = demandRepository;
    }

    public async Task<IEnumerable<MonthlyDemandHeader>> GetAllDemandsAsync()
    {
        return await _demandRepository.GetAllAsync();
    }

    public async Task<MonthlyDemandHeader?> GetDemandByIdAsync(Guid id)
    {
        return await _demandRepository.GetByIdAsync(id);
    }

    public async Task<MonthlyDemandHeader> CreateDemandAsync(MonthlyDemandHeader demand)
    {
        demand.Id = Guid.NewGuid();
        demand.CreatedAt = DateTime.UtcNow;
        return await _demandRepository.CreateAsync(demand);
    }

    public async Task<MonthlyDemandHeader> UpdateDemandAsync(MonthlyDemandHeader demand)
    {
        return await _demandRepository.UpdateAsync(demand);
    }

    public async Task DeleteDemandAsync(Guid id)
    {
        await _demandRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<MonthlyDemandHeader>> GetDemandsBySocietyAsync(Guid societyId)
    {
        return await _demandRepository.GetBySocietyIdAsync(societyId);
    }
}
