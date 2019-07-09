namespace AppMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenreId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.GenreId);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        MovieId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        PriceForTcket = c.Int(nullable: false),
                        ImgUrl = c.String(),
                        YoutubeURL = c.String(),
                        Description = c.String(),
                        Rating = c.Double(nullable: false),
                        Duration = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MovieId);
            
            CreateTable(
                "dbo.TimeTables",
                c => new
                    {
                        TimeId = c.Int(nullable: false, identity: true),
                        HallId = c.Int(nullable: false),
                        MovieId = c.Int(nullable: false),
                        Time = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TimeId)
                .ForeignKey("dbo.Halls", t => t.HallId, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.HallId)
                .Index(t => t.MovieId);
            
            CreateTable(
                "dbo.Halls",
                c => new
                    {
                        HallId = c.Int(nullable: false, identity: true),
                        HallName = c.String(),
                        NumOFSeats = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HallId);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        ReservationId = c.Int(nullable: false, identity: true),
                        TimeTableId = c.Int(nullable: false),
                        NumOfTickets = c.Int(nullable: false),
                        ApplicationUserId = c.String(maxLength: 128),
                        TimeTable_TimeId = c.Int(),
                    })
                .PrimaryKey(t => t.ReservationId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.TimeTables", t => t.TimeTable_TimeId)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.TimeTable_TimeId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.MovieGenres",
                c => new
                    {
                        Movie_MovieId = c.Int(nullable: false),
                        Genre_GenreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Movie_MovieId, t.Genre_GenreId })
                .ForeignKey("dbo.Movies", t => t.Movie_MovieId, cascadeDelete: true)
                .ForeignKey("dbo.Genres", t => t.Genre_GenreId, cascadeDelete: true)
                .Index(t => t.Movie_MovieId)
                .Index(t => t.Genre_GenreId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Reservations", "TimeTable_TimeId", "dbo.TimeTables");
            DropForeignKey("dbo.Reservations", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TimeTables", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.TimeTables", "HallId", "dbo.Halls");
            DropForeignKey("dbo.MovieGenres", "Genre_GenreId", "dbo.Genres");
            DropForeignKey("dbo.MovieGenres", "Movie_MovieId", "dbo.Movies");
            DropIndex("dbo.MovieGenres", new[] { "Genre_GenreId" });
            DropIndex("dbo.MovieGenres", new[] { "Movie_MovieId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Reservations", new[] { "TimeTable_TimeId" });
            DropIndex("dbo.Reservations", new[] { "ApplicationUserId" });
            DropIndex("dbo.TimeTables", new[] { "MovieId" });
            DropIndex("dbo.TimeTables", new[] { "HallId" });
            DropTable("dbo.MovieGenres");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Reservations");
            DropTable("dbo.Halls");
            DropTable("dbo.TimeTables");
            DropTable("dbo.Movies");
            DropTable("dbo.Genres");
        }
    }
}
