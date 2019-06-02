using WebApplication8.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication8.Data
{
    public class CProjectContext: DbContext
    {
        public CProjectContext(DbContextOptions<CProjectContext> options) : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<CoderProject> CoderProjects { get; set; }
        public DbSet<Coder> Coders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().ToTable("Project");
            modelBuilder.Entity<CoderProject>().ToTable("CoderProject");
            modelBuilder.Entity<Coder>().ToTable("Coder");
        }
    }
}

