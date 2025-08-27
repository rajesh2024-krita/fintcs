
using Microsoft.EntityFrameworkCore;
using Fintcs.Data.Entities;

namespace Fintcs.Data;

public class FintcsDbContext : DbContext
{
    public FintcsDbContext(DbContextOptions<FintcsDbContext> options) : base(options) { }

    // DbSets for all entities
    public DbSet<SuperAdmin> SuperAdmins { get; set; }
    public DbSet<LookupItem> LookupItems { get; set; }
    public DbSet<Society> Societies { get; set; }
    public DbSet<AppUser> AppUsers { get; set; }
    public DbSet<Member> Members { get; set; }
    public DbSet<Loan> Loans { get; set; }
    public DbSet<MonthlyDemandHeader> MonthlyDemandHeaders { get; set; }
    public DbSet<MonthlyDemandRow> MonthlyDemandRows { get; set; }
    public DbSet<Voucher> Vouchers { get; set; }
    public DbSet<VoucherLine> VoucherLines { get; set; }
    public DbSet<PendingEdit> PendingEdits { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure decimal precision
        modelBuilder.Entity<Society>()
            .Property(s => s.InterestDividend)
            .HasPrecision(5, 2);
        modelBuilder.Entity<Society>()
            .Property(s => s.InterestOD)
            .HasPrecision(5, 2);
        modelBuilder.Entity<Society>()
            .Property(s => s.InterestCD)
            .HasPrecision(5, 2);
        modelBuilder.Entity<Society>()
            .Property(s => s.InterestLoan)
            .HasPrecision(5, 2);
        modelBuilder.Entity<Society>()
            .Property(s => s.InterestEmergencyLoan)
            .HasPrecision(5, 2);
        modelBuilder.Entity<Society>()
            .Property(s => s.InterestLAS)
            .HasPrecision(5, 2);
        modelBuilder.Entity<Society>()
            .Property(s => s.LimitShare)
            .HasPrecision(18, 2);
        modelBuilder.Entity<Society>()
            .Property(s => s.LimitLoan)
            .HasPrecision(18, 2);
        modelBuilder.Entity<Society>()
            .Property(s => s.LimitEmergencyLoan)
            .HasPrecision(18, 2);
        modelBuilder.Entity<Society>()
            .Property(s => s.ChBounceChargeAmount)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Member>()
            .Property(m => m.OpeningBalanceShare)
            .HasPrecision(18, 2);
        modelBuilder.Entity<Member>()
            .Property(m => m.Value)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Loan>()
            .Property(l => l.LoanAmount)
            .HasPrecision(18, 2);
        modelBuilder.Entity<Loan>()
            .Property(l => l.PrevLoan)
            .HasPrecision(18, 2);
        modelBuilder.Entity<Loan>()
            .Property(l => l.InstallmentAmount)
            .HasPrecision(18, 2);
        modelBuilder.Entity<Loan>()
            .Property(l => l.Share)
            .HasPrecision(18, 2);
        modelBuilder.Entity<Loan>()
            .Property(l => l.CD)
            .HasPrecision(18, 2);
        modelBuilder.Entity<Loan>()
            .Property(l => l.LastSalary)
            .HasPrecision(18, 2);
        modelBuilder.Entity<Loan>()
            .Property(l => l.MWF)
            .HasPrecision(18, 2);
        modelBuilder.Entity<Loan>()
            .Property(l => l.PayAmount)
            .HasPrecision(18, 2);

        modelBuilder.Entity<MonthlyDemandHeader>()
            .Property(mdh => mdh.TotalAmount)
            .HasPrecision(18, 2);

        modelBuilder.Entity<MonthlyDemandRow>()
            .Property(mdr => mdr.LoanAmt)
            .HasPrecision(18, 2);
        modelBuilder.Entity<MonthlyDemandRow>()
            .Property(mdr => mdr.CD)
            .HasPrecision(18, 2);
        modelBuilder.Entity<MonthlyDemandRow>()
            .Property(mdr => mdr.Loan)
            .HasPrecision(18, 2);
        modelBuilder.Entity<MonthlyDemandRow>()
            .Property(mdr => mdr.Interest)
            .HasPrecision(18, 2);
        modelBuilder.Entity<MonthlyDemandRow>()
            .Property(mdr => mdr.ELoan)
            .HasPrecision(18, 2);
        modelBuilder.Entity<MonthlyDemandRow>()
            .Property(mdr => mdr.InterestExtra)
            .HasPrecision(18, 2);
        modelBuilder.Entity<MonthlyDemandRow>()
            .Property(mdr => mdr.Net)
            .HasPrecision(18, 2);
        modelBuilder.Entity<MonthlyDemandRow>()
            .Property(mdr => mdr.IntDue)
            .HasPrecision(18, 2);
        modelBuilder.Entity<MonthlyDemandRow>()
            .Property(mdr => mdr.PInt)
            .HasPrecision(18, 2);
        modelBuilder.Entity<MonthlyDemandRow>()
            .Property(mdr => mdr.PDed)
            .HasPrecision(18, 2);
        modelBuilder.Entity<MonthlyDemandRow>()
            .Property(mdr => mdr.LAS)
            .HasPrecision(18, 2);
        modelBuilder.Entity<MonthlyDemandRow>()
            .Property(mdr => mdr.Int)
            .HasPrecision(18, 2);
        modelBuilder.Entity<MonthlyDemandRow>()
            .Property(mdr => mdr.LASIntDue)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Voucher>()
            .Property(v => v.TotalDebit)
            .HasPrecision(18, 2);
        modelBuilder.Entity<Voucher>()
            .Property(v => v.TotalCredit)
            .HasPrecision(18, 2);

        modelBuilder.Entity<VoucherLine>()
            .Property(vl => vl.Debit)
            .HasPrecision(18, 2);
        modelBuilder.Entity<VoucherLine>()
            .Property(vl => vl.Credit)
            .HasPrecision(18, 2);
        modelBuilder.Entity<VoucherLine>()
            .Property(vl => vl.Ibldbc)
            .HasPrecision(18, 2);

        // Configure relationships
        modelBuilder.Entity<AppUser>()
            .HasOne(u => u.Society)
            .WithMany(s => s.Users)
            .HasForeignKey(u => u.SocietyId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Member>()
            .HasOne(m => m.Society)
            .WithMany(s => s.Members)
            .HasForeignKey(m => m.SocietyId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Loan>()
            .HasOne(l => l.Society)
            .WithMany(s => s.Loans)
            .HasForeignKey(l => l.SocietyId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Loan>()
            .HasOne(l => l.LoanType)
            .WithMany()
            .HasForeignKey(l => l.LoanTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Loan>()
            .HasOne(l => l.Bank)
            .WithMany()
            .HasForeignKey(l => l.BankId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<MonthlyDemandHeader>()
            .HasOne(h => h.Society)
            .WithMany(s => s.MonthlyDemands)
            .HasForeignKey(h => h.SocietyId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<MonthlyDemandHeader>()
            .HasOne(h => h.Month)
            .WithMany()
            .HasForeignKey(h => h.MonthId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<MonthlyDemandRow>()
            .HasOne(r => r.Header)
            .WithMany(h => h.Rows)
            .HasForeignKey(r => r.HeaderId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Voucher>()
            .HasOne(v => v.Society)
            .WithMany(s => s.Vouchers)
            .HasForeignKey(v => v.SocietyId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Voucher>()
            .HasOne(v => v.VoucherType)
            .WithMany()
            .HasForeignKey(v => v.VoucherTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<VoucherLine>()
            .HasOne(l => l.Voucher)
            .WithMany(v => v.Lines)
            .HasForeignKey(l => l.VoucherId)
            .OnDelete(DeleteBehavior.Cascade);

        // Configure indexes
        modelBuilder.Entity<SuperAdmin>()
            .HasIndex(s => s.Username)
            .IsUnique();

        modelBuilder.Entity<AppUser>()
            .HasIndex(u => u.Username)
            .IsUnique();

        modelBuilder.Entity<Member>()
            .HasIndex(m => new { m.MemNo, m.SocietyId })
            .IsUnique();

        modelBuilder.Entity<Loan>()
            .HasIndex(l => new { l.LoanNo, l.SocietyId })
            .IsUnique();

        modelBuilder.Entity<Voucher>()
            .HasIndex(v => new { v.VoucherNo, v.SocietyId })
            .IsUnique();

        modelBuilder.Entity<MonthlyDemandHeader>()
            .HasIndex(mdh => new { mdh.MonthId, mdh.YearValue, mdh.SocietyId })
            .IsUnique();

        modelBuilder.Entity<LookupItem>()
            .HasIndex(l => new { l.Category, l.Code });

        // Configure computed column for NetLoan
        modelBuilder.Entity<Loan>()
            .Property(l => l.NetLoan)
            .HasComputedColumnSql("[LoanAmount] - [PrevLoan]");
    }
}
