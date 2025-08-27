
using Microsoft.EntityFrameworkCore;
using Fintcs.Data;
using Fintcs.Data.Entities;

namespace Fintcs.Repositories;

public class VoucherRepository : IVoucherRepository
{
    private readonly FintcsDbContext _context;

    public VoucherRepository(FintcsDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Voucher>> GetAllAsync()
    {
        return await _context.Vouchers
            .Include(v => v.Society)
            .Include(v => v.VoucherLines)
            .ToListAsync();
    }

    public async Task<Voucher?> GetByIdAsync(Guid id)
    {
        return await _context.Vouchers
            .Include(v => v.Society)
            .Include(v => v.VoucherLines)
            .FirstOrDefaultAsync(v => v.Id == id);
    }

    public async Task<Voucher> CreateAsync(Voucher voucher)
    {
        _context.Vouchers.Add(voucher);
        await _context.SaveChangesAsync();
        return voucher;
    }

    public async Task<Voucher> UpdateAsync(Voucher voucher)
    {
        voucher.UpdatedAt = DateTime.UtcNow;
        _context.Entry(voucher).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return voucher;
    }

    public async Task DeleteAsync(Guid id)
    {
        var voucher = await _context.Vouchers.FindAsync(id);
        if (voucher != null)
        {
            _context.Vouchers.Remove(voucher);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _context.Vouchers.AnyAsync(v => v.Id == id);
    }

    public async Task<IEnumerable<Voucher>> GetBySocietyIdAsync(Guid societyId)
    {
        return await _context.Vouchers
            .Where(v => v.SocietyId == societyId)
            .Include(v => v.Society)
            .Include(v => v.VoucherLines)
            .ToListAsync();
    }
}
