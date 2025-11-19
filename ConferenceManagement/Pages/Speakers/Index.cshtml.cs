using ConferenceManagement.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ConferenceManagement.Pages.Speakers;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _db;
    public IndexModel(ApplicationDbContext db) => _db = db;

    public List<ConferenceManagement.Models.Speaker> Speakers { get; set; } = new();

    public void OnGet()
    {
        Speakers = _db.Speakers.OrderBy(s => s.LastName).ToList();
    }
}
