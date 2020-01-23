namespace Fliek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMoviesAndGenreType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    MovieName = c.String(),
                    ReleaseDate = c.DateTime(),
                    Rating = c.String(),
                    DateAdded = c.DateTime(nullable: false),
                    NumberInStock= c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
               "dbo.GenreTypes",
               c => new
               {
                   Id = c.Int(nullable: false, identity: true),
                   Genre = c.String(),
               })
               .PrimaryKey(t => t.Id);


            AddColumn("dbo.Movies", "GenreType_Id", c => c.Int());
            CreateIndex("dbo.Movies", "GenreType_Id");
            AddForeignKey("dbo.Movies", "GenreType_Id", "dbo.GenreTypes", "Id");

            AlterColumn("dbo.Movies", "MovieName", c => c.String(nullable: false, maxLength: 255));


        }

        public override void Down()
        {
            DropTable("dbo.Movies");
            DropTable("dbo.GenreTypes");
        }
    }
}
