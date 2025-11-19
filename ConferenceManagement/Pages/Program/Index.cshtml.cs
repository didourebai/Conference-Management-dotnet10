using ConferenceManagement.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ConferenceManagement.Pages.Program;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _db;
    public IndexModel(ApplicationDbContext db)
    {
        _db = db;
    }

    public List<ConferenceManagement.Models.Session> Sessions { get; set; } = new();

    public void OnGet()
    {
        Sessions = _db.Sessions
            .Include(s => s.Speaker)
            .Include(s => s.Room)
            .OrderBy(s => s.StartTime)
            .ToList();
    }
}
