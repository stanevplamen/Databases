using ConsoleBlogSystem.Data;
using SampleClass.Models;
using SimpleClasses.Data.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClasses.Client
{
    /// <summary>
    /// Enable-Migrations -EnableAutomaticMigrations
    /// </summary>
    class Program
    {
        static void Main()
        {
           Database.SetInitializer(new MigrateDatabaseToLatestVersion<BlogSystemContext, Configuration>()); // set the migration strategy

           var db = new BlogSystemContext();

           var homework1 = new Homework();
           homework1.Content = "Some solved math tasks";
           var homework2 = new Homework();
           homework2.Content = "Some solved history tasks";

           var material1 = new Material();
           material1.MaterialName = "Math Basics";
           var material2 = new Material();
           material2.MaterialName = "Math Foundementals";
           var material3 = new Material();
           material3.MaterialName = "Math Practising";

           var course1 = new Course();
           course1.CourseName = "Math";
           course1.Description = "First part";
           course1.Homeworks.Add(homework1);
           course1.Homeworks.Add(homework2);
           course1.Materials.Add(material1);
           course1.Materials.Add(material2);
           course1.Materials.Add(material3);
            
           var student1 = new Student();
           student1.StudentName = "Georgi Myshnakov";
           student1.StudentNumber = "05A1223";
           student1.Homeworks.Add(homework1);
           student1.Homeworks.Add(homework2);
           student1.Courses.Add(course1);

           course1.Students.Add(student1);

           db.Homeworks.Add(homework1);
           db.Homeworks.Add(homework2);

           db.Materials.Add(material1);
           db.Materials.Add(material2);
           db.Materials.Add(material3);

           db.Courses.Add(course1);

           db.Students.Add(student1);

           db.SaveChanges();
        }
    }
}
