using System.ComponentModel.DataAnnotations;

namespace Practice.Models;

public class Employee
{
    [Key]
    public long Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Login { get; set; }
    public string? Password { get; set; }
}