using System.ComponentModel.DataAnnotations;
namespace ConferenceManagement.Models;

public class Speaker
{
    public int Id { get; set; }

    [Required]
    public string FirstName { get; set; } = null!;

    [Required]
    public string LastName { get; set; } = null!;

    [Required, EmailAddress]
    public string Email { get; set; } = null!;

    public string? Bio { get; set; }

    public string? Organization { get; set; }

    public string? PhotoUrl { get; set; }

    public ICollection<Session> Sessions { get; set; } = new List<Session>();
}
