using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using Practice.Models;

namespace Practice.DAO;

public class EmployeeRepository
{
    private readonly DBContext _db;

    public EmployeeRepository(DBContext db)
    {
        _db = db;
    }

    public List<Employee> GetEmployees()
    {
        return _db.Employees.ToList();
    }
    
    public async Task<Employee> UpdateEmployee(Employee model)
    {
        var employee = await _db.Employees.Where(u => u.Id == model.Id).FirstOrDefaultAsync();
        if (employee != null)
        {
            if (!string.IsNullOrEmpty(employee.FirstName))
                employee.FirstName = model.FirstName;
            if (!string.IsNullOrEmpty(employee.LastName))
                employee.LastName = model.LastName;
            if (!string.IsNullOrEmpty(employee.Login))
                employee.Login = model.Login;
            if (!string.IsNullOrEmpty(employee.Password))
                employee.Password = model.Password;
            _db.Employees.Update(employee);
            await _db.SaveChangesAsync();
        }
        return employee!;
    }

    public async Task<Employee> AddEmployee(string firstName, string lastName, string login, string password)
    {
        Employee emp = new Employee
        {
            FirstName = firstName,
            LastName = lastName,
            Login = login,
            Password = Encrypt(password),
        };
        _db.Employees.Add(emp);
        await _db.SaveChangesAsync();
        return emp;
    }

    public async Task DeleteEmployee(long id)
    {
        var employee = await _db.Employees.Where(u => u.Id == id).FirstOrDefaultAsync();
        if (employee != null)
        {
            _db.Employees.Remove(employee);
            await _db.SaveChangesAsync();
        }
    }
    
    private string Encrypt(string password)
    {
        byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);
        
        string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));
        
        return hashed;
    }
}