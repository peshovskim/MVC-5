namespace AppMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKeyUser : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reservations", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Reservations", "ApplicationUserId");
            AddForeignKey("dbo.Reservations", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Reservations", new[] { "ApplicationUserId" });
            AlterColumn("dbo.Reservations", "ApplicationUserId", c => c.String());
        }
    }
}
