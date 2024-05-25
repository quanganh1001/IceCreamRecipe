
using System.ComponentModel.DataAnnotations;
using Models.Plans;
using Models.Users;

namespace Models.Subscriptions {
    public class Subscription : BaseEntity {

        [Required]
        public int UserId { get; set; }

        [Required]
        public int PlanId { get; set; }

        [Required]
        public DateTime ExpiredAt { get; set; }

        public User User { get; set; }

        public Plan Plan { get; set; }

    }
}
