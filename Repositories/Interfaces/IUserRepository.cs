using ConsimpleDemo.Models;

namespace ConsimpleDemo.Repositories.Interfaces;

public interface IUserRepository
{
    IQueryable<User> GetUsers();
}
