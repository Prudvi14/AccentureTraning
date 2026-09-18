using Capstone.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Capstone.DAL.Repository
{
    public class HelpDeskDbContext : DbContext
    {
        public HelpDeskDbContext(DbContextOptions<HelpDeskDbContext> options)
            : base(options)
        {
        }

        public class HelpDeskDbContextFactory : IDesignTimeDbContextFactory<HelpDeskDbContext>
        {
            public HelpDeskDbContext CreateDbContext(string[] args)
            {
                var options = new DbContextOptionsBuilder<HelpDeskDbContext>()
                    .UseSqlite("Data Source=Database\\ServiceDeskDB.db")
                    .Options;

                return new HelpDeskDbContext(options);
            }
        }

        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<ServiceRequest> ServiceRequests { get; set; } = null!;
        public DbSet<Status> Statuses { get; set; } = null!;
    }
}