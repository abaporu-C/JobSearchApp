﻿using JobSearchApp.Models;
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

        public DbSet<ApplicationDocument> ApplicationDocuments { get; set; }

        public DbSet<Document> Documents { get; set; }

        public DbSet<DocumentType> DocumentTypes { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Key Constraints
            modelBuilder.Entity<ApplicationDocument>()
                .HasKey(ad => new { ad.ApplicationID, ad.DocumentID });


            //Delete Behaviour

            modelBuilder.Entity<ApplicationDocument>()
                .HasOne(d => d.Application)
                .WithMany(a => a.ApplicationDocuments)
                .HasForeignKey(d => d.ApplicationID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Document>()
                .HasOne(d => d.User)
                .WithMany(a => a.Documents)
                .HasForeignKey(d => d.UserID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Document>()
                .HasOne(d => d.DocumentType)
                .WithMany(dt => dt.Documents)
                .HasForeignKey(d => d.DocumentTypeID)
                .OnDelete(DeleteBehavior.Restrict);

            //Seed Data
            modelBuilder.Entity<User>()
                        .HasData(
                            new User { ID = 1, Name = "Mario Feldman", UserName = "Mario", Email = "mail@mail.com", JoinedOn = DateTime.Now },
                            new User { ID = 2, Name = "Maria Feldman", UserName = "Maria", Email = "mail2@mail.com", JoinedOn = DateTime.Now },
                            new User { ID = 3, Name = "Steven Nakamura", UserName = "Steven", Email = "mail3@mail.com", JoinedOn = DateTime.Now },
                            new User { ID = 4, Name = "Gaia Nakamura", UserName = "Gaia", Email = "mail4@mail.com", JoinedOn = DateTime.Now }
                        );

            modelBuilder.Entity<Application>()
                        .HasData(
                            new Application { ID = 1, URL = "https://www.eluta.ca/spl/developer-developer-relations-ios-d91196f0709e576494e28922ade3e69a?utm_campaign=google_jobs_apply&utm_source=google_jobs_apply&utm_medium=organic", Employer = "Google Canada", JobTitle = "Developer", HasApplied = true, ApplicationDate = DateTime.Now, HasInterviewed = false, InterviewDate = DateTime.Parse("06/06/2022"), Hired = false, HireDate = null, Notes = "Prepare for interview reading company's website and gathering information about the position.", UserID = 1 }
                        );
        }
    }
}
