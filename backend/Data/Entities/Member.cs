
using System.ComponentModel.DataAnnotations;

namespace Fintcs.Data.Entities;

public class Member
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [Required, MaxLength(20)]
    public string MemNo { get; set; } = string.Empty; // Auto-generated: MEM_001, MEM_002, etc.
    
    [Required, MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    
    [MaxLength(100)]
    public string? FatherHusbandName { get; set; }
    
    [MaxLength(500)]
    public string? OfficeAddress { get; set; }
    
    [MaxLength(100)]
    public string? City { get; set; }
    
    [MaxLength(20)]
    public string? PhoneOffice { get; set; }
    
    [MaxLength(100)]
    public string? Branch { get; set; }
    
    [MaxLength(20)]
    public string? PhoneRes { get; set; }
    
    [MaxLength(20)]
    public string? Mobile { get; set; }
    
    [MaxLength(100)]
    public string? Designation { get; set; }
    
    [MaxLength(500)]
    public string? ResidenceAddress { get; set; }
    
    public DateTime? DOB { get; set; }
    public DateTime? DOJSociety { get; set; }
    
    [MaxLength(100)]
    public string? Email { get; set; }
    
    public DateTime? DOJOrg { get; set; } // Date of Joining Organization
    public DateTime? DOR { get; set; } // Date of Retirement
    
    [MaxLength(100)]
    public string? Nominee { get; set; }
    
    [MaxLength(50)]
    public string? NomineeRelation { get; set; }
    
    public decimal OpeningBalanceShare { get; set; } = 0;
    public decimal Value { get; set; } = 0;
    
    [MaxLength(10)]
    public string? CrDrCd { get; set; } // Cr / Dr / CD
    
    // Bank details
    [MaxLength(100)]
    public string? BankName { get; set; }
    
    [MaxLength(100)]
    public string? PayableAt { get; set; }
    
    [MaxLength(50)]
    public string? AccountNo { get; set; }
    
    // Status
    [MaxLength(20)]
    public string Status { get; set; } = "Active"; // Active/Deactive
    
    public DateTime? StatusDate { get; set; }
    
    // Deductions (stored as JSON)
    public string? DeductionsJson { get; set; } // Share, Withdrawal, G Loan Instalment, E Loan Instalment
    
    // File paths
    [MaxLength(500)]
    public string? PhotoPath { get; set; }
    
    [MaxLength(500)]
    public string? SignaturePath { get; set; }
    
    [Required]
    public Guid SocietyId { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    
    // Navigation properties
    public virtual Society Society { get; set; } = null!;
}
