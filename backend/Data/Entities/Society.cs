
using System.ComponentModel.DataAnnotations;

namespace Fintcs.Data.Entities;

public class Society
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [Required, MaxLength(200)]
    public string Name { get; set; } = string.Empty;
    
    [MaxLength(500)]
    public string? Address { get; set; }
    
    [MaxLength(100)]
    public string? City { get; set; }
    
    [MaxLength(20)]
    public string? Phone { get; set; }
    
    [MaxLength(20)]
    public string? Fax { get; set; }
    
    [MaxLength(100)]
    public string? Email { get; set; }
    
    [MaxLength(200)]
    public string? Website { get; set; }
    
    [MaxLength(50)]
    public string? RegistrationNo { get; set; }
    
    // Interest rates
    public decimal InterestDividend { get; set; } = 0;
    public decimal InterestOD { get; set; } = 0;
    public decimal InterestCD { get; set; } = 0;
    public decimal InterestLoan { get; set; } = 0;
    public decimal InterestEmergencyLoan { get; set; } = 0;
    public decimal InterestLAS { get; set; } = 0;
    
    // Limits
    public decimal LimitShare { get; set; } = 0;
    public decimal LimitLoan { get; set; } = 0;
    public decimal LimitEmergencyLoan { get; set; } = 0;
    
    // Ch bounce charge
    public decimal ChBounceChargeAmount { get; set; } = 0;
    
    [MaxLength(50)]
    public string? ChBounceChargeMode { get; set; } // Excess Provision, Cash, HDFC Bank, Inverter
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    
    // Navigation properties
    public virtual ICollection<AppUser> Users { get; set; } = new List<AppUser>();
    public virtual ICollection<Member> Members { get; set; } = new List<Member>();
    public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();
    public virtual ICollection<MonthlyDemandHeader> MonthlyDemands { get; set; } = new List<MonthlyDemandHeader>();
    public virtual ICollection<Voucher> Vouchers { get; set; } = new List<Voucher>();
}
