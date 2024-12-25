using Microsoft.EntityFrameworkCore;
using Practice.Models;

namespace Practice.DAO;

public class ServiceRepository : IServiceRepository
{
    private readonly DBContext _db;

    public ServiceRepository(DBContext db)
    {
        _db = db;
    }

    public IQueryable<Service> GetServices()
    {
        return _db.Services.AsQueryable();
    }

    public async Task<Service> GetServiceById(long id)
    {
        var service = await _db.Services.FirstOrDefaultAsync(s => s.Id == id);
        return service;
    }

    public async Task<Service?> AddService(Service service)
    {
        _db.Services.Add(service);
        await _db.SaveChangesAsync();
        return service;
    }

    public async Task<decimal> CalculateCost(List<Service> service)
    {
        decimal cost = 0;
        foreach (var i in service)
        {
            cost += i.Price;
        }

        return cost;
    }
}