namespace SalonAndSpaReservation.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Thirdmigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Services", "Description", c => c.String(nullable: false));
            DropColumn("dbo.Services", "Materials");
            DropColumn("dbo.Services", "AccountID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Services", "AccountID", c => c.Int(nullable: false));
            AddColumn("dbo.Services", "Materials", c => c.String(nullable: false));
            DropColumn("dbo.Services", "Description");
        }
    }
}
