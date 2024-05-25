﻿
using System.ComponentModel.DataAnnotations;
using Models.OrderDetails;
using Models.Users;

namespace Models.Orders {
    public class Order : BaseEntity {

        public int? UserId { get; set; }

        [Required]
        public required string Name { get; set; }

        [EmailAddress]
        [Required]
        public required string Email { get; set; }

        [Phone]
        [Required]
        public required string Phone { get; set; }

        public OrderStatus Status { get; set; }

        [Required]
        public required string Street { get; set; }

        [Required]
        public required string City { get; set; }

        [Required]
        public required string Country { get; set; }

        public User? User { get; set; }

        public List<OrderDetail> OrderDetails { get; set; } = [];
    }
}
