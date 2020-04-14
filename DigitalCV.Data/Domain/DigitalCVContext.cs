using DigitalCV.Data.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DigitalCV.Data.Domain
{
    public class DigitalCVContext : IdentityDbContext<ApplicationUser>
    {
        public DigitalCVContext(DbContextOptions<DigitalCVContext> options)
            : base(options)
        { }

        public DbSet<Education> Educations { get; set; }
        public DbSet<WorkExperience> WorkExperiences { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<ITExperience> ITExperiences { get; set; }
    }
}
