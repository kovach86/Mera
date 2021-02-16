namespace Core.Migrations
{
    using Core.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Core.DatabaseLayer.SavedTextDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Core.DatabaseLayer.SavedTextDbContext";
        }

        protected override void Seed(Core.DatabaseLayer.SavedTextDbContext context)
        {
          
        }
    }
}
