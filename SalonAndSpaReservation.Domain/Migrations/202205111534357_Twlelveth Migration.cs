namespace SalonAndSpaReservation.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TwlelvethMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Appointments", "PhoneNumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Appointments", "PhoneNumber", c => c.Int(nullable: false));
        }
    }
}
