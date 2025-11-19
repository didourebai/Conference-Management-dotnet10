using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ConferenceManagement.Models;

public class Session
{
    public int Id { get; set; }

    [Required]
    public int ConferenceId { get; set; }
    public Conference? Conference { get; set; }

    [Required]
    public string Title { get; set; } = null!;

    public string? Abstract { get; set; }

    public int? SpeakerId { get; set; }
    public Speaker? Speaker { get; set; }

    public int? RoomId { get; set; }
    public Room? Room { get; set; }

    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }

    public SessionType SessionType { get; set; } = SessionType.Talk;
}
