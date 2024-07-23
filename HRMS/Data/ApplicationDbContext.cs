using HRMS.Models;
using HRMS.WithoutUI;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace HRMS.Data
{
    public class ApplicationDbContext:DbContext
    
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) { }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Full_Forms> Core_FullForms { get; set; }
        public DbSet<Vacancies> Comm_Vacancies { get; set; }
        public DbSet<Experience> Experiences { get; set; }
    }
}
