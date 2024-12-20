using Microsoft.EntityFrameworkCore;
using Practice.Models;

namespace Practice.DAO;

public class UserRepository
{
    private readonly DBContext _db;

    public UserRepository(DBContext db)
    {
        _db = db;
    }

    public List<User> GetUsers()
    {
        return _db.Users.ToList();
    }
    
    public async Task<User> UpdateUser(User model)
    {
        var user = await _db.Users.Where(u => u.Id == model.Id).FirstOrDefaultAsync();
        if (user != null)
        {
            if (!string.IsNullOrEmpty(user.FirstName))
                user.FirstName = model.FirstName;
            if (!string.IsNullOrEmpty(user.LastName))
                user.LastName = model.LastName;
            if (!string.IsNullOrEmpty(user.MiddleName))
                user.MiddleName = model.MiddleName;
            if (!string.IsNullOrEmpty(user.FirstName))
                user.FirstName = model.FirstName;
            if (!string.IsNullOrEmpty(user.PhoneNumber))
                user.PhoneNumber = model.PhoneNumber;
            if (!string.IsNullOrEmpty(user.Passport))
                user.Passport = model.Passport;
            _db.Users.Update(user);
            await _db.SaveChangesAsync();
        }
        return user!;
    }

    public async Task<User> AddUser(string firstName, string lastName, string middleName, string phoneNumber, string passport)
    {
        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            MiddleName = middleName,
            PhoneNumber = phoneNumber,
            Passport = passport
        };
        _db.Users.Add(user);
        await _db.SaveChangesAsync();
        return user;
    }

    public async Task DeleteUser(long id)
    {
        var user = await _db.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
        if (user != null)
        {
            _db.Users.Remove(user);
            await _db.SaveChangesAsync();
        }
    }
}