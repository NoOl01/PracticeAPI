using Practice.Models;

namespace Practice.DAO;

public interface IUserRepository
{
    IQueryable<User> GetUsers();
    Task<User> GetUserById(long id);
    Task<User> AddUser(User user);
}