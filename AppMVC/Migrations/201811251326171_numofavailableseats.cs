namespace AppMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class numofavailableseats : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Halls", "NumOFAvailableSeats", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Halls", "NumOFAvailableSeats");
        }
    }
}
