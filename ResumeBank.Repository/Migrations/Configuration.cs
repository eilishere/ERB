namespace ResumeBank.Repository.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ResumeBank.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<ResumeBank.Repository.RBDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ResumeBank.Repository.RBDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Genders.AddOrUpdate(g => g.Id,
                new Gender() { Id = 2, Name = "Male" },
                new Gender() { Id = 1, Name = "Female" }
                );
        }
    }
}
