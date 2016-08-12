namespace Attest.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTable_Application : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Applications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationNo = c.String(nullable: false, maxLength: 10),
                        ApplicationDate = c.DateTime(nullable: false),
                        Category = c.Int(nullable: false),
                        ApplicantName = c.String(nullable: false, maxLength: 100),
                        ApplicantAddress = c.String(maxLength: 300),
                        NoOfCopies = c.Int(),
                        ApplicationFee = c.Decimal(nullable: false, precision: 10, scale: 2),
                        SearchYears = c.Int(),
                        SearchFee = c.Decimal(precision: 10, scale: 2),
                        CopyingFee = c.Decimal(precision: 10, scale: 2),
                        StampFee = c.Decimal(precision: 10, scale: 2),
                        ReceiptNo = c.Int(),
                        ReceiptDate = c.DateTime(),
                        Refund = c.Decimal(precision: 10, scale: 2),
                        SignatureDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.ApplicationNo, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Applications", new[] { "ApplicationNo" });
            DropTable("dbo.Applications");
        }
    }
}
