using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleBlogSystem.Models;
using ConsoleBlogSystem.Data;
using System.Data.Entity;
using ConsoleBlogSystem.Data.Migrations;

namespace ConsoleBlogSystem.Client
{
    internal class Program
    {
        static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BlogSystemContext, Configuration>()); // set the migration strategu
            
            var db = new BlogSystemContext();
            var category = new Category() { Parent = null, Name = "Database course", };
            db.Categories.Add(category);

            var post = new Post();
            post.Title = "Срока на домашните";
            post.Content = "Моля удължете срока на домашните";
            post.Type = PostType.Normal;
            post.Category = category;
            post.Tags.Add(new Tag { Text = "домашни" });
            post.Tags.Add(new Tag { Text = "срок" });
            db.Posts.Add(post);
            db.SaveChanges();

        }
    }
}
