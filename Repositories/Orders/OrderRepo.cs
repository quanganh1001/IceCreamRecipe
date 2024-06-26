using AutoMapper;

using Exceptions;
using IceCreamRecipe.Models;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Orders;

namespace Repositories.Orders;

public class OrderRepo : IOrderRepo
{

    private readonly AppDbContext _context;

    private readonly IMapper _mapper;


    public OrderRepo(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginationRes<OrderRes>> GetAllOrders(PaginationReq pageReq)
    { 
       
        var orders = await _context.Orders
            .Skip((pageReq.PageNo -1) * pageReq.PerPage)
            .Take(pageReq.PerPage)
            .ToListAsync();
        

        // list Orders --> PageOrder
        var totalOrders = await _context.Orders.CountAsync();

        return new PaginationRes<OrderRes>(pageReq.PageNo, pageReq.PerPage, totalOrders, _mapper.Map<List<OrderRes>>(orders));
        
    }
    
    public async Task<OrderRes> GetOrder(int orderId)
    { 
       var order = await _context.Orders.FindAsync(orderId)
               ??
               throw new NotFoundException("Order not found");
       
       // add OrderDetail for order
       var orderDetails = _context.OrderDetails
           .Where(od => od.OrderId == order.Id)
           .ToList();

       foreach (var detail in orderDetails)
       {
           detail.Book = await _context.Books.FindAsync(detail.BookId) ??
                         throw new NotFoundException("Book not found");
       }
       
       return _mapper.Map<OrderRes>(order);
    }


    
    public async Task<OrderRes> CreateOrder(OrderDto dto)
    {
        // Check if dto.UserId is not null and doesn't exist in the database
        if (dto.UserId != null && !_context.Users.Any(u => u.Id == dto.UserId))
        {
            throw new NotFoundException("UserId not found in the database.");
        }
        
        // OrderDto -> Order
        var order = _mapper.Map<Order>(dto);
        
        order.Status = OrderStatus.Process;
        
        // save order to db
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
        
       
        
        // order -> orderRes
        var orderRes = _mapper.Map<OrderRes>(order);
        return orderRes;
    }

    public async Task<string> UpdateOrderStatus(int orderId, OrderStatus newStatus)
    {
        // find order with orderId
        var orderCurrent =  await _context.Orders.FindAsync(orderId) ?? throw new NotFoundException("Order Not Found");
        
        // check Status valid
        if (orderCurrent.Status == OrderStatus.Process && 
            newStatus is OrderStatus.Completed 
                        or OrderStatus.Return 
                        or OrderStatus.Returned)
        {
            throw new BadRequestException("Cannot change status " + orderCurrent.Status + " to " + newStatus);
        }
        
        if (orderCurrent.Status == OrderStatus.Shipping &&
            newStatus is OrderStatus.Process 
                            or OrderStatus.Returned 
                            or OrderStatus.Cancel)
        {
            throw new BadRequestException("Cannot change status " + orderCurrent.Status + " to " + newStatus);
        }
        
        if (orderCurrent.Status == OrderStatus.Completed &&
            newStatus is not OrderStatus.Completed )
        {
            throw new BadRequestException("Cannot change status " + orderCurrent.Status + " to " + newStatus);
        }
        
        if (orderCurrent.Status == OrderStatus.Return &&
            newStatus is not OrderStatus.Returned )
        {
            throw new BadRequestException("Cannot change status " + orderCurrent.Status + " to " + newStatus);
        }
        
        if (orderCurrent.Status == OrderStatus.Returned &&
            newStatus is not OrderStatus.Returned )
        {
            throw new BadRequestException("Cannot change status " + orderCurrent.Status + " to " + newStatus);
        }
        
        if (orderCurrent.Status == OrderStatus.Cancel &&
            newStatus is OrderStatus.Completed 
                        or OrderStatus.Returned 
                        or OrderStatus.Return)
        {
            throw new BadRequestException("Cannot change status " + orderCurrent.Status + " to " + newStatus);
        }
        
        // if status valid -> save status
        orderCurrent.Status = newStatus;
        try
        {
            await _context.SaveChangesAsync();
            return "Order status updated successfully";
        }
        catch (Exception ex)
        {
            return "Error updating order status: " + ex.Message;
        }
        
    }

    public async void DeleteOrder(int orderId)
    {
        var order = await _context.Orders.FindAsync(orderId) ?? throw new NotFoundException("Order Not Found");
        
        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();
        
    }
}