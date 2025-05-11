using ClinicTask.DAL;
using ClinicTask.Models;
using Microsoft.AspNetCore.Identity;
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
		builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
		{
			opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
			opt.User.RequireUniqueEmail = true;
			opt.Password.RequiredLength = 8;
			opt.Lockout.MaxFailedAccessAttempts = 3;
			opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);
		}).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();
		var app = builder.Build();

		app.UseStaticFiles();
		app.UseAuthentication();
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
