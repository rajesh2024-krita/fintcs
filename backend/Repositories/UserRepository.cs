
using Microsoft.EntityFrameworkCore;
using Fintcs.Data;
using Fintcs.Data.Entities;

namespace Fintcs.Repositories;

public class UserRepository : IUserRepository
{
    private readonly FintcsDbContext _context;

    public UserRepository(FintcsDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<AppUser>> GetAllAsync()
    {
        return await _context.AppUsers.Include(u => u.Society).ToListAsync();
    }

    public async Task<AppUser?> GetByIdAsync(Guid id)
    {
        return await _context.AppUsers.Include(u => u.Society).FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<AppUser> CreateAsync(AppUser user)
    {
        _context.AppUsers.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<AppUser> UpdateAsync(AppUser user)
    {
        user.UpdatedAt = DateTime.UtcNow;
        _context.Entry(user).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task DeleteAsync(Guid id)
    {
        var user = await _context.AppUsers.FindAsync(id);
        if (user != null)
        {
            _context.AppUsers.Remove(user);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _context.AppUsers.AnyAsync(u => u.Id == id);
    }

    public async Task<IEnumerable<AppUser>> GetBySocietyIdAsync(Guid societyId)
    {
        return await _context.AppUsers
            .Where(u => u.SocietyId == societyId)
            .Include(u => u.Society)
            .ToListAsync();
    }
}
