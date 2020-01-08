namespace BasakWeb.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialesz111 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Silindi", c => c.Boolean(nullable: false));
            AddColumn("dbo.Orders", "Silindi", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "Silindi");
            DropColumn("dbo.Products", "Silindi");
        }
    }
}
