namespace Practice1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args); // the builder is used to configure the application and its services

            // Add services to the container.
            builder.Services.AddControllersWithViews(); // Add services for controllers and views to the dependency injection container

            var app = builder.Build(); // adds the services to the application and configures the HTTP request pipeline.
            //it builds the application and returns a WebApplication instance that can be used to configure the HTTP request pipeline and run the application.

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
