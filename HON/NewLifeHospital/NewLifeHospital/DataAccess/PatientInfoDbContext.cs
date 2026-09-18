using Microsoft.EntityFrameworkCore;
using NewLifeHospital.Models;

namespace NewLifeHospital.DataAccess
{
    public class PatientInfoDbContext : DbContext
    {
        public PatientInfoDbContext(
            DbContextOptions<PatientInfoDbContext> options)
            : base(options)
        {
        }

        public DbSet<PatientInfoDetail> PatientInfoDetails { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Server=(localdb)\\mssqllocaldb;Database=NewLifeHospitalDB;Trusted_Connection=True;TrustServerCertificate=True");
            }
        }
    }
}