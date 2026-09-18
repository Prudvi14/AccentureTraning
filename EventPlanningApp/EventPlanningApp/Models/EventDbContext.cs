using Microsoft.EntityFrameworkCore;

namespace EventPlanningApp.Models;

public class EventDbContext : DbContext
{
    public EventDbContext()
    {
    }

    public EventDbContext(DbContextOptions<EventDbContext> options) : base(options)
    {
    }

    public virtual DbSet<Event> Events { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=LaptopDB;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }
}