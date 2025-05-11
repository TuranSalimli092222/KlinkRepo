using ClinicTask.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClinicTask.DAL
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {

       public DbSet<Department> Departments {  get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){ }
    }
}
