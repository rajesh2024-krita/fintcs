
using Microsoft.EntityFrameworkCore;
using Fintcs.Data;
using Fintcs.Data.Entities;

namespace Fintcs.Repositories;

public class LookupRepository : ILookupRepository
{
    private readonly FintcsDbContext _context;

    public LookupRepository(FintcsDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<LookupItem>> GetAllAsync()
    {
        return await _context.LookupItems.ToListAsync();
    }

    public async Task<LookupItem?> GetByIdAsync(Guid id)
    {
        return await _context.LookupItems.FindAsync(id);
    }

    public async Task<LookupItem> CreateAsync(LookupItem lookupItem)
    {
        _context.LookupItems.Add(lookupItem);
        await _context.SaveChangesAsync();
        return lookupItem;
    }

    public async Task<LookupItem> UpdateAsync(LookupItem lookupItem)
    {
        lookupItem.UpdatedAt = DateTime.UtcNow;
        _context.Entry(lookupItem).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return lookupItem;
    }

    public async Task DeleteAsync(Guid id)
    {
        var lookupItem = await _context.LookupItems.FindAsync(id);
        if (lookupItem != null)
        {
            _context.LookupItems.Remove(lookupItem);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _context.LookupItems.AnyAsync(l => l.Id == id);
    }

    public async Task<IEnumerable<LookupItem>> GetByTypeAsync(string type)
    {
        return await _context.LookupItems
            .Where(l => l.Type == type && l.IsActive)
            .OrderBy(l => l.SortOrder)
            .ToListAsync();
    }
}
