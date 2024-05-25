
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Models.Books;
using Models.Orders;

namespace Models.OrderDetails {
    public class OrderDetail : BaseEntity {
        [Required]
        public required int OrderId { get; set; }

        [Required]
        public required int BookId { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public required decimal PurchasePrice { get; set; }

        [Required]
        public required int Quantity { get; set; }

        public required Order Order { get; set; }

        public required Book Book { get; set; }

    }
}
