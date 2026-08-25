using Microsoft.EntityFrameworkCore;
using LaptopCart.Models;

namespace LaptopCart.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<Product> Products { get; set;}
    }
}
