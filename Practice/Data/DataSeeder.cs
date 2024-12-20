using System.Security.Cryptography;
using Faker;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Practice.Models;

namespace Practice.Data;

public class DataSeeder
{
    public static void SeedData(DBContext db)
    {
        Random rnd = new Random();
        if (!db.Services.Any())
        {
            db.Services.AddRange(
                new Service
                {
                    Title = "Выбрать отель",
                    Price = 5000
                },
                new Service
                {
                    Title = "Составить тур",
                    Price = 10000
                }
            );
        }

        if (!db.Users.Any())
        {
            for (int i = 1; i <= 10; i++)
            {
                var user = new User
                {
                    FirstName = Name.First(),
                    LastName = Name.Last(),
                    MiddleName = Name.Middle(),
                    PhoneNumber = Phone.Number(),
                    Passport = Identification.UkPassportNumber()
                };
                db.Users.Add(user);
            }
        }

        if (!db.Employees.Any())
        {
            for (int i = 0; i <= 10; i++)
            {
                var emp = new Employee
                {
                    FirstName = Name.First(),
                    LastName = Name.Last(),
                    Login = Internet.UserName(),
                    Password = Encrypt(Lorem.Paragraph())
                };
                db.Employees.Add(emp);
            }
        }
        db.SaveChanges();
    }
    private static string Encrypt(string password)
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