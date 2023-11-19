namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Cost = c.Long(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.ProvisionOfServices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateOfProvisionOfServices = c.String(),
                        EmployeeId = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                        ServiceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.ClientId)
                .Index(t => t.ServiceId);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Firstname = c.String(),
                        Lastname = c.String(),
                        Middlename = c.String(),
                        Adres = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Firstname = c.String(),
                        Lastname = c.String(),
                        Middlename = c.String(),
                        DateOfBirth = c.String(),
                        Gender = c.String(),
                        Experience = c.Long(nullable: false),
                        PostId = c.Int(nullable: false),
                        FotocenterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Fotocenters", t => t.FotocenterId, cascadeDelete: true)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.PostId)
                .Index(t => t.FotocenterId);
            
            CreateTable(
                "dbo.Fotocenters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        Title = c.String(),
                        Start = c.String(),
                        Finish = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Salary = c.Long(nullable: false),
                        WorkSchedule = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProvisionOfServices", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.Clients", "Id", "dbo.Users");
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Employees", "Id", "dbo.Users");
            DropForeignKey("dbo.ProvisionOfServices", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Employees", "FotocenterId", "dbo.Fotocenters");
            DropForeignKey("dbo.ProvisionOfServices", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Services", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Employees", new[] { "FotocenterId" });
            DropIndex("dbo.Employees", new[] { "PostId" });
            DropIndex("dbo.Employees", new[] { "Id" });
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.Clients", new[] { "Id" });
            DropIndex("dbo.ProvisionOfServices", new[] { "ServiceId" });
            DropIndex("dbo.ProvisionOfServices", new[] { "ClientId" });
            DropIndex("dbo.ProvisionOfServices", new[] { "EmployeeId" });
            DropIndex("dbo.Services", new[] { "CategoryId" });
            DropTable("dbo.Roles");
            DropTable("dbo.Posts");
            DropTable("dbo.Fotocenters");
            DropTable("dbo.Employees");
            DropTable("dbo.Users");
            DropTable("dbo.Clients");
            DropTable("dbo.ProvisionOfServices");
            DropTable("dbo.Services");
            DropTable("dbo.Categories");
        }
    }
}
