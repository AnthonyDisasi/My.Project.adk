using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using My.Project.adk.Models;

namespace My.Project.adk.DataContext
{
    public class ProjectDbContext : IdentityDbContext<User_pro>
    {
        public ProjectDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Ecole> Ecoles { get; set; }
        public DbSet<Classe> Classes { get; set; }
        public DbSet<Eleve> Eleves { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
