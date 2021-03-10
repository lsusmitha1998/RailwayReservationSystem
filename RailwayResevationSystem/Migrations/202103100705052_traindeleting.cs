namespace RailwayResevationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class traindeleting : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Trains");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Trains",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TrainId = c.Int(nullable: false),
                        TrainName = c.String(nullable: false),
                        Source = c.String(nullable: false),
                        Destination = c.String(nullable: false),
                        DateOfTravel = c.DateTime(nullable: false),
                        TimeOfArrival = c.String(nullable: false),
                        TrainType = c.String(nullable: false),
                        SeatAvailability = c.String(nullable: false),
                        NoOfSeat = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
