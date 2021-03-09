namespace RailwayResevationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class creatingDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false),
                        password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CardNo = c.Long(nullable: false),
                        CardHolder = c.String(nullable: false),
                        ExpiryDate = c.DateTime(nullable: false),
                        Cvv = c.Int(nullable: false),
                        CardType = c.String(nullable: false),
                        AvailableBalance = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                        TrainType = c.String(nullable: false),
                        CoachClass = c.String(nullable: false),
                        SeatAvailability = c.String(nullable: false),
                        NoOfSeat = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 8),
                        Password = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        Email = c.String(nullable: false),
                        ContactNumber = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Trains");
            DropTable("dbo.Payments");
            DropTable("dbo.Admins");
        }
    }
}
