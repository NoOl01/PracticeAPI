using Practice.Models;

namespace Practice.DAO;

public interface ITourRepository
{
    IQueryable<Tour> GetTours();
    Tour GetTourById(long id);
    Task<Tour> AddTour(Tour tour);
}