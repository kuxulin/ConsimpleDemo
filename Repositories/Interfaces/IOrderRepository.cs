using ConsimpleDemo.Models;

namespace ConsimpleDemo.Repositories.Interfaces;

public interface IOrderRepository
{
    IQueryable<Order> GetOrders();
}
