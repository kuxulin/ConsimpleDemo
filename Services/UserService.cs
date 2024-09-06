using ConsimpleDemo.Models.DTOs;
using ConsimpleDemo.Repositories.Interfaces;
using ConsimpleDemo.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ConsimpleDemo.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IOrderRepository _orderRepository;

    public UserService(IUserRepository userRepository, IOrderRepository orderRepository)
    {
        _userRepository = userRepository;
        _orderRepository = orderRepository;
    }

    public async Task<IEnumerable<UserDTO>> GetBirthdayUsersAsync(DateTime date)
    {
        var users = await _userRepository.GetUsers()
            .Where(u => u.BirthDate.Date == date.Date)
            .Select(u => new UserDTO
            {
                Id = u.Id,
                FullName = u.FullName,
            })
            .ToListAsync();
        return users;
    }

    public async Task<IEnumerable<UserOrderDateDTO>> GetLastCustomersAsync(int days)
    {
        var minimalDate = DateTime.UtcNow.AddDays(-days);
        var users = await _userRepository.GetUsers()
            .Include(u => u.Orders)
            .Select(u => new UserOrderDateDTO
            {
                Id = u.Id,
                FullName = u.FullName,
                OrderDate = u.Orders.OrderBy(o => o.CreationDate).Last().CreationDate
            })
            .Where(u => u.OrderDate > minimalDate)
            .ToListAsync();
        return users;
    }

    public async Task<IEnumerable<BoughtCategoryDTO>> GetUserCategoriesAsync(Guid id)
    {
        var result = await _orderRepository.GetOrders()
           .Where(o => o.UserId == id)
           .SelectMany(o => o.OrderProducts)
           .GroupBy(op => op.Product.Category)
           .Select(g => new BoughtCategoryDTO
           {
               Category = g.Key,
               ProductsAmount = g.Sum(op => op.ProductAmount)
           })
           .ToListAsync();

        return result;
    }
}

