using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using Practice.Models;

namespace Practice.DAO;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly DBContext _db;

    public EmployeeRepository(DBContext db)
    {
        _db = db;
    }

    public IQueryable<Employee> GetEmployees()
    {
        return _db.Employees.AsQueryable();
    }

    public async Task<Employee> GetEmployeeById(long id)
    {
        var emp = await _db.Employees.FirstOrDefaultAsync(e => e.Id == id);
        return emp;
    }

    public async Task<Employee> AddEmployee(Employee emp)
    {
        _db.Employees.Add(emp);
        await _db.SaveChangesAsync();
        return emp;
    }
}