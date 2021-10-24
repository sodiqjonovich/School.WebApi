using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using School.Webapi.Configures;
using School.Webapi.Entities.Models;

namespace School.Webapi.Data
{
    public class AppDBContext: IdentityDbContext<User>
    {
        public DbSet<New> News { get; set; }
        
        public DbSet<Group> Groups { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Pupil> Pupils { get; set; }

        public DbSet<Information> Informations { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.Seed();
        }
    }
}
