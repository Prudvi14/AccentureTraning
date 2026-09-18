using Capstone.DAL.Models;
using Capstone.DAL.Repository;
using Microsoft.EntityFrameworkCore;

namespace Capstone.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var dbPath = Path.Combine(
                Directory.GetParent(builder.Environment.ContentRootPath)!.FullName,
                "Capstone.DAL",
                "Database",
                "ServiceDeskDB.db"
            );
            builder.Services.AddDbContext<HelpDeskDbContext>(options =>
                options.UseSqlite($"Data Source={dbPath}"));

            builder.Services.AddScoped<IRepository, Repository>();

            // ENABLE CORS
            var allowedOrigins = "_allowedOrigins";
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: allowedOrigins,
                    policy =>
                    {
                        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                    });
            });
            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();

            //FOR CORS
            app.UseCors(allowedOrigins);
            //FOR CORS
            app.MapControllers();

            // Seed master/reference data (Roles, Status) and a couple of test Users
            // so the app is usable immediately after a fresh migration/deploy.
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<HelpDeskDbContext>();
                SeedData(context);
            }

            app.Run();

            static void SeedData(HelpDeskDbContext context)
            {
                if (!context.Roles.Any())
                {
                    context.Roles.AddRange(
                        new Role { RoleName = "Admin" },
                        new Role { RoleName = "User" }
                    );
                    context.SaveChanges();
                }

                if (!context.Statuses.Any())
                {
                    context.Statuses.AddRange(
                        new Status { Description = "New" },
                        new Status { Description = "Closed" }
                    );
                    context.SaveChanges();
                }

                if (!context.Users.Any())
                {
                    var adminRoleId = context.Roles.First(r => r.RoleName == "Admin").RoleId;
                    var userRoleId = context.Roles.First(r => r.RoleName == "User").RoleId;

                    context.Users.AddRange(
                        new User { UserName = "admin", Password = "Admin@123", CreatedOn = DateTime.Now, RoleId = adminRoleId },
                        new User { UserName = "rahul", Password = "Rahul@123", CreatedOn = DateTime.Now, RoleId = userRoleId }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}