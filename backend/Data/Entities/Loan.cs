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

    [Required]
    public DateTime LoanDate { get; set; }

    [Required, MaxLength(20)]
    public string EDPNo { get; set; } = string.Empty;

    [Required, MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    public decimal LoanAmount { get; set; }

    public decimal PrevLoan { get; set; } = 0;

    // NetLoan is a computed column: LoanAmount - PrevLoan
    public decimal NetLoan { get; private set; }

    [Required]
    public int Installments { get; set; }

    [Required]
    public decimal InstallmentAmount { get; set; }

    public string? Purpose { get; set; }

    [MaxLength(100)]
    public string? AuthorizedBy { get; set; }

    [Required, MaxLength(20)]
    public string PaymentMode { get; set; } = string.Empty; // Cash, Cheque, Opening

    public Guid? BankId { get; set; }

    [MaxLength(50)]
    public string? ChequeNo { get; set; }

    public DateTime? ChequeDate { get; set; }

    public decimal Share { get; set; } = 0;
    public decimal CD { get; set; } = 0;
    public decimal LastSalary { get; set; } = 0;
    public decimal MWF { get; set; } = 0;
    public decimal PayAmount { get; set; } = 0;

    // Given/Taken tables stored as JSON
    public string? GivenJson { get; set; }
    public string? TakenJson { get; set; }

    [Required]
    public Guid SocietyId { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    // Navigation properties
    public virtual Society Society { get; set; } = null!;
    public virtual LookupItem LoanType { get; set; } = null!;
    public virtual LookupItem? Bank { get; set; }
}