namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _5 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Asset", "PropertyType");
            DropColumn("dbo.Asset", "TotalEquity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Asset", "TotalEquity", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Asset", "PropertyType", c => c.Int(nullable: false));
        }
    }
}
