
using Models.OrderDetails;

namespace Models.Orders;

public class OrderRes
{
    public int Id { get; set; }
    
    public int? UserId { get; set; }
    
    public required string Name { get; set; }
    
    public required string Email { get; set; }
    
    public required string Phone { get; set; }

    public OrderStatus Status { get; set; }
    
    public required string Street { get; set; }
    
    public required string City { get; set; }
    
    public required string Country { get; set; }
    
    public List<OrderDetailRes> OrderDetails { get; set; } = [];
}