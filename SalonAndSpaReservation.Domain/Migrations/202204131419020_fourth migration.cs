namespace SalonAndSpaReservation.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fourthmigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Materials", "ImageData", c => c.Binary());
            AddColumn("dbo.Materials", "ImageMimeType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Materials", "ImageMimeType");
            DropColumn("dbo.Materials", "ImageData");
        }
    }
}
