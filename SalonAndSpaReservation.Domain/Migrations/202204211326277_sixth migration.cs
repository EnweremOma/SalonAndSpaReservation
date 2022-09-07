namespace SalonAndSpaReservation.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sixthmigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "NumberOfGuest", c => c.Int(nullable: false));
            DropColumn("dbo.Appointments", "VendorID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointments", "VendorID", c => c.Int(nullable: false));
            DropColumn("dbo.Appointments", "NumberOfGuest");
        }
    }
}
