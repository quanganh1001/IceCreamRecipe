using System.ComponentModel.DataAnnotations;

namespace Models.Users;

public class LoginDto
{
    [Required]
    public required string Username { get; set; }
    
    [Required]
    public required string Password { get; set; }
}