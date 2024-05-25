
using Models.OrderDetails;
using Models.Orders;


namespace Repositories.OrdersDetail;

public interface IOrderDetailRepo
{

    Task<List<OrderDetailRes>> GetAllByOrder(int orderId);

    Task CreateOrderDetail(int orderId, OrderDto dto);

    // void UpdateOrderDetail(int orderId, UpdateOrderDto dto);
}
