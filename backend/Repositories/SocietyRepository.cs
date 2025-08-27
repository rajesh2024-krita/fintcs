
using Microsoft.EntityFrameworkCore;
using Fintcs.Data;
using Fintcs.Data.Entities;

namespace Fintcs.Repositories;

public class SocietyRepository : ISocietyRepository
{
    private readonly FintcsDbContext _context;

    public SocietyRepository(FintcsDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Society>> GetAllAsync()
    {
        return await _context.Societies.ToListAsync();
    }

    public async Task<Society?> GetByIdAsync(Guid id)
    {
        return await _context.Societies.FindAsync(id);
    }

    public async Task<Society> CreateAsync(Society society)
    {
        _context.Societies.Add(society);
        await _context.SaveChangesAsync();
        return society;
    }

    public async Task<Society> UpdateAsync(Society society)
    {
        society.UpdatedAt = DateTime.UtcNow;
        _context.Entry(society).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return society;
    }

    public async Task DeleteAsync(Guid id)
    {
        var society = await _context.Societies.FindAsync(id);
        if (society != null)
        {
            _context.Societies.Remove(society);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _context.Societies.AnyAsync(s => s.Id == id);
    }
}
