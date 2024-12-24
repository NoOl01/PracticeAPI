using Practice.Models;

namespace Practice.DAO;

public interface IServiceRepository
{
    IQueryable<Service> GetServices();
    Task<Service> GetServiceById(long id);
    Task<Service?> AddService(Service service);
}