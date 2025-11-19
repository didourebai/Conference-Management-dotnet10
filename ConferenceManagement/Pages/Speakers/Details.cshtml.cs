using ConferenceManagement.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ConferenceManagement.Pages.Speakers;

public class DetailsModel : PageModel
{
    private readonly ApplicationDbContext _db;
    public DetailsModel(ApplicationDbContext db) => _db = db;

    public ConferenceManagement.Models.Speaker? Speaker { get; set; }
    public List<ConferenceManagement.Models.Session> Sessions { get; set; } = new();

    public IActionResult OnGet(int id)
    {
        Speaker = _db.Speakers.Find(id);
        if (Speaker == null) return NotFound();

        Sessions = _db.Sessions
            .Include(s => s.Room)
            .Where(s => s.SpeakerId == id)
            .OrderBy(s => s.StartTime)
            .ToList();

        return Page();
    }
}
