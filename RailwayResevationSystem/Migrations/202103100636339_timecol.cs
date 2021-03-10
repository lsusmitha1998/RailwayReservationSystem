namespace RailwayResevationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class timecol : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trains", "TimeOfArrival", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trains", "TimeOfArrival");
        }
    }
}
