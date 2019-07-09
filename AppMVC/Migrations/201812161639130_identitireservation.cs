namespace AppMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class identitireservation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reservations", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Reservations", new[] { "ApplicationUserId" });
            AlterColumn("dbo.Reservations", "ApplicationUserId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reservations", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Reservations", "ApplicationUserId");
            AddForeignKey("dbo.Reservations", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
    }
}
