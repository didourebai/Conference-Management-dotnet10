using ConferenceManagement.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ConferenceManagement.Pages;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _db;

    public IndexModel(ApplicationDbContext db)
    {
        _db = db;
    }

    public ConferenceManagement.Models.Conference? Conference { get; set; }

    public void OnGet()
    {
        Conference = _db.Conferences.OrderBy(c => c.StartDate).FirstOrDefault();
    }
}
