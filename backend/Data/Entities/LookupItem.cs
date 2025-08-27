
using System.ComponentModel.DataAnnotations;

namespace Fintcs.Data.Entities;

public class LookupItem
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [Required, MaxLength(20)]
    public string Code { get; set; } = string.Empty;
    
    [Required, MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    
    [Required, MaxLength(50)]
    public string Category { get; set; } = string.Empty; // LoanType, Bank, VoucherType, Month
    
    public bool IsActive { get; set; } = true;
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}
