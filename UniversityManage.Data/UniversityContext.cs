using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UniversityManage.Model;

namespace UniversityManage.Data
{
    public class UniversityContext : DbContext
    {
        public string _conneection, _migration;

        public UniversityContext(string conn, string mig)
        {
            _conneection = conn;
            _migration = mig;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_conneection,
                    m => m.MigrationsAssembly(_migration) );
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //STUDENT
            builder.Entity<Student>()
                .HasOne(o => o.Departments);

            //INSTRUCTOR
            builder.Entity<Instructor>()
                .HasMany(m => m.Courses)
                .WithOne(o => o.Instructors);

            //STUDENTCOURSES - Many To Many Relationships
            builder.Entity<StudentCourse>()
                .HasKey(key => new { key.StudentId, key.CourseId});

            builder.Entity<StudentCourse>()
                .HasOne(o => o.Students)
                .WithMany(m => m.StudentCourses)
                .HasForeignKey(f => f.StudentId);

            builder.Entity<StudentCourse>()
                .HasOne(o => o.Courses)
                .WithMany(m => m.StudentCourses)
                .HasForeignKey(f => f.CourseId);

            //DEPARTMENT
            builder.Entity<Department>()
                .HasMany(m => m.Students)
                .WithOne(o => o.Departments);

            builder.Entity<Department>()
                .HasMany(m => m.Instructors)
                .WithOne(o => o.Departments);

            builder.Entity<Department>()
                .HasMany(m => m.Courses)
                .WithOne(o => o.Departments);

            //COURSES
            builder.Entity<Course>()
                .HasOne(o => o.Departments);

            builder.Entity<Course>()
                .HasOne(o => o.Instructors);

            base.OnModelCreating(builder);
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }

    }
}
