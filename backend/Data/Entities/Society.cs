
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fintcs.Data.Entities;

public class Society
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [Required, MaxLength(200)]
    public string Name { get; set; } = string.Empty;
    
    [MaxLength(500)]
    public string Address { get; set; } = string.Empty;
    
    [MaxLength(100)]
    public string City { get; set; } = string.Empty;
    
    [MaxLength(20)]
    public string Phone { get; set; } = string.Empty;
    
    [MaxLength(20)]
    public string Fax { get; set; } = string.Empty;
    
    [MaxLength(100)]
    public string Email { get; set; } = string.Empty;
    
    [MaxLength(200)]
    public string Website { get; set; } = string.Empty;
    
    [MaxLength(50)]
    public string RegistrationNo { get; set; } = string.Empty;
    
    // Interest rates
    [Column(TypeName = "decimal(5,2)")]
    public decimal InterestDividend { get; set; }
    
    [Column(TypeName = "decimal(5,2)")]
    public decimal InterestOD { get; set; }
    
    [Column(TypeName = "decimal(5,2)")]
    public decimal InterestCD { get; set; }
    
    [Column(TypeName = "decimal(5,2)")]
    public decimal InterestLoan { get; set; }
    
    [Column(TypeName = "decimal(5,2)")]
    public decimal InterestEmergencyLoan { get; set; }
    
    [Column(TypeName = "decimal(5,2)")]
    public decimal InterestLAS { get; set; }
    
    // Limits
    [Column(TypeName = "decimal(18,2)")]
    public decimal LimitShare { get; set; }
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal LimitLoan { get; set; }
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal LimitEmergencyLoan { get; set; }
    
    // Bounce charge
    [Column(TypeName = "decimal(10,2)")]
    public decimal ChBounceChargeAmount { get; set; }
    
    [MaxLength(50)]
    public string ChBounceChargeMode { get; set; } = string.Empty;
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    
    // Navigation properties
    public virtual ICollection<AppUser> Users { get; set; } = new List<AppUser>();
    public virtual ICollection<Member> Members { get; set; } = new List<Member>();
    public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();
    public virtual ICollection<Voucher> Vouchers { get; set; } = new List<Voucher>();
    public virtual ICollection<MonthlyDemandHeader> MonthlyDemands { get; set; } = new List<MonthlyDemandHeader>();
}
