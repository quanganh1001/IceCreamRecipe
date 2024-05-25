using System.ComponentModel.DataAnnotations;

namespace Models;

public abstract class BaseEntity {
    [Key]
    public int Id { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    [Required]
    public DateTime UpdatedAt { get; set; }

}