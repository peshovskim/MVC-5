namespace AppMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class identitireservation3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "ApplicatinUserId", c => c.String());
            AddColumn("dbo.Reservations", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Reservations", "ApplicationUser_Id");
            AddForeignKey("dbo.Reservations", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Reservations", "ApplicationIdentityId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reservations", "ApplicationIdentityId", c => c.String());
            DropForeignKey("dbo.Reservations", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Reservations", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Reservations", "ApplicationUser_Id");
            DropColumn("dbo.Reservations", "ApplicatinUserId");
        }
    }
}
