# Conference-Management-dotnet10

The conference management application is designed to serve as a complete platform for planning, organizing, and running professional events. At its core, the system empowers organizers to create and configure one or multiple conferences, each with its own structure, identity, and schedule. Organizers can define essential components such as tracks, rooms, and time slots, enabling them to build a well-structured and conflict-free program. Speakers can submit proposals, manage their profiles, and upload materials, while organizers review, approve, and schedule sessions into specific rooms and time periods. Participants can register for the event, personalize their profiles, explore the full conference program, and even build their own tailored agenda from available sessions. The application also offers convenient public access to schedules, speaker details, and session information. Features like calendar integration (ICS export), email notifications, and dashboard messages help keep attendees informed and engaged. Meanwhile, system administrators maintain overall control of users, permissions, and global configurations. With built-in analytics to track registrations, session counts, and distributions across tracks, the platform provides everything needed to manage a modern conference from planning to execution.
Minimal data model and mapping for Conference Management (MVP).
## How? What do we need?

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

