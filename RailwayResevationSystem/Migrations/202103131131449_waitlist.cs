namespace RailwayResevationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class waitlist : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MyTickets", "ConfirmationStatus", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MyTickets", "ConfirmationStatus");
        }
    }
}
