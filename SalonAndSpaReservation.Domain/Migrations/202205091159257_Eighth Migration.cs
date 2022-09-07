namespace SalonAndSpaReservation.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EighthMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "ServicePrice", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Appointments", "ServicePrice");
        }
    }
}
