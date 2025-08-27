
using Microsoft.EntityFrameworkCore;
using Fintcs.Data;
using Fintcs.Data.Entities;

namespace Fintcs.Repositories;

public class DemandRepository : IDemandRepository
{
    private readonly FintcsDbContext _context;

    public DemandRepository(FintcsDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<MonthlyDemandHeader>> GetAllAsync()
    {
        return await _context.MonthlyDemandHeaders
            .Include(d => d.Society)
            .Include(d => d.DemandRows)
            .ToListAsync();
    }

    public async Task<MonthlyDemandHeader?> GetByIdAsync(Guid id)
    {
        return await _context.MonthlyDemandHeaders
            .Include(d => d.Society)
            .Include(d => d.DemandRows)
            .FirstOrDefaultAsync(d => d.Id == id);
    }

    public async Task<MonthlyDemandHeader> CreateAsync(MonthlyDemandHeader demand)
    {
        _context.MonthlyDemandHeaders.Add(demand);
        await _context.SaveChangesAsync();
        return demand;
    }

    public async Task<MonthlyDemandHeader> UpdateAsync(MonthlyDemandHeader demand)
    {
        demand.UpdatedAt = DateTime.UtcNow;
        _context.Entry(demand).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return demand;
    }

    public async Task DeleteAsync(Guid id)
    {
        var demand = await _context.MonthlyDemandHeaders.FindAsync(id);
        if (demand != null)
        {
            _context.MonthlyDemandHeaders.Remove(demand);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _context.MonthlyDemandHeaders.AnyAsync(d => d.Id == id);
    }

    public async Task<IEnumerable<MonthlyDemandHeader>> GetBySocietyIdAsync(Guid societyId)
    {
        return await _context.MonthlyDemandHeaders
            .Where(d => d.SocietyId == societyId)
            .Include(d => d.Society)
            .Include(d => d.DemandRows)
            .ToListAsync();
    }
}
