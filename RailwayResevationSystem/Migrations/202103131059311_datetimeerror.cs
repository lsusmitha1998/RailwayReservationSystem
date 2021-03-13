namespace RailwayResevationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datetimeerror : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BookTickets", "BookedDate", c => c.DateTime(nullable: true, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.BookTickets", "CancelledDate", c => c.DateTime(nullable: true, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.MyTickets", "DateOfBooking", c => c.DateTime(nullable: true, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MyTickets", "DateOfBooking", c => c.DateTime(nullable: false));
            AlterColumn("dbo.BookTickets", "CancelledDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.BookTickets", "BookedDate", c => c.DateTime(nullable: false));
        }
    }
}
