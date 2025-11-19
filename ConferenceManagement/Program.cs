
using ConferenceManagement.Data;
using ConferenceManagement.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Configure EF Core (SQLite) using connection string from configuration
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

// Ensure database is created and seed minimal sample data for MVP
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var db = services.GetRequiredService<ApplicationDbContext>();
        db.Database.EnsureCreated();

        if (!db.Conferences.Any())
        {
            var conference = new Conference
            {
                Name = "Sample Conference 2025",
                Description = "A minimal seeded conference",
                Location = "Virtual",
                StartDate = DateTime.UtcNow.Date,
                EndDate = DateTime.UtcNow.Date.AddDays(2)
            };

            var speaker = new Speaker
            {
                FirstName = "Hamida",
                LastName = "Rebai",
                Email = "hamida@example.org",
                Bio = "Keynote speaker",
                Organization = "Example Organisation"
            };

            var room = new Room
            {
                Name = "Main Hall",
                Capacity = 200
            };

            var session = new Session
            {
                Title = "Intro to the Conference",
                Abstract = "Welcome and overview",
                SessionType = SessionType.Talk,
                StartTime = DateTime.UtcNow.AddHours(1),
                EndTime = DateTime.UtcNow.AddHours(2),
                Speaker = speaker,
                Room = room,
                Conference = conference
            };

            var participant = new Participant
            {
                FirstName = "Rayen",
                LastName = "Trabelsi",
                Email = "rayen@example.org",
                RegistrationDate = DateTime.UtcNow,
                Conference = conference
            };

            db.Conferences.Add(conference);
            db.Speakers.Add(speaker);
            db.Rooms.Add(room);
            db.Sessions.Add(session);
            db.Participants.Add(participant);
            db.SaveChanges();
        }
    }
    catch (Exception ex)
    {
        // Fail silently for now; in real app log the error
        Console.WriteLine($"Error seeding database: {ex.Message}");
    }
}

app.Run();
