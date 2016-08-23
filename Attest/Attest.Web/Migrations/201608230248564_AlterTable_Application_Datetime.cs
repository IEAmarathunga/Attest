namespace Attest.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterTable_Application_Datetime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Applications", "ApplicationDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Applications", "ReceiptDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Applications", "SignatureDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Applications", "CreatedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Applications", "LastModifiedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Applications", "DeletedDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Applications", "DeletedDate", c => c.DateTime());
            AlterColumn("dbo.Applications", "LastModifiedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Applications", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Applications", "SignatureDate", c => c.DateTime());
            AlterColumn("dbo.Applications", "ReceiptDate", c => c.DateTime());
            AlterColumn("dbo.Applications", "ApplicationDate", c => c.DateTime(nullable: false));
        }
    }
}
