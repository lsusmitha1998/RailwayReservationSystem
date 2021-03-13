namespace RailwayResevationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class myticketscardno : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MyTickets", "CardNo", c => c.Long(nullable: false));
            AlterColumn("dbo.MyTickets", "Price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MyTickets", "Price", c => c.Int(nullable: false));
            DropColumn("dbo.MyTickets", "CardNo");
        }
    }
}
