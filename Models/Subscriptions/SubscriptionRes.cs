using Models.Plans;

namespace Models.Subscriptions {
    public class SubscriptionRes {

        public int Id { get; set; }

        public DateTime ExpiredAt { get; set; }

        public int Plan { get; set; }
        
        public DateTime CreatedAt { get; set; }
        
        public DateTime UpdatedAt { get; set; }

    }
}