namespace SalonAndSpaReservation.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EleventhMigrtion : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Appointments", "CustomerID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointments", "CustomerID", c => c.Int(nullable: false));
        }
    }
}
