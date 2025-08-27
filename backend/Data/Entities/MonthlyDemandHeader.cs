
using System.ComponentModel.DataAnnotations;

namespace Fintcs.Data.Entities;

public class MonthlyDemandHeader
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [Required]
    public Guid MonthId { get; set; }
    
    public int YearValue { get; set; }
    
    [Required]
    public Guid SocietyId { get; set; }
    
    public int TotalMembers { get; set; }
    public decimal TotalAmount { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    
    // Navigation properties
    public virtual Society Society { get; set; } = null!;
    public virtual LookupItem Month { get; set; } = null!;
    public virtual ICollection<MonthlyDemandRow> Rows { get; set; } = new List<MonthlyDemandRow>();
}
