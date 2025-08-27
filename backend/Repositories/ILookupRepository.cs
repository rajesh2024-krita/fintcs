
using Fintcs.Data.Entities;

namespace Fintcs.Repositories;

public interface ILookupRepository
{
    Task<IEnumerable<LookupItem>> GetAllAsync();
    Task<LookupItem?> GetByIdAsync(Guid id);
    Task<LookupItem> CreateAsync(LookupItem lookupItem);
    Task<LookupItem> UpdateAsync(LookupItem lookupItem);
    Task DeleteAsync(Guid id);
    Task<bool> ExistsAsync(Guid id);
    Task<IEnumerable<LookupItem>> GetByTypeAsync(string type);
}
