
using Microsoft.EntityFrameworkCore;
using Fintcs.Data;
using Fintcs.Data.Entities;

namespace Fintcs.Repositories;

public class MemberRepository : IMemberRepository
{
    private readonly FintcsDbContext _context;

    public MemberRepository(FintcsDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Member>> GetAllAsync()
    {
        return await _context.Members.Include(m => m.Society).ToListAsync();
    }

    public async Task<Member?> GetByIdAsync(Guid id)
    {
        return await _context.Members.Include(m => m.Society).FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<Member> CreateAsync(Member member)
    {
        _context.Members.Add(member);
        await _context.SaveChangesAsync();
        return member;
    }

    public async Task<Member> UpdateAsync(Member member)
    {
        member.UpdatedAt = DateTime.UtcNow;
        _context.Entry(member).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return member;
    }

    public async Task DeleteAsync(Guid id)
    {
        var member = await _context.Members.FindAsync(id);
        if (member != null)
        {
            _context.Members.Remove(member);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _context.Members.AnyAsync(m => m.Id == id);
    }

    public async Task<IEnumerable<Member>> GetBySocietyIdAsync(Guid societyId)
    {
        return await _context.Members
            .Where(m => m.SocietyId == societyId)
            .Include(m => m.Society)
            .ToListAsync();
    }

    public async Task<Member?> GetByMemberCodeAsync(string memberCode)
    {
        return await _context.Members
            .Include(m => m.Society)
            .FirstOrDefaultAsync(m => m.MemberCode == memberCode);
    }
}
