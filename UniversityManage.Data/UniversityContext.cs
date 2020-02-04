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
            //relationships here
            //DEPARTMENT
            //builder.Entity<Department>()
            //    .HasMany(a => a.InstructorsDepartment)
            //    .WithOne(b => b.DepartmentInstructor);
            builder.Entity<Department>()
                .HasMany(a => a.StudentsDepartment)
                .WithOne(b => b.DepartmentStudent);

            //STUDENT
            builder.Entity<Student>()
                .HasOne(a => a.DepartmentStudent);

            base.OnModelCreating(builder);
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }

    }
}
