using System.ComponentModel.DataAnnotations;

namespace Practice.DTO;

public class ServiceDTO
{
    [Key]
    [Required]
    public long Id { get; set; }
    [Required]
    public string? Title { get; set; }
    [Required]
    public decimal Price { get; set; }
}