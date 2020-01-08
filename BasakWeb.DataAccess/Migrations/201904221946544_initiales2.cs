namespace BasakWeb.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initiales2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "DateAdded", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "DateAdded");
        }
    }
}
