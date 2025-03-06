using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace THI_BANG_LAI_XE.Models;

public partial class ThiBangLaiXeContext : DbContext
{
    public ThiBangLaiXeContext()
    {
    }

    public ThiBangLaiXeContext(DbContextOptions<ThiBangLaiXeContext> options)
        : base(options)
    {
    }
    public virtual DbSet<Answer> Answers { get; set; }
    public virtual DbSet<Certificate> Certificates { get; set; }
    public virtual DbSet<Course> Courses { get; set; }
    public virtual DbSet<Exam> Exams { get; set; }
    public virtual DbSet<ExamPaper> ExamPapers { get; set; }
    public virtual DbSet<Question> Questions { get; set; }
    public virtual DbSet<Registration> Registrations { get; set; }
    public virtual DbSet<Result> Results { get; set; }
    public virtual DbSet<Role> Roles { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<UserSelectedAnswer> UserSelectedAnswers { get; set; }
    public virtual DbSet<CoursesDocumentation> CoursesDocumentations { get; set; }
    public virtual DbSet<ExamPapersSelected> ExamPapersSelecteds { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var builder = new ConfigurationBuilder();
        builder.SetBasePath(Directory.GetCurrentDirectory());
        builder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        var configuration = builder.Build();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("Default"));
    }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<Answer>(entity =>
    //    {
    //        entity.HasOne(d => d.Question).WithMany(p => p.Answers)
    //            .HasForeignKey(d => d.QuestionId)
    //            .OnDelete(DeleteBehavior.ClientSetNull)
    //            .HasConstraintName("FK_Answers_Questions");
    //    });

    //    modelBuilder.Entity<Certificate>(entity =>
    //    {
    //        entity.HasKey(e => e.CertificatesId);

    //        entity.Property(e => e.CertificateCode).HasMaxLength(50);

    //        entity.HasOne(d => d.User).WithMany(p => p.Certificates)
    //            .HasForeignKey(d => d.UserId)
    //            .OnDelete(DeleteBehavior.ClientSetNull)
    //            .HasConstraintName("FK_Certificates_Users");
    //    });

    //    modelBuilder.Entity<Course>(entity =>
    //    {
    //        entity.Property(e => e.CourseName).HasMaxLength(100);
    //        entity.Property(e => e.CreateDate).HasColumnType("datetime");
    //        entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

    //        entity.HasOne(d => d.Teacher).WithMany(p => p.Courses)
    //            .HasForeignKey(d => d.TeacherId)
    //            .OnDelete(DeleteBehavior.ClientSetNull)
    //            .HasConstraintName("FK_Courses_Users");

    //        entity.HasMany(d => d.ExamPapers).WithMany(p => p.Courses)
    //            .UsingEntity<Dictionary<string, object>>(
    //                "CoursesDocumentation",
    //                r => r.HasOne<ExamPaper>().WithMany()
    //                    .HasForeignKey("ExamPaperId")
    //                    .OnDelete(DeleteBehavior.ClientSetNull)
    //                    .HasConstraintName("FK_CoursesDocumentation_ExamPapers"),
    //                l => l.HasOne<Course>().WithMany()
    //                    .HasForeignKey("CourseId")
    //                    .OnDelete(DeleteBehavior.ClientSetNull)
    //                    .HasConstraintName("FK_CoursesDocumentation_Courses"),
    //                j =>
    //                {
    //                    j.HasKey("CourseId", "ExamPaperId");
    //                    j.ToTable("CoursesDocumentation");
    //                });
    //    });

    //    modelBuilder.Entity<Exam>(entity =>
    //    {
    //        entity.Property(e => e.CourseId).HasColumnName("CourseID");
    //        entity.Property(e => e.DateCreated)
    //            .HasMaxLength(10)
    //            .IsFixedLength();
    //        entity.Property(e => e.Room).HasMaxLength(50);

    //        entity.HasOne(d => d.Course).WithMany(p => p.Exams)
    //            .HasForeignKey(d => d.CourseId)
    //            .OnDelete(DeleteBehavior.ClientSetNull)
    //            .HasConstraintName("FK_Exams_Courses");

    //        entity.HasMany(d => d.ExamPapers).WithMany(p => p.Exams)
    //            .UsingEntity<Dictionary<string, object>>(
    //                "ExamPapersSelected",
    //                r => r.HasOne<ExamPaper>().WithMany()
    //                    .HasForeignKey("ExamPaperId")
    //                    .OnDelete(DeleteBehavior.ClientSetNull)
    //                    .HasConstraintName("FK_ExamPapersSelected_ExamPapers"),
    //                l => l.HasOne<Exam>().WithMany()
    //                    .HasForeignKey("ExamId")
    //                    .OnDelete(DeleteBehavior.ClientSetNull)
    //                    .HasConstraintName("FK_ExamPapersSelected_Exams"),
    //                j =>
    //                {
    //                    j.HasKey("ExamId", "ExamPaperId");
    //                    j.ToTable("ExamPapersSelected");
    //                });
    //    });

    //    modelBuilder.Entity<ExamPaper>(entity =>
    //    {
    //        entity.Property(e => e.CreateDate).HasColumnType("datetime");
    //        entity.Property(e => e.ExamPaperName).HasMaxLength(100);
    //    });

    //    modelBuilder.Entity<Question>(entity =>
    //    {
    //        entity.HasOne(d => d.ExamPaper).WithMany(p => p.Questions)
    //            .HasForeignKey(d => d.ExamPaperId)
    //            .OnDelete(DeleteBehavior.ClientSetNull)
    //            .HasConstraintName("FK_Questions_ExamPapers");
    //    });

    //    modelBuilder.Entity<Registration>(entity =>
    //    {
    //        entity.Property(e => e.DateCreated).HasColumnType("datetime");

    //        entity.HasOne(d => d.Course).WithMany(p => p.Registrations)
    //            .HasForeignKey(d => d.CourseId)
    //            .HasConstraintName("FK_Registrations_Courses");

    //        entity.HasOne(d => d.User).WithMany(p => p.Registrations)
    //            .HasForeignKey(d => d.UserId)
    //            .OnDelete(DeleteBehavior.ClientSetNull)
    //            .HasConstraintName("FK_Registrations_Users");
    //    });

    //    modelBuilder.Entity<Result>(entity =>
    //    {
    //        entity.Property(e => e.DateCreated).HasColumnType("datetime");
    //        entity.Property(e => e.Score).HasColumnType("decimal(5, 2)");

    //        entity.HasOne(d => d.Exam).WithMany(p => p.Results)
    //            .HasForeignKey(d => d.ExamId)
    //            .OnDelete(DeleteBehavior.ClientSetNull)
    //            .HasConstraintName("FK_Results_Exams");

    //        entity.HasOne(d => d.User).WithMany(p => p.Results)
    //            .HasForeignKey(d => d.UserId)
    //            .OnDelete(DeleteBehavior.ClientSetNull)
    //            .HasConstraintName("FK_Results_Users");
    //    });

    //    modelBuilder.Entity<Role>(entity =>
    //    {
    //        entity.Property(e => e.RoleName)
    //            .HasMaxLength(10)
    //            .IsFixedLength();
    //    });

    //    modelBuilder.Entity<User>(entity =>
    //    {
    //        entity.Property(e => e.Class).HasMaxLength(50);
    //        entity.Property(e => e.DateCreated).HasColumnType("datetime");
    //        entity.Property(e => e.Email).HasMaxLength(100);
    //        entity.Property(e => e.FullName).HasMaxLength(100);
    //        entity.Property(e => e.Password).HasMaxLength(255);
    //        entity.Property(e => e.Phone).HasMaxLength(15);
    //        entity.Property(e => e.School).HasMaxLength(100);

    //        entity.HasOne(d => d.RoleNavigation).WithMany(p => p.Users)
    //            .HasForeignKey(d => d.Role)
    //            .OnDelete(DeleteBehavior.ClientSetNull)
    //            .HasConstraintName("FK_Users_Roles");
    //    });

    //    modelBuilder.Entity<UserSelectedAnswer>(entity =>
    //    {
    //        entity.HasKey(e => e.SelectedId);

    //        entity.ToTable("UserSelectedAnswer");

    //        entity.HasOne(d => d.Answer).WithMany(p => p.UserSelectedAnswers)
    //            .HasForeignKey(d => d.AnswerId)
    //            .OnDelete(DeleteBehavior.ClientSetNull)
    //            .HasConstraintName("FK_UserSelectedAnswer_Answers");

    //        entity.HasOne(d => d.Exam).WithMany(p => p.UserSelectedAnswers)
    //            .HasForeignKey(d => d.ExamId)
    //            .OnDelete(DeleteBehavior.ClientSetNull)
    //            .HasConstraintName("FK_UserSelectedAnswer_Exams");

    //        entity.HasOne(d => d.ExamPaper).WithMany(p => p.UserSelectedAnswers)
    //            .HasForeignKey(d => d.ExamPaperId)
    //            .OnDelete(DeleteBehavior.ClientSetNull)
    //            .HasConstraintName("FK_UserSelectedAnswer_ExamPapers");

    //        entity.HasOne(d => d.User).WithMany(p => p.UserSelectedAnswers)
    //            .HasForeignKey(d => d.UserId)
    //            .OnDelete(DeleteBehavior.ClientSetNull)
    //            .HasConstraintName("FK_UserSelectedAnswer_Users");
    //    });

    //    OnModelCreatingPartial(modelBuilder);
    //}

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
