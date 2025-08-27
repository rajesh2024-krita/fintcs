
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fintcs.Data.Entities;

public class MonthlyDemandRow
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [Required]
    public Guid HeaderId { get; set; }
    
    [MaxLength(20)]
    public string EDPNo { get; set; } = string.Empty;
    
    [MaxLength(100)]
    public string MemberName { get; set; } = string.Empty;
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal LoanAmt { get; set; }
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal CD { get; set; }
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal Loan { get; set; }
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal Interest { get; set; }
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal ELoan { get; set; }
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal InterestExtra { get; set; }
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal Net { get; set; }
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal IntDue { get; set; }
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal PInt { get; set; }
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal PDed { get; set; }
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal LAS { get; set; }
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal Int { get; set; }
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal LASIntDue { get; set; }
    
    // Navigation properties
    public virtual MonthlyDemandHeader Header { get; set; } = null!;
}
