using ConferenceManagement.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ConferenceManagement.Pages.Program;

public class SessionDetailsModel : PageModel
{
    private readonly ApplicationDbContext _db;
    public SessionDetailsModel(ApplicationDbContext db) => _db = db;

    public ConferenceManagement.Models.Session? Session { get; set; }

    public IActionResult OnGet(int id)
    {
        Session = _db.Sessions
            .Include(s => s.Speaker)
            .Include(s => s.Room)
            .FirstOrDefault(s => s.Id == id);

        if (Session == null) return NotFound();
        return Page();
    }
}
