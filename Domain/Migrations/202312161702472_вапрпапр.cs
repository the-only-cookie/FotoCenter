namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class вапрпапр : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProvisionOfServices", "DateOfProvisionOfServices", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProvisionOfServices", "DateOfProvisionOfServices", c => c.String());
        }
    }
}
