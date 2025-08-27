
using System.ComponentModel.DataAnnotations;

namespace Fintcs.Data.Entities;

public class AppUser
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [Required, MaxLength(20)]
    public string Role { get; set; } = string.Empty; // SuperAdmin, SocietyAdmin, User, Member
    
    [MaxLength(20)]
    public string? EDPNo { get; set; }
    
    [Required, MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    
    [MaxLength(500)]
    public string? AddressO { get; set; } // Office Address
    
    [MaxLength(500)]
    public string? AddressR { get; set; } // Residence Address
    
    [MaxLength(100)]
    public string? Designation { get; set; }
    
    [MaxLength(20)]
    public string? PhoneO { get; set; } // Office Phone
    
    [MaxLength(20)]
    public string? PhoneR { get; set; } // Residence Phone
    
    [MaxLength(20)]
    public string? Mobile { get; set; }
    
    [MaxLength(100)]
    public string? Email { get; set; }
    
    [Required, MaxLength(50)]
    public string Username { get; set; } = string.Empty;
    
    [Required, MaxLength(256)]
    public string PasswordHash { get; set; } = string.Empty;
    
    public Guid? SocietyId { get; set; }
    
    public bool IsActive { get; set; } = true;
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    
    // Navigation properties
    public virtual Society? Society { get; set; }
}
