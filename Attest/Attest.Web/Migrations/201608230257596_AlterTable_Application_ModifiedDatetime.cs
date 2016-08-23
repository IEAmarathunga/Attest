namespace Attest.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterTable_Application_ModifiedDatetime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Applications", "LastModifiedDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Applications", "LastModifiedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
    }
}
