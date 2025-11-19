using ConferenceManagement.Data;
using ConferenceManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ConferenceManagement.Pages.Register;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _db;
    public IndexModel(ApplicationDbContext db) => _db = db;

    [BindProperty]
    public Participant Participant { get; set; } = new();

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        // Attach to first conference for MVP
        var conf = _db.Conferences.OrderBy(c => c.StartDate).FirstOrDefault();
        if (conf == null)
        {
            ModelState.AddModelError(string.Empty, "No conference available to register.");
            return Page();
        }

        Participant.ConferenceId = conf.Id;
        Participant.RegistrationDate = DateTime.UtcNow;
        _db.Participants.Add(Participant);
        _db.SaveChanges();

        return RedirectToPage("/Register/Success");
    }
}
