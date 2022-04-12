using JobSearchApp.Models;
using Microsoft.EntityFrameworkCore;

namespace JobSearchApp.Data
{
    public class AppDbContext : DbContext
    {

        /// <summary>
        /// Magic strings.
        /// </summary>
        public static readonly string AppDb = nameof(AppDb).ToLower();

        public AppDbContext (DbContextOptions<AppDbContext> options):base(options)
        {

        }

        public DbSet<Application> Applications { get; set; }

        public DbSet<Document> Documents { get; set; }

        public DbSet<DocumentType> DocumentTypes { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Document>()
                .HasOne(d => d.Application)
                .WithMany(a => a.Documents)
                .HasForeignKey(d => d.ApplicationID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
