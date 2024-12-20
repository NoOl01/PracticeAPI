using System.ComponentModel.DataAnnotations;

namespace Practice.Models;

public class User
{
    [Key]
    public long Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? MiddleName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Passport { get; set; }
    public ICollection<Tour>? Tours { get; set; }
}