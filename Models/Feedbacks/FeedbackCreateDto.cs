using System.ComponentModel.DataAnnotations;

namespace Models.Feedbacks {
    public class FeedbackCreateDto {

        [Required]
        public required string Name { get; set; }

        [EmailAddress]
        [Required]
        public required string Email { get; set; }

        [Required]
        public required string Content { get; set; }

    }
}
