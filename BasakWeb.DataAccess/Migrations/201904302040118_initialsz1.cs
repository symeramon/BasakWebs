namespace BasakWeb.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialsz1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "RequiredDate", c => c.DateTime());
            AlterColumn("dbo.Orders", "ShippedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "ShippedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Orders", "RequiredDate", c => c.DateTime(nullable: false));
        }
    }
}
