namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            
          
            
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
