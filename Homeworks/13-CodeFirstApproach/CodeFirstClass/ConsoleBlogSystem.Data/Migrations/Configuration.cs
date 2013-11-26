namespace ConsoleBlogSystem.Data.Migrations
{
    using ConsoleBlogSystem.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<BlogSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
           ContextKey = "ConsoleBlogSystem.Data.BlogSystemContext";
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(BlogSystemContext context)
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
            context.Tags.AddOrUpdate(new Tag { Text = "срок" });
            context.Tags.AddOrUpdate(new Tag { Text = "форум" });

        }
    }
}
