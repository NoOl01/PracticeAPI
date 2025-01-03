﻿using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using Practice.DAO;
using Practice.Models;

namespace Practice.Data;

public class Mutation
{
    // [Serial]
    // public async Task<User> UpdateUser([Service] DBContext db, User model)
    // {
    //     var user = await db.Users.Where(u => u.Id == model.Id).FirstOrDefaultAsync();
    //     if (user != null)
    //     {
    //         if (!string.IsNullOrEmpty(user.FirstName))
    //             user.FirstName = model.FirstName;
    //         if (!string.IsNullOrEmpty(user.LastName))
    //             user.LastName = model.LastName;
    //         if (!string.IsNullOrEmpty(user.MiddleName))
    //             user.MiddleName = model.MiddleName;
    //         if (!string.IsNullOrEmpty(user.FirstName))
    //             user.FirstName = model.FirstName;
    //         if (!string.IsNullOrEmpty(user.PhoneNumber))
    //             user.PhoneNumber = model.PhoneNumber;
    //         if (!string.IsNullOrEmpty(user.Passport))
    //             user.Passport = model.Passport;
    //         db.Users.Update(user);
    //         await db.SaveChangesAsync();
    //     }
    //     return user;
    // }
    //
    // [Serial]
    // public async Task DeleteUser([Service] DBContext db, User model)
    // {
    //     var user = await db.Users.Where(u => u.Id == model.Id).FirstOrDefaultAsync();
    //     if (user != null)
    //     {
    //         db.Users.Remove(user);
    //         await db.SaveChangesAsync();
    //     }
    // }
    
    public async Task<User> AddUser([Service] IUserRepository rep, string firstName, string lastName, string middleName, string phoneNumber, string passport)
    {
        User user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            MiddleName = middleName,
            PhoneNumber = phoneNumber,
            Passport = passport
        };
        var createUser = await rep.AddUser(user);
        return createUser;
    }
    
    // [Serial]
    // public async Task<Service> UpdateService([Service] DBContext db, Service model)
    // {
    //     var service = await db.Services.Where(u => u.Id == model.Id).FirstOrDefaultAsync();
    //     if (service != null)
    //     {
    //         if (!string.IsNullOrEmpty(service.Title))
    //             service.Title = model.Title;
    //         db.Services.Update(service);
    //         await db.SaveChangesAsync();
    //     }
    //     return service;
    // }
    //
    // [Serial]
    // public async Task DeleteService([Service] DBContext db, Service model)
    // {
    //     var service = await db.Services.Where(u => u.Id == model.Id).FirstOrDefaultAsync();
    //     if (service != null)
    //     {
    //         db.Services.Remove(service);
    //         await db.SaveChangesAsync();
    //     }
    // }
    
    public async Task<Service> AddService([Service] IServiceRepository rep, string title, decimal price)
    {
        Service service = new Service()
        {
            Title = title,
            Price = price
        };
        var createService = await rep.AddService(service);
        return createService!;
    }
    
    // [Serial]
    // public async Task<Employee> UpdateEmployee([Service] DBContext db, Employee model)
    // {
    //     var employee = await db.Employees.Where(u => u.Id == model.Id).FirstOrDefaultAsync();
    //     if (employee != null)
    //     {
    //         if (!string.IsNullOrEmpty(employee.FirstName))
    //             employee.FirstName = model.FirstName;
    //         if (!string.IsNullOrEmpty(employee.LastName))
    //             employee.LastName = model.LastName;
    //         if (!string.IsNullOrEmpty(employee.Login))
    //             employee.Login = model.Login;
    //         if (!string.IsNullOrEmpty(employee.Password))
    //             employee.Password = model.Password;
    //         db.Employees.Update(employee);
    //         await db.SaveChangesAsync();
    //     }
    //     return employee;
    // }
    //
    // [Serial]
    // public async Task DeleteEmployee([Service] DBContext db, Employee model)
    // {
    //     var employee = await db.Employees.Where(u => u.Id == model.Id).FirstOrDefaultAsync();
    //     if (employee != null)
    //     {
    //         db.Employees.Remove(employee);
    //         await db.SaveChangesAsync();
    //     }
    // }
    
    public async Task<Employee> AddEmployee([Service] IEmployeeRepository rep, string firstName, string lastName, string login, string password)
    {
        Employee emp = new Employee
        {
            FirstName = firstName,
            LastName = lastName,
            Login = login,
            Password = Encrypt(password),
        };
        var createEmployee = await rep.AddEmployee(emp);
        return createEmployee;
    }
    
    // [Serial]
    // public async Task<Tour> UpdateTour([Service] DBContext db, Tour model)
    // {
    //     var tour = await db.Tours.Where(u => u.Id == model.Id).FirstOrDefaultAsync();
    //     if (tour != null)
    //     {
    //         if (!string.IsNullOrEmpty(tour.Country))
    //             tour.Country = model.Country;
    //         if (tour.ServiceId != 0)
    //             tour.ServiceId = model.ServiceId;
    //         if (tour.UserId != 0)
    //             tour.UserId = model.UserId;
    //         tour.Date = DateTime.Now;
    //         db.Tours.Update(tour);
    //         await db.SaveChangesAsync();
    //     }
    //     return tour;
    // }
    //
    // [Serial]
    // public async Task DeleteTour([Service] DBContext db, Tour model)
    // {
    //     var tour = await db.Tours.Where(u => u.Id == model.Id).FirstOrDefaultAsync();
    //     if (tour != null)
    //     {
    //         db.Tours.Remove(tour);
    //         await db.SaveChangesAsync();
    //     }
    // }
    
    public async Task<Tour> AddTour([Service] ITourRepository rep, string country, long serviceId, long userId)
    {
        Tour tour = new Tour
        {
            Country = country,
            ServiceId = serviceId,
            UserId = userId,
        };
        var createTour = await rep.AddTour(tour);
        return createTour;
    }
    
    private string Encrypt(string password)
    {
        byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);
        
        string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password!,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));
        
        return hashed;
    }
}