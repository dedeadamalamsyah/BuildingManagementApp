using System.ComponentModel.DataAnnotations;

namespace BuildingApp.Domain.Entities;

public class Visitor
{
    public int Id { get; set; }

    [Required]
    public string FullName { get; set; } = string.Empty;

    [Required, EmailAddress]
    public string Email { get; set; } = string.Empty;

    public DateTime RegistrationDate { get; set; } = DateTime.Now;

    public bool IsApproved { get; set; } = true;
}