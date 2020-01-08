namespace BasakWeb.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialesz11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Sozlesme", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "Sozlesme");
        }
    }
}
