namespace KendoDreamCarShopper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TroubleShootingValidationError2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ModelImages", "HighResolutionUrl", c => c.String(nullable: false, maxLength: 1024));
            AlterColumn("dbo.ModelImages", "LowResolutionUrl", c => c.String(nullable: false, maxLength: 1024));
            AlterColumn("dbo.ModelImages", "ShortDescription", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.ModelImages", "LongDescription", c => c.String(nullable: false, maxLength: 480));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ModelImages", "LongDescription", c => c.String());
            AlterColumn("dbo.ModelImages", "ShortDescription", c => c.String());
            AlterColumn("dbo.ModelImages", "LowResolutionUrl", c => c.String());
            AlterColumn("dbo.ModelImages", "HighResolutionUrl", c => c.String());
        }
    }
}
