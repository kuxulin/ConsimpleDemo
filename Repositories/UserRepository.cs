using ConsimpleDemo.Data;
using ConsimpleDemo.Models;
using ConsimpleDemo.Repositories.Interfaces;

namespace ConsimpleDemo.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationContext _context;

    public UserRepository(ApplicationContext context)
    {
        _context = context;
    }

    public IQueryable<User> GetUsers()
    {
        return _context.Users;
    }


}
