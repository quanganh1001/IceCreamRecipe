
using Models;
using Models.Orders;

namespace Repositories.Orders;

public interface IOrderRepo
{

    Task<PaginationRes<OrderRes>> GetAllOrders(PaginationReq pageReq);

    Task<OrderRes> GetOrder(int orderId);
    
    Task<OrderRes> CreateOrder(OrderDto dto);

    Task<string> UpdateOrderStatus(int orderId, OrderStatus newStatus);
    
    void DeleteOrder(int orderId);
}