﻿using System.ComponentModel.DataAnnotations;

namespace Models.Recipes {
    public class RecipeCreateDto {

        [Required]
        public required int UserId { get; set; }

        [Required]
        public required string Title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public required string Ingredients { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public required string Description { get; set; }
        
        [Required]
        public required string ShortDescription {get; set;}

        public IFormFile? Thumbnail { get; set; }

        public ICollection<IFormFile>? Files { get; set; } = [];

        public RecipeType Type { get; set; }
    }
}
