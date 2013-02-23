namespace KendoDreamCarShopper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelImage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ModelImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ModelId = c.Int(nullable: false),
                        HighResolutionUrl = c.String(nullable: false, maxLength: 1024),
                        LowResolutionUrl = c.String(nullable: false, maxLength: 1024),
                        Order = c.Int(nullable: false),
                        ShortDescription = c.String(nullable: false),
                        LongDescription = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Models", t => t.ModelId, cascadeDelete: true)
                .Index(t => t.ModelId);
            
            DropColumn("dbo.Models", "ImageUrl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Models", "ImageUrl", c => c.String(nullable: false, maxLength: 1024));
            DropIndex("dbo.ModelImages", new[] { "ModelId" });
            DropForeignKey("dbo.ModelImages", "ModelId", "dbo.Models");
            DropTable("dbo.ModelImages");
        }
    }
}
