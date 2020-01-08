namespace BasakWeb.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialsz : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ApplicationUsers", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ApplicationUsers", "Email", c => c.String());
        }
    }
}
