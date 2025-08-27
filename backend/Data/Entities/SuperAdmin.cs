
using System.ComponentModel.DataAnnotations;

namespace Fintcs.Data.Entities;

public class SuperAdmin
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [Required, MaxLength(50)]
    public string Username { get; set; } = string.Empty;
    
    [Required, MaxLength(256)]
    public string PasswordHash { get; set; } = string.Empty;
    
    [Required, MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    
    [MaxLength(100)]
    public string? Email { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}
