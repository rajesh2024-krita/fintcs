
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fintcs.Data.Entities;

public class VoucherLine
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [Required]
    public Guid VoucherId { get; set; }
    
    [Required, MaxLength(200)]
    public string Particulars { get; set; } = string.Empty;
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal Debit { get; set; }
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal Credit { get; set; }
    
    [MaxLength(10)]
    public string DbCr { get; set; } = string.Empty; // Debit/Credit
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal Ibldbc { get; set; }
    
    // Navigation properties
    public virtual Voucher Voucher { get; set; } = null!;
}
