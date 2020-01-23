namespace Fliek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeDateFieldsNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "DateOFBirth", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "DateOFBirth", c => c.DateTime(nullable: false));
        }
    }
}
