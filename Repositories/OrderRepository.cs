using ConsimpleDemo.Data;
using ConsimpleDemo.Models;
using ConsimpleDemo.Repositories.Interfaces;

namespace ConsimpleDemo.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly ApplicationContext _context;

    public OrderRepository(ApplicationContext context)
    {
        _context = context;
    }

    public IQueryable<Order> GetOrders()
    {
        return _context.Orders;
    }
}
