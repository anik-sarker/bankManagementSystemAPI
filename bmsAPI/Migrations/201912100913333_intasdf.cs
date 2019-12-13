namespace bmsAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intasdf : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        AccountId = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.AccountId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        CardId = c.Int(nullable: false),
                        CardStatusId = c.Int(nullable: false),
                        BranchId = c.Int(nullable: false),
                        AccountId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.Accounts", t => t.AccountId, cascadeDelete: true)
                .ForeignKey("dbo.Branches", t => t.BranchId, cascadeDelete: true)
                .ForeignKey("dbo.Cards", t => t.CardId, cascadeDelete: true)
                .ForeignKey("dbo.CardStatus", t => t.CardStatusId, cascadeDelete: true)
                .Index(t => t.CardId)
                .Index(t => t.CardStatusId)
                .Index(t => t.BranchId)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        BranchId = c.Int(nullable: false, identity: true),
                        BranchName = c.String(),
                        CurrentEmployees = c.Int(nullable: false),
                        Balance = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.BranchId);
            
            CreateTable(
                "dbo.Cards",
                c => new
                    {
                        CardId = c.Int(nullable: false, identity: true),
                        CardType = c.String(),
                    })
                .PrimaryKey(t => t.CardId);
            
            CreateTable(
                "dbo.CardStatus",
                c => new
                    {
                        CardStatusId = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.CardStatusId);
            
            CreateTable(
                "dbo.BankBalances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Balance = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CusAccountTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccType = c.String(nullable: false),
                        MaxTransection = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CusTransections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        Amount = c.Double(nullable: false),
                        BranchId = c.Int(nullable: false),
                        TransDate = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branches", t => t.BranchId, cascadeDelete: true)
                .Index(t => t.BranchId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        DateOfBirth = c.DateTime(),
                        Email = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false, maxLength: 11),
                        Address = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        NID = c.Int(nullable: false),
                        BranchId = c.Int(nullable: false),
                        Salary = c.Double(nullable: false),
                        JoinDate = c.String(),
                        Password = c.String(nullable: false, maxLength: 18),
                        EmpPoints = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branches", t => t.BranchId, cascadeDelete: true)
                .Index(t => t.BranchId);
            
            CreateTable(
                "dbo.EmpSalaries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        SalaryAmn = c.Double(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Password = c.String(nullable: false, maxLength: 18),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Managers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        DateOfBirth = c.DateTime(),
                        Email = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false, maxLength: 11),
                        Gender = c.String(nullable: false),
                        NID = c.Int(nullable: false),
                        BranchId = c.Int(nullable: false),
                        Salary = c.Double(nullable: false),
                        JoinDate = c.String(),
                        Password = c.String(nullable: false, maxLength: 18),
                        ManPoints = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branches", t => t.BranchId, cascadeDelete: true)
                .Index(t => t.BranchId);
            
            CreateTable(
                "dbo.MangrTransections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ManagerId = c.Int(nullable: false),
                        BranchId = c.Int(nullable: false),
                        Amount = c.Double(nullable: false),
                        TransDate = c.String(nullable: false),
                        Authorized = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branches", t => t.BranchId, cascadeDelete: true)
                .Index(t => t.BranchId);
            
            CreateTable(
                "dbo.ManNoticeBoards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        MesBody = c.String(nullable: false),
                        Seen = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ManSalaries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ManagerId = c.Int(nullable: false),
                        SalaryAmn = c.Double(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Managers", t => t.ManagerId, cascadeDelete: true)
                .Index(t => t.ManagerId);
            
            CreateTable(
                "dbo.NewUserRegs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserTypes", t => t.UserTypeId, cascadeDelete: true)
                .Index(t => t.UserTypeId);
            
            CreateTable(
                "dbo.UserTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        UserPasssword = c.String(),
                        UserRole = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NewUserRegs", "UserTypeId", "dbo.UserTypes");
            DropForeignKey("dbo.ManSalaries", "ManagerId", "dbo.Managers");
            DropForeignKey("dbo.MangrTransections", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.Managers", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.EmpSalaries", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.CusTransections", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.Customers", "CardStatusId", "dbo.CardStatus");
            DropForeignKey("dbo.Customers", "CardId", "dbo.Cards");
            DropForeignKey("dbo.Customers", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.Customers", "AccountId", "dbo.Accounts");
            DropIndex("dbo.NewUserRegs", new[] { "UserTypeId" });
            DropIndex("dbo.ManSalaries", new[] { "ManagerId" });
            DropIndex("dbo.MangrTransections", new[] { "BranchId" });
            DropIndex("dbo.Managers", new[] { "BranchId" });
            DropIndex("dbo.EmpSalaries", new[] { "EmployeeId" });
            DropIndex("dbo.Employees", new[] { "BranchId" });
            DropIndex("dbo.CusTransections", new[] { "BranchId" });
            DropIndex("dbo.Customers", new[] { "AccountId" });
            DropIndex("dbo.Customers", new[] { "BranchId" });
            DropIndex("dbo.Customers", new[] { "CardStatusId" });
            DropIndex("dbo.Customers", new[] { "CardId" });
            DropTable("dbo.UserInfoes");
            DropTable("dbo.UserTypes");
            DropTable("dbo.NewUserRegs");
            DropTable("dbo.ManSalaries");
            DropTable("dbo.ManNoticeBoards");
            DropTable("dbo.MangrTransections");
            DropTable("dbo.Managers");
            DropTable("dbo.Logins");
            DropTable("dbo.EmpSalaries");
            DropTable("dbo.Employees");
            DropTable("dbo.CusTransections");
            DropTable("dbo.CusAccountTypes");
            DropTable("dbo.BankBalances");
            DropTable("dbo.CardStatus");
            DropTable("dbo.Cards");
            DropTable("dbo.Branches");
            DropTable("dbo.Customers");
            DropTable("dbo.Accounts");
        }
    }
}
