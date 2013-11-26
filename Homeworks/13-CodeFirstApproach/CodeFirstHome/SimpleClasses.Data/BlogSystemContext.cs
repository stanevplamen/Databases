using SampleClass.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBlogSystem.Data
{
    public class BlogSystemContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<Course> Courses { get; set; }

        public BlogSystemContext()
            : base("SimpleClassesDb")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().Property(x => x.CourseName).IsFixedLength().HasMaxLength(255);
            modelBuilder.Entity<Student>().Property(x => x.StudentName).IsFixedLength().HasMaxLength(50);
            modelBuilder.Entity<Material>().Property(x => x.MaterialName).IsFixedLength().HasMaxLength(50);
            modelBuilder.Entity<Course>().Property(x => x.CourseName).IsFixedLength().HasMaxLength(255);
            base.OnModelCreating(modelBuilder);
        }
    }
}
