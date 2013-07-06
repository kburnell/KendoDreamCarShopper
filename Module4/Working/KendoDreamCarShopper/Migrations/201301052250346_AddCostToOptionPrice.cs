namespace KendoDreamCarShopper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCostToOptionPrice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OptionChoices", "Cost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OptionChoices", "Cost");
        }
    }
}
