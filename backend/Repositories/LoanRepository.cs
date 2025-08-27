
using Microsoft.EntityFrameworkCore;
using Fintcs.Data;
using Fintcs.Data.Entities;

namespace Fintcs.Repositories;

public class LoanRepository : ILoanRepository
{
    private readonly FintcsDbContext _context;

    public LoanRepository(FintcsDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Loan>> GetAllAsync()
    {
        return await _context.Loans
            .Include(l => l.Society)
            .Include(l => l.Member)
            .ToListAsync();
    }

    public async Task<Loan?> GetByIdAsync(Guid id)
    {
        return await _context.Loans
            .Include(l => l.Society)
            .Include(l => l.Member)
            .FirstOrDefaultAsync(l => l.Id == id);
    }

    public async Task<Loan> CreateAsync(Loan loan)
    {
        _context.Loans.Add(loan);
        await _context.SaveChangesAsync();
        return loan;
    }

    public async Task<Loan> UpdateAsync(Loan loan)
    {
        loan.UpdatedAt = DateTime.UtcNow;
        _context.Entry(loan).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return loan;
    }

    public async Task DeleteAsync(Guid id)
    {
        var loan = await _context.Loans.FindAsync(id);
        if (loan != null)
        {
            _context.Loans.Remove(loan);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _context.Loans.AnyAsync(l => l.Id == id);
    }

    public async Task<IEnumerable<Loan>> GetBySocietyIdAsync(Guid societyId)
    {
        return await _context.Loans
            .Where(l => l.SocietyId == societyId)
            .Include(l => l.Society)
            .Include(l => l.Member)
            .ToListAsync();
    }

    public async Task<IEnumerable<Loan>> GetByMemberIdAsync(Guid memberId)
    {
        return await _context.Loans
            .Where(l => l.MemberId == memberId)
            .Include(l => l.Society)
            .Include(l => l.Member)
            .ToListAsync();
    }
}
