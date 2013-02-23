namespace KendoDreamCarShopper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Config : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Models", "MakeId", "dbo.Makes");
            DropForeignKey("dbo.ModelImages", "ModelId", "dbo.Models");
            DropForeignKey("dbo.Options", "ModelId", "dbo.Models");
            DropForeignKey("dbo.OptionChoices", "OptionId", "dbo.Options");
            DropForeignKey("dbo.Orders", "MakeId", "dbo.Makes");
            DropForeignKey("dbo.Orders", "ModelId", "dbo.Models");
            DropForeignKey("dbo.OrderConfigs", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderConfigs", "OptionId", "dbo.Options");
            DropForeignKey("dbo.OrderConfigs", "OptionChoiceId", "dbo.OptionChoices");
            DropIndex("dbo.Models", new[] { "MakeId" });
            DropIndex("dbo.ModelImages", new[] { "ModelId" });
            DropIndex("dbo.Options", new[] { "ModelId" });
            DropIndex("dbo.OptionChoices", new[] { "OptionId" });
            DropIndex("dbo.Orders", new[] { "MakeId" });
            DropIndex("dbo.Orders", new[] { "ModelId" });
            DropIndex("dbo.OrderConfigs", new[] { "OrderId" });
            DropIndex("dbo.OrderConfigs", new[] { "OptionId" });
            DropIndex("dbo.OrderConfigs", new[] { "OptionChoiceId" });
            AddForeignKey("dbo.Models", "MakeId", "dbo.Makes", "Id", cascadeDelete: false);
            AddForeignKey("dbo.ModelImages", "ModelId", "dbo.Models", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Options", "ModelId", "dbo.Models", "Id", cascadeDelete: false);
            AddForeignKey("dbo.OptionChoices", "OptionId", "dbo.Options", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Orders", "MakeId", "dbo.Makes", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Orders", "ModelId", "dbo.Models", "Id", cascadeDelete: false);
            AddForeignKey("dbo.OrderConfigs", "OrderId", "dbo.Orders", "Id", cascadeDelete: false);
            AddForeignKey("dbo.OrderConfigs", "OptionId", "dbo.Options", "Id", cascadeDelete: false);
            AddForeignKey("dbo.OrderConfigs", "OptionChoiceId", "dbo.OptionChoices", "Id", cascadeDelete: false);
            CreateIndex("dbo.Models", "MakeId");
            CreateIndex("dbo.ModelImages", "ModelId");
            CreateIndex("dbo.Options", "ModelId");
            CreateIndex("dbo.OptionChoices", "OptionId");
            CreateIndex("dbo.Orders", "MakeId");
            CreateIndex("dbo.Orders", "ModelId");
            CreateIndex("dbo.OrderConfigs", "OrderId");
            CreateIndex("dbo.OrderConfigs", "OptionId");
            CreateIndex("dbo.OrderConfigs", "OptionChoiceId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.OrderConfigs", new[] { "OptionChoiceId" });
            DropIndex("dbo.OrderConfigs", new[] { "OptionId" });
            DropIndex("dbo.OrderConfigs", new[] { "OrderId" });
            DropIndex("dbo.Orders", new[] { "ModelId" });
            DropIndex("dbo.Orders", new[] { "MakeId" });
            DropIndex("dbo.OptionChoices", new[] { "OptionId" });
            DropIndex("dbo.Options", new[] { "ModelId" });
            DropIndex("dbo.ModelImages", new[] { "ModelId" });
            DropIndex("dbo.Models", new[] { "MakeId" });
            DropForeignKey("dbo.OrderConfigs", "OptionChoiceId", "dbo.OptionChoices");
            DropForeignKey("dbo.OrderConfigs", "OptionId", "dbo.Options");
            DropForeignKey("dbo.OrderConfigs", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "ModelId", "dbo.Models");
            DropForeignKey("dbo.Orders", "MakeId", "dbo.Makes");
            DropForeignKey("dbo.OptionChoices", "OptionId", "dbo.Options");
            DropForeignKey("dbo.Options", "ModelId", "dbo.Models");
            DropForeignKey("dbo.ModelImages", "ModelId", "dbo.Models");
            DropForeignKey("dbo.Models", "MakeId", "dbo.Makes");
            CreateIndex("dbo.OrderConfigs", "OptionChoiceId");
            CreateIndex("dbo.OrderConfigs", "OptionId");
            CreateIndex("dbo.OrderConfigs", "OrderId");
            CreateIndex("dbo.Orders", "ModelId");
            CreateIndex("dbo.Orders", "MakeId");
            CreateIndex("dbo.OptionChoices", "OptionId");
            CreateIndex("dbo.Options", "ModelId");
            CreateIndex("dbo.ModelImages", "ModelId");
            CreateIndex("dbo.Models", "MakeId");
            AddForeignKey("dbo.OrderConfigs", "OptionChoiceId", "dbo.OptionChoices", "Id");
            AddForeignKey("dbo.OrderConfigs", "OptionId", "dbo.Options", "Id");
            AddForeignKey("dbo.OrderConfigs", "OrderId", "dbo.Orders", "Id");
            AddForeignKey("dbo.Orders", "ModelId", "dbo.Models", "Id");
            AddForeignKey("dbo.Orders", "MakeId", "dbo.Makes", "Id");
            AddForeignKey("dbo.OptionChoices", "OptionId", "dbo.Options", "Id");
            AddForeignKey("dbo.Options", "ModelId", "dbo.Models", "Id");
            AddForeignKey("dbo.ModelImages", "ModelId", "dbo.Models", "Id");
            AddForeignKey("dbo.Models", "MakeId", "dbo.Makes", "Id");
        }
    }
}
