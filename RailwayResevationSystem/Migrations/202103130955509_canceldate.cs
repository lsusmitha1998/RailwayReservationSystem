namespace RailwayResevationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class canceldate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookTickets", "CardNo", c => c.Long(nullable: true));
            AddColumn("dbo.BookTickets", "BookedDate", c => c.DateTime(nullable: true));
            AddColumn("dbo.BookTickets", "CancelledDate", c => c.DateTime(nullable: true));
            DropTable("dbo.MyBookings");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MyBookings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        TrainId = c.Int(nullable: false),
                        Source = c.String(),
                        Destination = c.String(),
                        NoofTickets = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        DateOfBooking = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.BookTickets", "CancelledDate");
            DropColumn("dbo.BookTickets", "BookedDate");
            DropColumn("dbo.BookTickets", "CardNo");
        }
    }
}
