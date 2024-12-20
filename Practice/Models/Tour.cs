using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practice.Models;

public class Tour
{
    [Key]
    public long Id { get; set; }
    
    public string? Country { get; set; }
    [ForeignKey("ServiceId")]
    public long ServiceId { get; set; }
    public Service? Services { get; set; }
    [ForeignKey("UserId")]
    public long UserId { get; set; }
    public User? User { get; set; }
    public DateTime? Date { get; set; } = DateTime.Now;
}