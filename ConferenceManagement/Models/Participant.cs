using System.ComponentModel.DataAnnotations;
namespace ConferenceManagement.Models;

public class Participant
{
    public int Id { get; set; }

    [Required]
    public int ConferenceId { get; set; }
    public Conference? Conference { get; set; }

    [Required]
    public string FirstName { get; set; } = null!;

    [Required]
    public string LastName { get; set; } = null!;

    [Required, EmailAddress]
    public string Email { get; set; } = null!;

    public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;
}
