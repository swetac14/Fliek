namespace Fliek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnnotationsToGenerateAutoIncrementIDs : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "MembershipTypeID", "dbo.MembershipTypes");
            DropPrimaryKey("dbo.MembershipTypes");
            AlterColumn("dbo.MembershipTypes", "Id", c => c.Byte(nullable: false, identity: true));
            AddPrimaryKey("dbo.MembershipTypes", "Id");
            AddForeignKey("dbo.Customers", "MembershipTypeID", "dbo.MembershipTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MembershipTypeID", "dbo.MembershipTypes");
            DropPrimaryKey("dbo.MembershipTypes");
            AlterColumn("dbo.MembershipTypes", "Id", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.MembershipTypes", "Id");
            AddForeignKey("dbo.Customers", "MembershipTypeID", "dbo.MembershipTypes", "Id", cascadeDelete: true);
        }
    }
}
