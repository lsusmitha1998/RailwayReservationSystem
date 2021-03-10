namespace RailwayResevationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class drpcol : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Trains", "CoachClass");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Trains", "CoachClass", c => c.String(nullable: false));
        }
    }
}
