namespace KendoDreamCarShopper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModelValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Models", "Description", c => c.String(nullable: false, maxLength: 2000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Models", "Description", c => c.String(nullable: false, maxLength: 750));
        }
    }
}
