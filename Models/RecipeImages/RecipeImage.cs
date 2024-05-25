using System.ComponentModel.DataAnnotations;
using Models.Recipes;

namespace Models.RecipeImages {
    public class RecipeImage : BaseEntity {

        [Required]
        public int RecipeId { get; set; }

        [Required]
        public required string Image { get; set; }

        [Required]
        public required string Name { get; set; }

        public Recipe Recipe { get; set; }

    }
}
