namespace SalonAndSpaReservation.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TenthMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "ServiceDuration", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Services", "Duration", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Services", "Duration", c => c.String(nullable: false));
            DropColumn("dbo.Appointments", "ServiceDuration");
        }
    }
}
