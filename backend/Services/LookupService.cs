
using Fintcs.Data.Entities;
using Fintcs.Repositories;

namespace Fintcs.Services;

public class LookupService : ILookupService
{
    private readonly ILookupRepository _lookupRepository;

    public LookupService(ILookupRepository lookupRepository)
    {
        _lookupRepository = lookupRepository;
    }

    public async Task<IEnumerable<LookupItem>> GetAllLookupsAsync()
    {
        return await _lookupRepository.GetAllAsync();
    }

    public async Task<LookupItem?> GetLookupByIdAsync(Guid id)
    {
        return await _lookupRepository.GetByIdAsync(id);
    }

    public async Task<LookupItem> CreateLookupAsync(LookupItem lookupItem)
    {
        lookupItem.Id = Guid.NewGuid();
        lookupItem.CreatedAt = DateTime.UtcNow;
        return await _lookupRepository.CreateAsync(lookupItem);
    }

    public async Task<LookupItem> UpdateLookupAsync(LookupItem lookupItem)
    {
        return await _lookupRepository.UpdateAsync(lookupItem);
    }

    public async Task DeleteLookupAsync(Guid id)
    {
        await _lookupRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<LookupItem>> GetLookupsByTypeAsync(string type)
    {
        return await _lookupRepository.GetByTypeAsync(type);
    }
}
