namespace BasakWeb.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initiale334 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Sold", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Sold");
        }
    }
}
