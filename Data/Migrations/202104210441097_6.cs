namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Goal", "NumberOfYears", c => c.Double(nullable: false));
            DropColumn("dbo.Goal", "PayOffTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Goal", "PayOffTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Goal", "NumberOfYears");
        }
    }
}
