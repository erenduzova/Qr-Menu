using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QrMenu.Data;
namespace QrMenu
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<QrMenuContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("QrMenuContext") ?? throw new InvalidOperationException("Connection string 'QrMenuContext' not found.")));

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddSession();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.UseSession();

            app.Run();
        }
    }
}