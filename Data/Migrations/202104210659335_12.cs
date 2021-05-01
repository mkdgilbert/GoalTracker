namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PlanOfAction", "GoalId", c => c.Int());
            CreateIndex("dbo.PlanOfAction", "GoalId");
            AddForeignKey("dbo.PlanOfAction", "GoalId", "dbo.Goal", "GoalId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlanOfAction", "GoalId", "dbo.Goal");
            DropIndex("dbo.PlanOfAction", new[] { "GoalId" });
            DropColumn("dbo.PlanOfAction", "GoalId");
        }
    }
}
