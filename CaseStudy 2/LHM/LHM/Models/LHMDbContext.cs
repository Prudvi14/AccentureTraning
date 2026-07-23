using Microsoft.EntityFrameworkCore;

namespace LHM.Models
{
    public class LHMDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\mssqllocaldb;Database=LHMDb;Trusted_Connection=True;MultipleActiveResultSets=true",
                options => options.EnableRetryOnFailure()
            );
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
    }
}