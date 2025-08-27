
using System.ComponentModel.DataAnnotations;

namespace Fintcs.Data.Entities;

public class LookupItem
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [Required, MaxLength(50)]
    public string Category { get; set; } = string.Empty; // LoanType, Bank, VoucherType, Month, Year
    
    [Required, MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    
    [MaxLength(20)]
    public string Code { get; set; } = string.Empty;
    
    public string? Value { get; set; } // For additional data like year numbers
    
    public int SortOrder { get; set; }
    
    public bool IsActive { get; set; } = true;
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
