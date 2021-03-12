namespace RailwayResevationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mybookingsup : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MyBookings", "Source", c => c.String());
            AddColumn("dbo.MyBookings", "Destination", c => c.String());
            AddColumn("dbo.MyBookings", "DateOfBooking", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MyBookings", "DateOfBooking");
            DropColumn("dbo.MyBookings", "Destination");
            DropColumn("dbo.MyBookings", "Source");
        }
    }
}
