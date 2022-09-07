namespace SalonAndSpaReservation.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialmigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Materials", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Materials", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Materials", "Category", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Materials", "Category", c => c.String());
            AlterColumn("dbo.Materials", "Description", c => c.String());
            AlterColumn("dbo.Materials", "Name", c => c.String());
        }
    }
}
