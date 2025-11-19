Minimal data model and mapping for Conference Management (MVP)

Entities (in `ConferenceManagement.Models`):
- `Conference` — Id, Name, Description, Location, StartDate, EndDate, Sessions, Participants
- `Speaker` — Id, FirstName, LastName, Email, Bio, Organization, PhotoUrl
- `Room` — Id, Name, Capacity
- `Session` — Id, ConferenceId, Title, Abstract, SpeakerId, RoomId, StartTime, EndTime, SessionType
- `Participant` — Id, ConferenceId, FirstName, LastName, Email, RegistrationDate

DbContext:
- `ConferenceManagement.Data.ApplicationDbContext` with DbSet for each entity and string conversion for `SessionType` enum.

Configuration:
- Uses SQLite by default with connection string in `appsettings.json` (`Data Source=conference.db`).

Startup/seed:
- `Program.cs` registers the `ApplicationDbContext` and seeds a small sample conference, speaker, room, session and participant if the database is empty.

Suggested Razor Pages area map (MVP):
- Area: Admin
  - `/Admin/Conferences/Index`
  - `/Admin/Conferences/Create`
  - `/Admin/Conferences/Edit/{id}`
  - `/Admin/Rooms/*`
  - `/Admin/Speakers/*`
- Area: Organizer
  - `/Organizer/Conference/{id}/Dashboard`
  - `/Organizer/Conference/{id}/Sessions`
  - `/Organizer/Conference/{id}/Sessions/Create`
  - `/Organizer/Conference/{id}/Speakers`
  - `/Organizer/Conference/{id}/Schedule`
  - `/Organizer/Conference/{id}/Participants`
- Public
  - `/` — List of conferences
  - `/Conference/{slug}` — Overview
  - `/Conference/{slug}/Program` — Schedule
  - `/Conference/{slug}/Session/{id}` — Session details
  - `/Conference/{slug}/Speakers` — Speaker list
  - `/Conference/{slug}/Register` — Participant registration

Next steps:
- Add migrations and DB updates (or rely on EnsureCreated for MVP)
- Scaffold simple Razor Pages per area and wire up CRUD where needed
- Add authentication/authorization for Admin/Organizer/Speaker/Participant roles
