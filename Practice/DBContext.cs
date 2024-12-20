using Microsoft.EntityFrameworkCore;
using Practice.Models;

namespace Practice;

public class DBContext : DbContext
{
    public DBContext(DbContextOptions options) : base(options) { }
    
    public DbSet<Service> Services { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Tour> Tours { get; set; }
}