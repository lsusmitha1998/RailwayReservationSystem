namespace RailwayResevationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class admincol : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "PhoneNumber", c => c.Long(nullable: false));
            AddColumn("dbo.Admins", "Email", c => c.String(nullable: false));
            AddColumn("dbo.Admins", "Petname", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admins", "Petname");
            DropColumn("dbo.Admins", "Email");
            DropColumn("dbo.Admins", "PhoneNumber");
        }
    }
}
