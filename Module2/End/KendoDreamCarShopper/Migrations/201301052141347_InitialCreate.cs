namespace KendoDreamCarShopper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Makes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 75),
                        ImageUrl = c.String(nullable: false, maxLength: 1024),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Models",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MakeId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 75),
                        Description = c.String(nullable: false, maxLength: 750),
                        EngineType = c.String(nullable: false, maxLength: 75),
                        BreakHorsepower = c.Int(nullable: false),
                        ZeroToSixty = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TopSpeed = c.Int(nullable: false),
                        BasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ImageUrl = c.String(nullable: false, maxLength: 1024),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Makes", t => t.MakeId, cascadeDelete: true)
                .Index(t => t.MakeId);
            
            CreateTable(
                "dbo.Options",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ModelId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 120),
                        SortOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Models", t => t.ModelId, cascadeDelete: true)
                .Index(t => t.ModelId);
            
            CreateTable(
                "dbo.OptionChoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OptionId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 120),
                        SortOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Options", t => t.OptionId, cascadeDelete: true)
                .Index(t => t.OptionId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.OptionChoices", new[] { "OptionId" });
            DropIndex("dbo.Options", new[] { "ModelId" });
            DropIndex("dbo.Models", new[] { "MakeId" });
            DropForeignKey("dbo.OptionChoices", "OptionId", "dbo.Options");
            DropForeignKey("dbo.Options", "ModelId", "dbo.Models");
            DropForeignKey("dbo.Models", "MakeId", "dbo.Makes");
            DropTable("dbo.OptionChoices");
            DropTable("dbo.Options");
            DropTable("dbo.Models");
            DropTable("dbo.Makes");
        }
    }
}
