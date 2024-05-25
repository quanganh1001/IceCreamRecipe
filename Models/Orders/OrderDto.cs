using System.ComponentModel.DataAnnotations;
using Models.OrderDetails;

namespace Models.Orders;

public class OrderDto
{
    public int? UserId { get; set; }

    [Required]
    public required string Name { get; set; }

    [EmailAddress]
    [Required]
    public required string Email { get; set; }

    [Phone]
    [Required]
    public required string Phone { get; set; }
    
    [Required]
    public required string Street { get; set; }

    [Required]
    public required string City { get; set; }

    [Required]
    public required string Country { get; set; }

    public required decimal TotalAmount { get; set; } = 0; 
    public List<OrderDetailDto> OrderDetails { get; set; } = [];
}