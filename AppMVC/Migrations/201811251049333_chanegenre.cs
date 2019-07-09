namespace AppMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chanegenre : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MovieGenres", "Movie_MovieId", "dbo.Movies");
            DropForeignKey("dbo.MovieGenres", "Genre_GenreId", "dbo.Genres");
            DropIndex("dbo.MovieGenres", new[] { "Movie_MovieId" });
            DropIndex("dbo.MovieGenres", new[] { "Genre_GenreId" });
            AddColumn("dbo.Movies", "GenreId", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "GenreId");
            AddForeignKey("dbo.Movies", "GenreId", "dbo.Genres", "GenreId", cascadeDelete: true);
            DropTable("dbo.MovieGenres");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MovieGenres",
                c => new
                    {
                        Movie_MovieId = c.Int(nullable: false),
                        Genre_GenreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Movie_MovieId, t.Genre_GenreId });
            
            DropForeignKey("dbo.Movies", "GenreId", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenreId" });
            DropColumn("dbo.Movies", "GenreId");
            CreateIndex("dbo.MovieGenres", "Genre_GenreId");
            CreateIndex("dbo.MovieGenres", "Movie_MovieId");
            AddForeignKey("dbo.MovieGenres", "Genre_GenreId", "dbo.Genres", "GenreId", cascadeDelete: true);
            AddForeignKey("dbo.MovieGenres", "Movie_MovieId", "dbo.Movies", "MovieId", cascadeDelete: true);
        }
    }
}
