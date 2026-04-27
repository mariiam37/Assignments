using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace Assignments
{
    #region Entities

    // Organizer (Data Annotations)
    public class Organizer
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string? CompanyName { get; set; }

        public bool IsVerified { get; set; }

        public OrganizerProfile Profile { get; set; }

        public ICollection<Event> Events { get; set; } = new List<Event>();
    }

    // OrganizerProfile (Data Annotations)
    public class OrganizerProfile
    {
        [Key]
        public int OrganizerId { get; set; }

        public string Bio { get; set; }

        public string Website { get; set; }

        public string LogoUrl { get; set; }

        public Organizer Organizer { get; set; }
    }

    // Event (Fluent API)
    public class Event
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int MaxAttendees { get; set; }

        public int? ParentEventId { get; set; }
        public Event ParentEvent { get; set; }
        public ICollection<Event> Sessions { get; set; } = new List<Event>();

        public int OrganizerId { get; set; }
        public Organizer Organizer { get; set; }

        public ICollection<Registration> Registrations { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime LastModified { get; set; }
    }

    // Attendee (Data Annotations)
    public class Attendee
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public Address Address { get; set; }

        public Badge Badge { get; set; }

        public ICollection<Registration> Registrations { get; set; }
    }

    // Address (Owned)
    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
    }

    // Badge (Fluent API)
    public class Badge
    {
        public int Id { get; set; }

        public string BadgeNumber { get; set; }

        public DateTime IssuedDate { get; set; }

        public string Tier { get; set; }

        public int AttendeeId { get; set; }
        public Attendee Attendee { get; set; }
    }

    // Registration (Separate Config)
    public class Registration
    {
        public int AttendeeId { get; set; }
        public Attendee Attendee { get; set; }

        public int EventId { get; set; }
        public Event Event { get; set; }

        public string Note { get; set; }

        public DateTime RegisteredAt { get; set; }
    }

    #endregion

    #region Configuration Class

    public class RegistrationConfig : IEntityTypeConfiguration<Registration>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Registration> builder)
        {
            builder.HasKey(r => new { r.AttendeeId, r.EventId });

            builder.HasOne(r => r.Attendee)
                .WithMany(a => a.Registrations)
                .HasForeignKey(r => r.AttendeeId);

            builder.HasOne(r => r.Event)
                .WithMany(e => e.Registrations)
                .HasForeignKey(r => r.EventId);

            builder.Property(r => r.RegisteredAt)
                .HasDefaultValueSql("GETDATE()");
        }
    }

    #endregion

    #region DbContext

    public class AppDbContext : DbContext
    {
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<OrganizerProfile> Profiles { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<Badge> Badges { get; set; }
        public DbSet<Registration> Registrations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=.;Database=EventHubDB;Trusted_Connection=True;TrustServerCertificate=True; ");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Organizer ↔ Profile (1-1)
            modelBuilder.Entity<Organizer>()
                .HasOne(o => o.Profile)
                .WithOne(p => p.Organizer)
                .HasForeignKey<OrganizerProfile>(p => p.OrganizerId);

            // Event self-reference
            modelBuilder.Entity<Event>()
                .HasOne(e => e.ParentEvent)
                .WithMany(e => e.Sessions)
                .HasForeignKey(e => e.ParentEventId)
                .OnDelete(DeleteBehavior.Restrict);

            // Event timestamps
            modelBuilder.Entity<Event>()
                .Property(e => e.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Event>()
                .Property(e => e.LastModified)
                .HasDefaultValueSql("GETDATE()");

            // Owned Address
            modelBuilder.Entity<Attendee>()
                .OwnsOne(a => a.Address);

            // Badge 1-1
            modelBuilder.Entity<Badge>()
                .HasOne(b => b.Attendee)
                .WithOne(a => a.Badge)
                .HasForeignKey<Badge>(b => b.AttendeeId);

            // Apply config class
            modelBuilder.ApplyConfiguration(new RegistrationConfig());
        }
    }

    #endregion

    #region Program

    class Program
    {
        static void Main()
        {
            using var context = new AppDbContext();

            Console.WriteLine("Database ready.");
        }
    }

    #endregion
}
