using ConferenceManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace ConferenceManagement.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Conference> Conferences => Set<Conference>();
    public DbSet<Speaker> Speakers => Set<Speaker>();
    public DbSet<Room> Rooms => Set<Room>();
    public DbSet<Session> Sessions => Set<Session>();
    public DbSet<Participant> Participants => Set<Participant>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Store SessionType enum as string for readability
        modelBuilder.Entity<Session>()
            .Property(s => s.SessionType)
            .HasConversion<string>();
    }
}
