namespace Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDateTimeToSavedTextTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SavedTexts", "DateTimeOfText", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SavedTexts", "DateTimeOfText");
        }
    }
}
