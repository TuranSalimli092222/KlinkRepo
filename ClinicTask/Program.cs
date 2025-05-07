using ClinicTask.DAL;
using Microsoft.EntityFrameworkCore;

namespace ClinicTask;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllersWithViews();
        string connectionStr = "Server= DESKTOP-D9KR3VR\\SQLEXPRESS;Database=KlinikaAppDb;Trusted_Connection=True;TrustServerCertificate = True";

        builder.Services.AddDbContext<AppDbContext>(opt =>
        opt.UseSqlServer(connectionStr));
        var app = builder.Build();
        app.UseStaticFiles();
        app.MapControllerRoute(
              name: "areas",
              pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
            );
        app.MapControllerRoute(
name: "default",
pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}
