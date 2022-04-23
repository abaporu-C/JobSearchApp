﻿// <auto-generated />
using System;
using JobSearchApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JobSearchApp.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.4");

            modelBuilder.Entity("JobSearchApp.Models.Application", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("ApplicationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Employer")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("HasApplied")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("HasInterviewed")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("HireDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Hired")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("InterviewDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UserID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("Applications");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            ApplicationDate = new DateTime(2022, 4, 22, 13, 46, 16, 913, DateTimeKind.Local).AddTicks(2790),
                            Category = "Software Developer",
                            Employer = "Google Canada",
                            HasApplied = true,
                            HasInterviewed = false,
                            Hired = false,
                            InterviewDate = new DateTime(2022, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            JobTitle = "Developer",
                            Notes = "Prepare for interview reading company's website and gathering information about the position.",
                            URL = "https://www.eluta.ca/spl/developer-developer-relations-ios-d91196f0709e576494e28922ade3e69a?utm_campaign=google_jobs_apply&utm_source=google_jobs_apply&utm_medium=organic",
                            UserID = 1
                        });
                });

            modelBuilder.Entity("JobSearchApp.Models.ApplicationDocument", b =>
                {
                    b.Property<int>("ApplicationID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DocumentID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ApplicationID", "DocumentID");

                    b.HasIndex("DocumentID");

                    b.ToTable("ApplicationDocuments");
                });

            modelBuilder.Entity("JobSearchApp.Models.DocumentCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UserID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("DocumentCategories");
                });

            modelBuilder.Entity("JobSearchApp.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("JoinedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Email = "mail@mail.com",
                            JoinedOn = new DateTime(2022, 4, 22, 13, 46, 16, 913, DateTimeKind.Local).AddTicks(2644),
                            Name = "Mario Feldman"
                        },
                        new
                        {
                            ID = 2,
                            Email = "mail2@mail.com",
                            JoinedOn = new DateTime(2022, 4, 22, 13, 46, 16, 913, DateTimeKind.Local).AddTicks(2674),
                            Name = "Maria Feldman"
                        },
                        new
                        {
                            ID = 3,
                            Email = "mail3@mail.com",
                            JoinedOn = new DateTime(2022, 4, 22, 13, 46, 16, 913, DateTimeKind.Local).AddTicks(2675),
                            Name = "Steven Nakamura"
                        },
                        new
                        {
                            ID = 4,
                            Email = "mail4@mail.com",
                            JoinedOn = new DateTime(2022, 4, 22, 13, 46, 16, 913, DateTimeKind.Local).AddTicks(2676),
                            Name = "Gaia Nakamura"
                        });
                });

            modelBuilder.Entity("JobSearchApp.Models.Utils.FileContent", b =>
                {
                    b.Property<int>("FileContentID")
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("Content")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<string>("MimeType")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.HasKey("FileContentID");

                    b.ToTable("FileContent");
                });

            modelBuilder.Entity("JobSearchApp.Models.Utils.UploadedFile", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("UploadedFile");

                    b.HasDiscriminator<string>("Discriminator").HasValue("UploadedFile");
                });

            modelBuilder.Entity("JobSearchApp.Models.Document", b =>
                {
                    b.HasBaseType("JobSearchApp.Models.Utils.UploadedFile");

                    b.Property<int>("DocumentCategoryID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UserID")
                        .HasColumnType("INTEGER");

                    b.HasIndex("DocumentCategoryID");

                    b.HasIndex("UserID");

                    b.HasDiscriminator().HasValue("Document");
                });

            modelBuilder.Entity("JobSearchApp.Models.Application", b =>
                {
                    b.HasOne("JobSearchApp.Models.User", "User")
                        .WithMany("Applications")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("JobSearchApp.Models.ApplicationDocument", b =>
                {
                    b.HasOne("JobSearchApp.Models.Application", "Application")
                        .WithMany("ApplicationDocuments")
                        .HasForeignKey("ApplicationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobSearchApp.Models.Document", "Document")
                        .WithMany("ApplicationDocuments")
                        .HasForeignKey("DocumentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Application");

                    b.Navigation("Document");
                });

            modelBuilder.Entity("JobSearchApp.Models.DocumentCategory", b =>
                {
                    b.HasOne("JobSearchApp.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("JobSearchApp.Models.Utils.FileContent", b =>
                {
                    b.HasOne("JobSearchApp.Models.Utils.UploadedFile", "UploadedFile")
                        .WithOne("FileContent")
                        .HasForeignKey("JobSearchApp.Models.Utils.FileContent", "FileContentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UploadedFile");
                });

            modelBuilder.Entity("JobSearchApp.Models.Document", b =>
                {
                    b.HasOne("JobSearchApp.Models.DocumentCategory", "DocumentCategory")
                        .WithMany("Documents")
                        .HasForeignKey("DocumentCategoryID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("JobSearchApp.Models.User", "User")
                        .WithMany("Documents")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DocumentCategory");

                    b.Navigation("User");
                });

            modelBuilder.Entity("JobSearchApp.Models.Application", b =>
                {
                    b.Navigation("ApplicationDocuments");
                });

            modelBuilder.Entity("JobSearchApp.Models.DocumentCategory", b =>
                {
                    b.Navigation("Documents");
                });

            modelBuilder.Entity("JobSearchApp.Models.User", b =>
                {
                    b.Navigation("Applications");

                    b.Navigation("Documents");
                });

            modelBuilder.Entity("JobSearchApp.Models.Utils.UploadedFile", b =>
                {
                    b.Navigation("FileContent")
                        .IsRequired();
                });

            modelBuilder.Entity("JobSearchApp.Models.Document", b =>
                {
                    b.Navigation("ApplicationDocuments");
                });
#pragma warning restore 612, 618
        }
    }
}
