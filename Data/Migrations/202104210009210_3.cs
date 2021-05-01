namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PlanOfAction", "Discretionary");
            DropColumn("dbo.PlanOfAction", "YearlySaving");
            DropColumn("dbo.PlanOfAction", "MonthlySaving");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PlanOfAction", "MonthlySaving", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.PlanOfAction", "YearlySaving", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.PlanOfAction", "Discretionary", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
