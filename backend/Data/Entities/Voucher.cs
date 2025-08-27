
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fintcs.Data.Entities;

public class Voucher
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [Required, MaxLength(20)]
    public string VoucherNo { get; set; } = string.Empty; // Auto-generated
    
    [Required]
    public Guid VoucherTypeId { get; set; }
    
    public DateTime Date { get; set; } = DateTime.Today;
    
    [MaxLength(50)]
    public string ChNo { get; set; } = string.Empty;
    
    public DateTime? ChequeDate { get; set; }
    
    public string Narration { get; set; } = string.Empty;
    
    public string Remarks { get; set; } = string.Empty;
    
    public DateTime? PassDate { get; set; }
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalDebit { get; set; }
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalCredit { get; set; }
    
    [Required]
    public Guid SocietyId { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    
    // Navigation properties
    public virtual Society Society { get; set; } = null!;
    public virtual LookupItem VoucherType { get; set; } = null!;
    public virtual ICollection<VoucherLine> Lines { get; set; } = new List<VoucherLine>();
}
