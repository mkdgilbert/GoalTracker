namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PlanOfAction", "Goal_GoalId", "dbo.Goal");
            DropIndex("dbo.PlanOfAction", new[] { "Goal_GoalId" });
            DropColumn("dbo.PlanOfAction", "Goal_GoalId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PlanOfAction", "Goal_GoalId", c => c.Int());
            CreateIndex("dbo.PlanOfAction", "Goal_GoalId");
            AddForeignKey("dbo.PlanOfAction", "Goal_GoalId", "dbo.Goal", "GoalId");
        }
    }
}
