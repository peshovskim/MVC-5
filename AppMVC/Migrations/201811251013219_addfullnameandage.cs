namespace AppMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addfullnameandage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Fullame", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "Age", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Age");
            DropColumn("dbo.AspNetUsers", "Fullame");
        }
    }
}
