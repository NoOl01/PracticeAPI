using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using Practice.Models;

namespace Practice.DAO;

public class TourRepository
{
    private readonly DBContext _db;

    public TourRepository(DBContext db)
    {
        _db = db;
    }

    public List<Tour> GetAllToursOnly()
    {
        return _db.Tours.ToList();
    }

    public List<Tour> GetAllToursWithUsers()
    {
        return _db.Tours.Include(u => u.User).ToList();
    }

    public List<Tour> GetAllToursWithServices()
    {
        return _db.Tours.Include(s => s.Services).ToList();
    }

    public List<Tour> GetAllToursWithUserAndServices()
    {
        return _db.Tours.Include(u => u.User).Include(s => s.Services).ToList();
    }

    public async Task<Tour> UpdateTour(Tour model)
    {
        var tour = await _db.Tours.Where(u => u.Id == model.Id).FirstOrDefaultAsync();
        if (tour != null)
        {
            if (!string.IsNullOrEmpty(tour.Country))
                tour.Country = model.Country;
            if (tour.ServiceId != 0)
                tour.ServiceId = model.ServiceId;
            if (tour.UserId != 0)
                tour.UserId = model.UserId;
            tour.Date = DateTime.Now;
            _db.Tours.Update(tour);
            await _db.SaveChangesAsync();
        }
        return tour!;
    }

    public async Task<Tour> AddTour(string country, long serviceId, long userId)
    {
        Tour tour = new Tour
        {
            Country = country,
            ServiceId = serviceId,
            UserId = userId,
        };
        _db.Tours.Add(tour);
        await _db.SaveChangesAsync();
        return tour;
    }

    public async Task DeleteTour(long id)
    {
        var tour = await _db.Tours.Where(u => u.Id == id).FirstOrDefaultAsync();
        if (tour != null)
        {
            _db.Tours.Remove(tour);
            await _db.SaveChangesAsync();
        }
    }
}