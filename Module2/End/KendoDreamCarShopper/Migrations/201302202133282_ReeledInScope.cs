namespace KendoDreamCarShopper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReeledInScope : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Options", "ModelId", "dbo.Models");
            DropForeignKey("dbo.OptionChoices", "OptionId", "dbo.Options");
            DropForeignKey("dbo.OrderConfigs", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderConfigs", "OptionId", "dbo.Options");
            DropForeignKey("dbo.OrderConfigs", "OptionChoiceId", "dbo.OptionChoices");
            DropIndex("dbo.Options", new[] { "ModelId" });
            DropIndex("dbo.OptionChoices", new[] { "OptionId" });
            DropIndex("dbo.OrderConfigs", new[] { "OrderId" });
            DropIndex("dbo.OrderConfigs", new[] { "OptionId" });
            DropIndex("dbo.OrderConfigs", new[] { "OptionChoiceId" });
            DropTable("dbo.Options");
            DropTable("dbo.OptionChoices");
            DropTable("dbo.OrderConfigs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OrderConfigs",
                c => new
                    {
                        OrderConfigId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        OptionId = c.Int(nullable: false),
                        OptionChoiceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderConfigId);
            
            CreateTable(
                "dbo.OptionChoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OptionId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 120),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SortOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Options",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ModelId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 120),
                        SortOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.OrderConfigs", "OptionChoiceId");
            CreateIndex("dbo.OrderConfigs", "OptionId");
            CreateIndex("dbo.OrderConfigs", "OrderId");
            CreateIndex("dbo.OptionChoices", "OptionId");
            CreateIndex("dbo.Options", "ModelId");
            AddForeignKey("dbo.OrderConfigs", "OptionChoiceId", "dbo.OptionChoices", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OrderConfigs", "OptionId", "dbo.Options", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OrderConfigs", "OrderId", "dbo.Orders", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OptionChoices", "OptionId", "dbo.Options", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Options", "ModelId", "dbo.Models", "Id", cascadeDelete: true);
        }
    }
}
