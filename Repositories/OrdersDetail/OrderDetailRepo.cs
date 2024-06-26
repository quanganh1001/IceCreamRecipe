using AutoMapper;
using Exceptions;
using IceCreamRecipe.Models;
using Microsoft.EntityFrameworkCore;
using Models.OrderDetails;
using Models.Orders;


namespace Repositories.OrdersDetail;

public class OrderDetailRepo : IOrderDetailRepo
{

    private readonly AppDbContext _context;

    private readonly IMapper _mapper;

    public OrderDetailRepo(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    
    public async Task<List<OrderDetailRes>> GetAllByOrder(int orderId)
    {
        var orderDetails = await _context.OrderDetails
            .Where(od => od.OrderId == orderId)
            .ToListAsync();

        foreach (var orderDetail in orderDetails)
        {
            var book = await _context.Books.FindAsync(orderDetail.BookId) ?? throw new NotFoundException("Book Not Found");
            var order = await _context.Orders.FindAsync(orderDetail.OrderId) ?? throw new NotFoundException("Order Not Found");
            
            orderDetail.Book = book;
            orderDetail.Order = order;
        }
        var orderDetailResList = _mapper.Map<List<OrderDetailRes>>(orderDetails);

        return orderDetailResList;
    }

    public async Task CreateOrderDetail(int orderId, OrderDto dto)
    {
        // list OrderDetailDto -> list OrderDetail
        var orderDetails = _mapper.Map<List<OrderDetail>>(dto.OrderDetails);

        // add OrderId for OrderDetail
        foreach (var orderDetail in orderDetails)
        {
            // Check if dto.BookId is not null and doesn't exist in the database
            var book = await _context.Books.FindAsync(orderDetail.BookId) ?? throw new NotFoundException("Book Not Found");

            orderDetail.Book = book;
            orderDetail.OrderId = orderId;

            _context.OrderDetails.Add(orderDetail);
        }

        await _context.SaveChangesAsync();
    }
    
}