using System.ComponentModel.DataAnnotations;

namespace Models.RecipeImages;

public class RecipeImageCreateDto
{
    [Required]
    public int RecipeId { get; set; }

    [Required]
    public required string Image { get; set; }

    [Required]
    public required string Name { get; set; }
    
}