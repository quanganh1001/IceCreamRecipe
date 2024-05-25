using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Plans {
    public class Plan : BaseEntity {

        [Required]
        public required PlanType Type { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public required decimal Price { get; set; }

    }
}
