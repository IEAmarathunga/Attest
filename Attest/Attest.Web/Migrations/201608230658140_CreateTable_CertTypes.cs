namespace Attest.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTable_CertTypes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CertificateTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CertificateTypes");
        }
    }
}
