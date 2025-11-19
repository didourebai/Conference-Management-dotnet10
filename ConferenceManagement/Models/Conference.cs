using System.ComponentModel.DataAnnotations;
namespace ConferenceManagement.Models;

public class Conference
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? Location { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public ICollection<Session> Sessions { get; set; } = new List<Session>();

    public ICollection<Participant> Participants { get; set; } = new List<Participant>();
}
