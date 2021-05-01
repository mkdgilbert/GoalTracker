namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Goal", "FinanceOption");
            DropColumn("dbo.Goal", "OutOfPocketOption");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Goal", "OutOfPocketOption", c => c.Boolean(nullable: false));
            AddColumn("dbo.Goal", "FinanceOption", c => c.Boolean(nullable: false));
        }
    }
}
