using ClinicTask.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicTask.DAL
{
    public class AppDbContext:DbContext
    {

       public DbSet<Department> Departments {  get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){ }
    }
}
