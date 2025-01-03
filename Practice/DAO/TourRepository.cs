﻿using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using Practice.Models;

namespace Practice.DAO;

public class TourRepository : ITourRepository
{
    private readonly DBContext _db;

    public TourRepository(DBContext db)
    {
        _db = db;
    }


    public IQueryable<Tour> GetTours()
    {
        return _db.Tours.AsQueryable();
    }

    public async Task<Tour> GetTourById(long id)
    {
        var tour = await _db.Tours.FirstOrDefaultAsync(t => t.Id == id);
        return tour;
    }

    public async Task<Tour> AddTour(Tour tour)
    {
        _db.Tours.Add(tour);
        await _db.SaveChangesAsync();
        return tour;
    }
}