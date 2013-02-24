namespace KendoDreamCarShopper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangePkNameOnOrder : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderConfigs", "OrderId", "dbo.Orders");
            DropIndex("dbo.OrderConfigs", new[] { "OrderId" });
            DropPrimaryKey("dbo.Orders", new[] { "OrderId" });
            DropColumn("dbo.Orders", "OrderId");
            AddColumn("dbo.Orders", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Orders", "Id");
            AddForeignKey("dbo.OrderConfigs", "OrderId", "dbo.Orders", "Id", cascadeDelete: true);
            CreateIndex("dbo.OrderConfigs", "OrderId");
 
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "OrderId", c => c.Int(nullable: false, identity: true));
            DropIndex("dbo.OrderConfigs", new[] { "OrderId" });
            DropForeignKey("dbo.OrderConfigs", "OrderId", "dbo.Orders");
            DropPrimaryKey("dbo.Orders", new[] { "Id" });
            AddPrimaryKey("dbo.Orders", "OrderId");
            DropColumn("dbo.Orders", "Id");
            CreateIndex("dbo.OrderConfigs", "OrderId");
            AddForeignKey("dbo.OrderConfigs", "OrderId", "dbo.Orders", "OrderId", cascadeDelete: true);
        }
    }
}
