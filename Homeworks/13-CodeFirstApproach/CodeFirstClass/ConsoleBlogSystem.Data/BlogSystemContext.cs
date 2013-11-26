using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleBlogSystem.Models;

namespace ConsoleBlogSystem.Data
{
    public class BlogSystemContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostAnswer> PostAnswers { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public BlogSystemContext()
            : base("ForumDb")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().Property(x => x.Content).IsFixedLength().HasMaxLength(255);
            base.OnModelCreating(modelBuilder);
        }

    }
}
