using System.ComponentModel.DataAnnotations;
namespace ConferenceManagement.Models;

public class Room
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    public int? Capacity { get; set; }

    public ICollection<Session> Sessions { get; set; } = new List<Session>();
}
