namespace SimpleClasses.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using SampleClass.Models;

    public sealed class Configuration : DbMigrationsConfiguration<ConsoleBlogSystem.Data.BlogSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "ConsoleBlogSystem.Data.BlogSystemContext";
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ConsoleBlogSystem.Data.BlogSystemContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Materials.AddOrUpdate(new Material { MaterialName = "physycs" });
            context.Materials.AddOrUpdate(new Material { MaterialName = "chemistry" });

            var course2 = new Course();
            course2.CourseName = "Sport meets Phylosophy";
            course2.Materials.Add(new Material { MaterialName = "phylosophy" });
            course2.Materials.Add(new Material { MaterialName = "sport" });

            var student2 = new Student();
            student2.StudentName = "Kiro Shtangata";
            student2.Courses.Add(course2);

            context.Courses.AddOrUpdate(course2);
            context.Students.AddOrUpdate(student2);

            student2.StudentName = "Kiro Ivanov - Shtangata";
            student2.StudentNumber = "12A1205";

            context.Students.AddOrUpdate(student2);
        }
    }
}
