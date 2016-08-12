namespace Attest.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumns_UserDetails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Applications", "CreatedBy", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Applications", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Applications", "LastModifiedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Applications", "LastModifiedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Applications", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Applications", "DeletedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Applications", "DeleteComment", c => c.String(maxLength: 100));
            AddColumn("dbo.Applications", "DeletedDate", c => c.DateTime());
            CreateIndex("dbo.Applications", "CreatedBy");
            CreateIndex("dbo.Applications", "LastModifiedBy");
            CreateIndex("dbo.Applications", "DeletedBy");
            AddForeignKey("dbo.Applications", "CreatedBy", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Applications", "DeletedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Applications", "LastModifiedBy", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Applications", "LastModifiedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Applications", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Applications", "CreatedBy", "dbo.AspNetUsers");
            DropIndex("dbo.Applications", new[] { "DeletedBy" });
            DropIndex("dbo.Applications", new[] { "LastModifiedBy" });
            DropIndex("dbo.Applications", new[] { "CreatedBy" });
            DropColumn("dbo.Applications", "DeletedDate");
            DropColumn("dbo.Applications", "DeleteComment");
            DropColumn("dbo.Applications", "DeletedBy");
            DropColumn("dbo.Applications", "IsDeleted");
            DropColumn("dbo.Applications", "LastModifiedDate");
            DropColumn("dbo.Applications", "LastModifiedBy");
            DropColumn("dbo.Applications", "CreatedDate");
            DropColumn("dbo.Applications", "CreatedBy");
        }
    }
}
