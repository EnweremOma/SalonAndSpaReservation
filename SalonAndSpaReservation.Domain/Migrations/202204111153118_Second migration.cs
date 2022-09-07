namespace SalonAndSpaReservation.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Secondmigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Services", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Services", "Duration", c => c.String(nullable: false));
            AlterColumn("dbo.Services", "Materials", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Services", "Materials", c => c.String());
            AlterColumn("dbo.Services", "Duration", c => c.String());
            AlterColumn("dbo.Services", "Name", c => c.String());
        }
    }
}
