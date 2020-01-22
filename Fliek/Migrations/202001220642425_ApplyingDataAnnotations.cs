namespace Fliek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyingDataAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "FirstName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Customers", "LastName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Movies", "MovieName", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "MovieName", c => c.String());
            AlterColumn("dbo.Customers", "LastName", c => c.String());
            AlterColumn("dbo.Customers", "FirstName", c => c.String());
        }
    }
}
