namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PlanOfAction", "Essentials");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PlanOfAction", "Essentials", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
