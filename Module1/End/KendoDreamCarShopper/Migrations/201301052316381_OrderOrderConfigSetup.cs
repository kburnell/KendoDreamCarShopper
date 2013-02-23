namespace KendoDreamCarShopper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderOrderConfigSetup : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.OrderConfigId)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: false)
                .ForeignKey("dbo.Options", t => t.OptionId, cascadeDelete: false)
                .ForeignKey("dbo.OptionChoices", t => t.OptionChoiceId, cascadeDelete: false)
                .Index(t => t.OrderId)
                .Index(t => t.OptionId)
                .Index(t => t.OptionChoiceId);
            
            AddColumn("dbo.Orders", "Username", c => c.String(nullable: false));
            AddColumn("dbo.Orders", "TotalCharge", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddForeignKey("dbo.Orders", "MakeId", "dbo.Makes", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Orders", "ModelId", "dbo.Models", "Id", cascadeDelete: false);
            CreateIndex("dbo.Orders", "MakeId");
            CreateIndex("dbo.Orders", "ModelId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.OrderConfigs", new[] { "OptionChoiceId" });
            DropIndex("dbo.OrderConfigs", new[] { "OptionId" });
            DropIndex("dbo.OrderConfigs", new[] { "OrderId" });
            DropIndex("dbo.Orders", new[] { "ModelId" });
            DropIndex("dbo.Orders", new[] { "MakeId" });
            DropForeignKey("dbo.OrderConfigs", "OptionChoiceId", "dbo.OptionChoices");
            DropForeignKey("dbo.OrderConfigs", "OptionId", "dbo.Options");
            DropForeignKey("dbo.OrderConfigs", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "ModelId", "dbo.Models");
            DropForeignKey("dbo.Orders", "MakeId", "dbo.Makes");
            DropColumn("dbo.Orders", "TotalCharge");
            DropColumn("dbo.Orders", "Username");
            DropTable("dbo.OrderConfigs");
        }
    }
}
