namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upatedatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Asset", "HouseAppraisal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Asset", "HouseDebt", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Asset", "HouseDebt");
            DropColumn("dbo.Asset", "HouseAppraisal");
        }
    }
}
