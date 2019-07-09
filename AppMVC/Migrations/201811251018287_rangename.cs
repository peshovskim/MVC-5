namespace AppMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rangename : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "Fullame", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "Fullame", c => c.String(nullable: false));
        }
    }
}
