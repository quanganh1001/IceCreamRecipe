using System.ComponentModel.DataAnnotations;
using Models.Books;

namespace Models.BookImages {
    public class BookImage : BaseEntity {

        [Required]
        public required int BookId { get; set; }

        [Required]
        public required string Image { get; set; }

        public string? Name { get; set; }

        public required Book Book { get; set; }
    }
}
