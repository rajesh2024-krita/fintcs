
using Microsoft.EntityFrameworkCore;
using Fintcs.Data;
using Fintcs.Data.Entities;

namespace Fintcs.Repositories;

public class AuthRepository : IAuthRepository
{
    private readonly FintcsDbContext _context;

    public AuthRepository(FintcsDbContext context)
    {
        _context = context;
    }

    public async Task<SuperAdmin?> GetSuperAdminByUsernameAsync(string username)
    {
        return await _context.SuperAdmins
            .FirstOrDefaultAsync(s => s.Username == username);
    }

    public async Task<AppUser?> GetUserByUsernameAsync(string username)
    {
        return await _context.AppUsers
            .Include(u => u.Society)
            .FirstOrDefaultAsync(u => u.Username == username);
    }

    public async Task<SuperAdmin> CreateSuperAdminAsync(SuperAdmin admin)
    {
        _context.SuperAdmins.Add(admin);
        await _context.SaveChangesAsync();
        return admin;
    }

    public async Task SeedDefaultDataAsync()
    {
        // Check if data already exists
        if (await _context.SuperAdmins.AnyAsync() || await _context.LookupItems.AnyAsync())
            return;

        // Seed Super Admin
        var superAdmin = new SuperAdmin
        {
            Username = "admin",
            PasswordHash = BCrypt.Net.BCrypt.HashPassword("admin"),
            Name = "System Administrator"
        };
        _context.SuperAdmins.Add(superAdmin);

        // Seed Lookup Items
        var lookupItems = new List<LookupItem>
        {
            // Loan Types
            new() { Category = "LoanType", Name = "General", Code = "GEN", SortOrder = 1 },
            new() { Category = "LoanType", Name = "Personal", Code = "PER", SortOrder = 2 },
            new() { Category = "LoanType", Name = "Housing", Code = "HOU", SortOrder = 3 },
            new() { Category = "LoanType", Name = "Vehicle", Code = "VEH", SortOrder = 4 },
            new() { Category = "LoanType", Name = "Education", Code = "EDU", SortOrder = 5 },
            new() { Category = "LoanType", Name = "Others", Code = "OTH", SortOrder = 6 },

            // Banks
            new() { Category = "Bank", Name = "HDFC Bank", Code = "HDFC", SortOrder = 1 },
            new() { Category = "Bank", Name = "ICICI Bank", Code = "ICICI", SortOrder = 2 },
            new() { Category = "Bank", Name = "State Bank of India", Code = "SBI", SortOrder = 3 },
            new() { Category = "Bank", Name = "Bank of Baroda", Code = "BOB", SortOrder = 4 },
            new() { Category = "Bank", Name = "Punjab National Bank", Code = "PNB", SortOrder = 5 },

            // Voucher Types
            new() { Category = "VoucherType", Name = "Payment", Code = "PAY", SortOrder = 1 },
            new() { Category = "VoucherType", Name = "Receipt", Code = "REC", SortOrder = 2 },
            new() { Category = "VoucherType", Name = "Journal", Code = "JOU", SortOrder = 3 },
            new() { Category = "VoucherType", Name = "Contra", Code = "CON", SortOrder = 4 },
            new() { Category = "VoucherType", Name = "Adjustment", Code = "ADJ", SortOrder = 5 },
            new() { Category = "VoucherType", Name = "Others", Code = "OTH", SortOrder = 6 },

            // Months
            new() { Category = "Month", Name = "January", Code = "JAN", Value = "1", SortOrder = 1 },
            new() { Category = "Month", Name = "February", Code = "FEB", Value = "2", SortOrder = 2 },
            new() { Category = "Month", Name = "March", Code = "MAR", Value = "3", SortOrder = 3 },
            new() { Category = "Month", Name = "April", Code = "APR", Value = "4", SortOrder = 4 },
            new() { Category = "Month", Name = "May", Code = "MAY", Value = "5", SortOrder = 5 },
            new() { Category = "Month", Name = "June", Code = "JUN", Value = "6", SortOrder = 6 },
            new() { Category = "Month", Name = "July", Code = "JUL", Value = "7", SortOrder = 7 },
            new() { Category = "Month", Name = "August", Code = "AUG", Value = "8", SortOrder = 8 },
            new() { Category = "Month", Name = "September", Code = "SEP", Value = "9", SortOrder = 9 },
            new() { Category = "Month", Name = "October", Code = "OCT", Value = "10", SortOrder = 10 },
            new() { Category = "Month", Name = "November", Code = "NOV", Value = "11", SortOrder = 11 },
            new() { Category = "Month", Name = "December", Code = "DEC", Value = "12", SortOrder = 12 }
        };

        // Add Years (2000-2050)
        for (int year = 2000; year <= 2050; year++)
        {
            lookupItems.Add(new LookupItem
            {
                Category = "Year",
                Name = year.ToString(),
                Code = year.ToString(),
                Value = year.ToString(),
                SortOrder = year - 2000 + 1
            });
        }

        _context.LookupItems.AddRange(lookupItems);
        await _context.SaveChangesAsync();
    }
}
