namespace Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SavedTexts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TextValue = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SavedTexts");
        }
    }
}
