namespace Fliek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenreType : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into GenreTypes(Genre) Values ('Action')");
            Sql("Insert into GenreTypes(Genre) Values ('Family')");
            Sql("Insert into GenreTypes(Genre) Values ('Horror')");
            Sql("Insert into GenreTypes(Genre) Values ('Comedy')");
            Sql("Insert into GenreTypes(Genre) Values ('Sci-Fi')");
        }
        
        public override void Down()
        {
        }
    }
}
