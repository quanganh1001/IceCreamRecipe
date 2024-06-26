
using System.ComponentModel.DataAnnotations;
using Models.Subscriptions;

namespace Models.Users;

public class User : BaseEntity {

    [Required]
    public required string Name { get; set; }

    [Required]
    public required string Username { get; set; }

    [EmailAddress]
    public required string Email { get; set; }

    [Required]
    public required string Password { get; set; }

    public Role Role { get; set; }

    [Phone]
    public string? Phone { get; set; }

    public string? Avatar { get; set; }

    public string? Street { get; set; }

    public string? City { get; set; }

    public string? Country { get; set; }

    public bool IsActivated { get; set; } = false;
    
    public ICollection<Subscription> Subscriptions { get; set; } = [];
}