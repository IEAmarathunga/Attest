namespace Attest.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumns_MsgInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Applications", "IsApplicationFound", c => c.Boolean(nullable: false));
            AddColumn("dbo.Applications", "IsMsgSent", c => c.Boolean(nullable: false));
            AddColumn("dbo.Applications", "IsApplicationCollected", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Applications", "IsApplicationCollected");
            DropColumn("dbo.Applications", "IsMsgSent");
            DropColumn("dbo.Applications", "IsApplicationFound");
        }
    }
}
