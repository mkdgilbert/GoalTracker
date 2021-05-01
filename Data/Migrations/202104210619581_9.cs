namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _9 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Goal", "PlanOfAction_PlanId", "dbo.PlanOfAction");
            DropIndex("dbo.Goal", new[] { "PlanOfAction_PlanId" });
            AddColumn("dbo.PlanOfAction", "Goal_GoalId", c => c.Int());
            CreateIndex("dbo.PlanOfAction", "Goal_GoalId");
            AddForeignKey("dbo.PlanOfAction", "Goal_GoalId", "dbo.Goal", "GoalId");
            DropColumn("dbo.Goal", "PlanOfAction_PlanId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Goal", "PlanOfAction_PlanId", c => c.Int());
            DropForeignKey("dbo.PlanOfAction", "Goal_GoalId", "dbo.Goal");
            DropIndex("dbo.PlanOfAction", new[] { "Goal_GoalId" });
            DropColumn("dbo.PlanOfAction", "Goal_GoalId");
            CreateIndex("dbo.Goal", "PlanOfAction_PlanId");
            AddForeignKey("dbo.Goal", "PlanOfAction_PlanId", "dbo.PlanOfAction", "PlanId");
        }
    }
}
