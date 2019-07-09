namespace AppMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class identitireservation2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "ApplicationIdentityId", c => c.String());
            DropColumn("dbo.Reservations", "ApplicationUserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reservations", "ApplicationUserId", c => c.String());
            DropColumn("dbo.Reservations", "ApplicationIdentityId");
        }
    }
}
