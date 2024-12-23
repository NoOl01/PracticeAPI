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

    public Service? GetServiceById(long id)
    {
        var services = _db.Services.FirstOrDefault(s => s.Id == id);
        return services;
    }

    public async Task<Service?> AddService(Service service)
    {
        _db.Services.Add(service);
        await _db.SaveChangesAsync();
        return service;
    }
}