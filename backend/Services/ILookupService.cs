
using Fintcs.Data.Entities;

namespace Fintcs.Services;

public interface ILookupService
{
    Task<IEnumerable<LookupItem>> GetAllLookupsAsync();
    Task<LookupItem?> GetLookupByIdAsync(Guid id);
    Task<LookupItem> CreateLookupAsync(LookupItem lookupItem);
    Task<LookupItem> UpdateLookupAsync(LookupItem lookupItem);
    Task DeleteLookupAsync(Guid id);
    Task<IEnumerable<LookupItem>> GetLookupsByTypeAsync(string type);
}
