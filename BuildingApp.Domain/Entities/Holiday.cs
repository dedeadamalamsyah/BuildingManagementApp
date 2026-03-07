using System.ComponentModel.DataAnnotations;

namespace BuildingApp.Domain.Entities;

public class Holiday
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public DateTime Date { get; set; }
}