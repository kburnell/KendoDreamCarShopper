namespace KendoDreamCarShopper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLocationToMake : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Makes", "Location", c => c.String(nullable: false, maxLength: 140));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Makes", "Location");
        }
    }
}
