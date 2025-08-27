
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fintcs.Data.Entities;

public class Member
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [Required, MaxLength(20)]
    public string MemNo { get; set; } = string.Empty; // Auto-generated: MEM_001, MEM_002, etc.
    
    [MaxLength(20)]
    public string MemberCode { get; set; } = string.Empty;
    
    [Required, MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    
    [MaxLength(100)]
    public string FatherHusbandName { get; set; } = string.Empty;
    
    [MaxLength(500)]
    public string OfficeAddress { get; set; } = string.Empty;
    
    [MaxLength(100)]
    public string City { get; set; } = string.Empty;
    
    [MaxLength(20)]
    public string PhoneOffice { get; set; } = string.Empty;
    
    [MaxLength(100)]
    public string Branch { get; set; } = string.Empty;
    
    [MaxLength(20)]
    public string PhoneRes { get; set; } = string.Empty;
    
    [MaxLength(20)]
    public string Mobile { get; set; } = string.Empty;
    
    [MaxLength(100)]
    public string Designation { get; set; } = string.Empty;
    
    [MaxLength(500)]
    public string ResidenceAddress { get; set; } = string.Empty;
    
    public DateTime? DOB { get; set; }
    public DateTime? DOJSociety { get; set; } // Date of Joining Society
    
    [MaxLength(100)]
    public string Email { get; set; } = string.Empty;
    
    public DateTime? DOJOrg { get; set; } // Date of Joining Organization
    public DateTime? DOR { get; set; } // Date of Retirement
    
    [MaxLength(100)]
    public string Nominee { get; set; } = string.Empty;
    
    [MaxLength(50)]
    public string NomineeRelation { get; set; } = string.Empty;
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal OpeningBalanceShare { get; set; }
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal Value { get; set; }
    
    [MaxLength(10)]
    public string CrDrCD { get; set; } = string.Empty; // Cr/Dr/CD
    
    // Bank details
    [MaxLength(100)]
    public string BankName { get; set; } = string.Empty;
    
    [MaxLength(100)]
    public string PayableAt { get; set; } = string.Empty;
    
    [MaxLength(50)]
    public string AccountNo { get; set; } = string.Empty;
    
    // Status
    [MaxLength(20)]
    public string Status { get; set; } = "Active"; // Active/Deactive
    
    public DateTime? StatusDate { get; set; }
    
    // Deductions (stored as comma-separated string)
    public string Deductions { get; set; } = string.Empty; // Share,Withdrawal,G Loan Instalment,E Loan Instalment
    
    // File uploads
    [MaxLength(500)]
    public string? PhotoUrl { get; set; }
    
    [MaxLength(500)]
    public string? SignatureUrl { get; set; }
    
    [Required]
    public Guid SocietyId { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    
    // Navigation properties
    public virtual Society Society { get; set; } = null!;
}
