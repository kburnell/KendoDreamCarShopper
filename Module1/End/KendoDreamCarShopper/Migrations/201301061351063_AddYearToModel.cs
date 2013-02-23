namespace KendoDreamCarShopper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddYearToModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Models", "Year", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Models", "Year");
        }
    }
}
