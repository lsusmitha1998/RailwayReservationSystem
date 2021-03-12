namespace RailwayResevationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class booking : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookTickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false),
                        TrainId = c.Int(nullable: false),
                        Coach = c.String(nullable: false),
                        SeatLocation = c.String(nullable: false),
                        Price = c.Double(nullable: false),
                        NoOfTickets = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BookTickets");
        }
    }
}
