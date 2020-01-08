namespace BasakWeb.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialesz1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropPrimaryKey("dbo.OrderDetails");
            AddColumn("dbo.OrderDetails", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.OrderDetails", "Id");
            AddForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders", "OrderId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropPrimaryKey("dbo.OrderDetails");
            DropColumn("dbo.OrderDetails", "Id");
            AddPrimaryKey("dbo.OrderDetails", "OrderId");
            AddForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders", "OrderId");
        }
    }
}
