using Microsoft.EntityFrameworkCore;

namespace ArcyWriter.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }

#if !EF_MIGRATION
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
#else
        public AppDbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={Path.Combine(Directory.GetCurrentDirectory(), "writerproject.db")}");
        }   
#endif

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
