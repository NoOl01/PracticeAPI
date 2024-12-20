using Practice.Models;

namespace Practice.Data;

public class Query
{
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<User> GetUsers([Service] DBContext context) => context.Users;
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Service> GetServices([Service] DBContext context) => context.Services;
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Employee> GetEmployees([Service] DBContext context) => context.Employees;
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Tour> GetTours([Service] DBContext context) => context.Tours;
}