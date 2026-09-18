using Microsoft.EntityFrameworkCore;

namespace EventPlanning.DataAccess
{
    public class EventDbContext : DbContext
    {
        public EventDbContext(DbContextOptions<EventDbContext> options)
            : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
    }
}