namespace SalonAndSpaReservation.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NinthMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "FirstName", c => c.String());
            AddColumn("dbo.Appointments", "LastName", c => c.String());
            AddColumn("dbo.Appointments", "PhoneNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Appointments", "Email", c => c.String());
            AddColumn("dbo.Appointments", "State", c => c.String());
            AddColumn("dbo.Appointments", "City", c => c.String());
            AddColumn("dbo.Appointments", "ZipCode", c => c.Int(nullable: false));
            AddColumn("dbo.Appointments", "StreetAddress", c => c.String());
            AddColumn("dbo.Appointments", "Gender", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Appointments", "Gender");
            DropColumn("dbo.Appointments", "StreetAddress");
            DropColumn("dbo.Appointments", "ZipCode");
            DropColumn("dbo.Appointments", "City");
            DropColumn("dbo.Appointments", "State");
            DropColumn("dbo.Appointments", "Email");
            DropColumn("dbo.Appointments", "PhoneNumber");
            DropColumn("dbo.Appointments", "LastName");
            DropColumn("dbo.Appointments", "FirstName");
        }
    }
}
