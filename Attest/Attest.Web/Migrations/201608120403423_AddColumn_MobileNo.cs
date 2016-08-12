namespace Attest.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumn_MobileNo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Applications", "ApplicantMobile", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Applications", "ApplicantMobile");
        }
    }
}
