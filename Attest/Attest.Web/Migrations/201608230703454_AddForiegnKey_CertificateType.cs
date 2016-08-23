namespace Attest.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForiegnKey_CertificateType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Applications", "CertificateTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Applications", "CertificateTypeId");
            AddForeignKey("dbo.Applications", "CertificateTypeId", "dbo.CertificateTypes", "Id", cascadeDelete: true);
            DropColumn("dbo.Applications", "Category");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Applications", "Category", c => c.Int(nullable: false));
            DropForeignKey("dbo.Applications", "CertificateTypeId", "dbo.CertificateTypes");
            DropIndex("dbo.Applications", new[] { "CertificateTypeId" });
            DropColumn("dbo.Applications", "CertificateTypeId");
        }
    }
}
