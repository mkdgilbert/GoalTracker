namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Asset",
                c => new
                    {
                        AssetId = c.Int(nullable: false, identity: true),
                        PropertyType = c.Int(nullable: false),
                        AvailableCash = c.Decimal(nullable: false, precision: 18, scale: 2),
                        YearlyIncome = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalEquity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Id = c.String(maxLength: 128),
                        UserInfo_UserInfoId = c.Int(),
                    })
                .PrimaryKey(t => t.AssetId)
                .ForeignKey("dbo.ApplicationUser", t => t.Id)
                .ForeignKey("dbo.UserInfo", t => t.UserInfo_UserInfoId)
                .Index(t => t.Id)
                .Index(t => t.UserInfo_UserInfoId);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id);
            
            CreateTable(
                "dbo.Goal",
                c => new
                    {
                        GoalId = c.Int(nullable: false, identity: true),
                        Id = c.String(maxLength: 128),
                        GoalCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FinanceOption = c.Boolean(nullable: false),
                        OutOfPocketOption = c.Boolean(nullable: false),
                        GoalName = c.String(nullable: false),
                        GoalType = c.String(nullable: false),
                        PayOffTime = c.DateTime(nullable: false),
                        InterestRate = c.Single(nullable: false),
                        PlanOfAction_PlanId = c.Int(),
                        UserInfo_UserInfoId = c.Int(),
                    })
                .PrimaryKey(t => t.GoalId)
                .ForeignKey("dbo.PlanOfAction", t => t.PlanOfAction_PlanId)
                .ForeignKey("dbo.ApplicationUser", t => t.Id)
                .ForeignKey("dbo.UserInfo", t => t.UserInfo_UserInfoId)
                .Index(t => t.Id)
                .Index(t => t.PlanOfAction_PlanId)
                .Index(t => t.UserInfo_UserInfoId);
            
            CreateTable(
                "dbo.PlanOfAction",
                c => new
                    {
                        PlanId = c.Int(nullable: false, identity: true),
                        Id = c.String(maxLength: 128),
                        AssetId = c.Int(nullable: false),
                        PlanName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PlanId)
                .ForeignKey("dbo.Asset", t => t.AssetId, cascadeDelete: true)
                .ForeignKey("dbo.ApplicationUser", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.AssetId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserInfo",
                c => new
                    {
                        UserInfoId = c.Int(nullable: false, identity: true),
                        Id = c.String(maxLength: 128),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserInfoId)
                .ForeignKey("dbo.ApplicationUser", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserInfo", "Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.Goal", "UserInfo_UserInfoId", "dbo.UserInfo");
            DropForeignKey("dbo.Asset", "UserInfo_UserInfoId", "dbo.UserInfo");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Goal", "Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.Goal", "PlanOfAction_PlanId", "dbo.PlanOfAction");
            DropForeignKey("dbo.PlanOfAction", "Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.PlanOfAction", "AssetId", "dbo.Asset");
            DropForeignKey("dbo.Asset", "Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropIndex("dbo.UserInfo", new[] { "Id" });
            DropIndex("dbo.PlanOfAction", new[] { "AssetId" });
            DropIndex("dbo.PlanOfAction", new[] { "Id" });
            DropIndex("dbo.Goal", new[] { "UserInfo_UserInfoId" });
            DropIndex("dbo.Goal", new[] { "PlanOfAction_PlanId" });
            DropIndex("dbo.Goal", new[] { "Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Asset", new[] { "UserInfo_UserInfoId" });
            DropIndex("dbo.Asset", new[] { "Id" });
            DropTable("dbo.UserInfo");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.PlanOfAction");
            DropTable("dbo.Goal");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.Asset");
        }
    }
}
