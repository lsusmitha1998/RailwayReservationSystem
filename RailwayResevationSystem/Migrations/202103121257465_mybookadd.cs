namespace RailwayResevationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mybookadd : DbMigration
    {
        public override void Up()
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MyBookings");
        }
    }
}
