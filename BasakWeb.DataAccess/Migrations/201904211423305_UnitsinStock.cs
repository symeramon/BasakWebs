namespace BasakWeb.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UnitsinStock : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "UnitsInStock", c => c.Short(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "UnitsInStock");
        }
    }
}
