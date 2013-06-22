namespace KendoDreamCarShopper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TroubleShootingValidationError : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ModelImages", "HighResolutionUrl", c => c.String());
            AlterColumn("dbo.ModelImages", "LowResolutionUrl", c => c.String());
            AlterColumn("dbo.ModelImages", "ShortDescription", c => c.String());
            AlterColumn("dbo.ModelImages", "LongDescription", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ModelImages", "LongDescription", c => c.String(nullable: false));
            AlterColumn("dbo.ModelImages", "ShortDescription", c => c.String(nullable: false));
            AlterColumn("dbo.ModelImages", "LowResolutionUrl", c => c.String(nullable: false, maxLength: 1024));
            AlterColumn("dbo.ModelImages", "HighResolutionUrl", c => c.String(nullable: false, maxLength: 1024));
        }
    }
}
