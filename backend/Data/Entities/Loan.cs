
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fintcs.Data.Entities;

public class Loan
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [Required, MaxLength(20)]
    public string LoanNo { get; set; } = string.Empty; // Auto-generated
    
    [Required]
    public Guid LoanTypeId { get; set; }
    
    public DateTime LoanDate { get; set; } = DateTime.Today;
    
    [MaxLength(20)]
    public string EDPNo { get; set; } = string.Empty;
    
    [Required, MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal LoanAmount { get; set; }
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal PrevLoan { get; set; }
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal NetLoan { get; set; } // Auto-calculated: LoanAmount - PrevLoan
    
    public int Installments { get; set; }
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal InstallmentAmount { get; set; }
    
    public string Purpose { get; set; } = string.Empty;
    
    [MaxLength(100)]
    public string AuthorizedBy { get; set; } = string.Empty;
    
    [MaxLength(20)]
    public string PaymentMode { get; set; } = string.Empty; // Cash, Cheque, Opening
    
    public Guid? BankId { get; set; }
    
    [MaxLength(50)]
    public string ChequeNo { get; set; } = string.Empty;
    
    public DateTime? ChequeDate { get; set; }
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal Share { get; set; }
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal CD { get; set; }
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal LastSalary { get; set; }
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal MWF { get; set; }
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal PayAmount { get; set; }
    
    // JSON fields for Given/Taken tables
    public string GivenJson { get; set; } = "[]";
    public string TakenJson { get; set; } = "[]";
    
    [Required]
    public Guid SocietyId { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    
    // Navigation properties
    public virtual Society Society { get; set; } = null!;
    public virtual LookupItem LoanType { get; set; } = null!;
    public virtual LookupItem? Bank { get; set; }
}
