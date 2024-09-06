using ConsimpleDemo.Models.DTOs;

namespace ConsimpleDemo.Services.Interfaces;

public interface IUserService
{
    Task<IEnumerable<UserDTO>> GetBirthdayUsersAsync(DateTime date);
    Task<IEnumerable<UserOrderDateDTO>> GetLastCustomersAsync(int days);
    Task<IEnumerable<BoughtCategoryDTO>> GetUserCategoriesAsync(Guid id);
}
