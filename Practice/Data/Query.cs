using Practice.DAO;
using Practice.Models;

namespace Practice.Data;

public class Query
{
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<User> GetUsers([Service] IUserRepository rep) => rep.GetUsers();
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Service> GetServices([Service] IServiceRepository rep) => rep.GetServices();
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Employee> GetEmployees([Service] IEmployeeRepository rep) => rep.GetEmployees();
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Tour> GetTours([Service] ITourRepository rep) => rep.GetTours();
}