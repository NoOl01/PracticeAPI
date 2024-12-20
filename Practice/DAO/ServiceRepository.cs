using Microsoft.EntityFrameworkCore;
using Practice.Models;

namespace Practice.DAO;

public class ServiceRepository
{
    private readonly DBContext _db;

    public ServiceRepository(DBContext db)
    {
        _db = db;
    }

    public List<Service> GetServices()
    {
        return _db.Services.ToList();
    }
    
    public async Task<Service> UpdateService(Service model)
    {
        var service = await _db.Services.Where(u => u.Id == model.Id).FirstOrDefaultAsync();
        if (service != null)
        {
            if (!string.IsNullOrEmpty(service.Title))
                service.Title = model.Title;
            _db.Services.Update(service);
            await _db.SaveChangesAsync();
        }
        return service!;
    }
    
    public async Task<Service> AddService(string title, decimal price)
    {
        var service = new Service
        {
            Title = title,
            Price = price
        };
        _db.Services.Add(service);
        await _db.SaveChangesAsync();
        return service;
    }

    public async Task DeleteService(long id)
    {
        var service = await _db.Services.Where(u => u.Id == id).FirstOrDefaultAsync();
        if (service != null)
        {
            _db.Services.Remove(service);
            await _db.SaveChangesAsync();
        }
    }
}