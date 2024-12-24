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
    public async Task<User> GetUserById([Service] IUserRepository rep, long id)
    {
        User user = await rep.GetUserById(id);
        return user;
    }
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Service> GetServices([Service] IServiceRepository rep) => rep.GetServices();

    [UseProjection]
    public async Task<Service> GetServiceById([Service] IServiceRepository rep, long id)
    {
        Service service = await rep.GetServiceById(id);
        return service;
    }
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Employee> GetEmployees([Service] IEmployeeRepository rep) => rep.GetEmployees();

    [UseProjection]
    public async Task<Employee> GetEmployeeById([Service] IEmployeeRepository rep, long id)
    {
        Employee emp = await rep.GetEmployeeById(id);
        return emp;
    }
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Tour> GetTours([Service] ITourRepository rep) => rep.GetTours();

    [UseProjection]
    public async Task<Tour> GetTourById([Service] ITourRepository rep, long id)
    {
        Tour tour = await rep.GetTourById(id);
        return tour;
    }
}