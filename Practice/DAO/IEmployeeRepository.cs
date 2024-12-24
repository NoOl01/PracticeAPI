using Practice.Models;

namespace Practice.DAO;

public interface IEmployeeRepository
{
    IQueryable<Employee> GetEmployees();
    Task<Employee> GetEmployeeById(long id);
    Task<Employee> AddEmployee(Employee emp);
}