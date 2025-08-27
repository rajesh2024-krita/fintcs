
using System.ComponentModel.DataAnnotations;

namespace Fintcs.Data.Entities;

public class PendingEdit
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [Required, MaxLength(50)]
    public string Entity { get; set; } = string.Empty; // Society, User, etc.
    
    [Required]
    public Guid EntityId { get; set; }
    
    [Required]
    public string PayloadJson { get; set; } = string.Empty; // Serialized changes
    
    [MaxLength(20)]
    public string Status { get; set; } = "Pending"; // Pending, Approved, Rejected
    
    [Required]
    public Guid CreatedByUserId { get; set; }
    
    public bool ApprovedByAllUsers { get; set; } = false;
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}
