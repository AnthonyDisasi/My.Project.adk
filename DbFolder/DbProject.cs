using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using My.Project.adk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.Project.adk.DbFolder
{
    public class DbProject : IdentityDbContext<User_pro>
    {
        public DbProject(DbContextOptions options) : base(options){ }
        public DbSet<Ecole> Ecole { get; set; }
        public DbSet<Classe> Classe { get; set; }
        public DbSet<Eleve> Eleve { get; set; }

        public DbSet<User_pro> User_Pros { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
