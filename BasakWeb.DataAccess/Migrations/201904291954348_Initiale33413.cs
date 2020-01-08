namespace BasakWeb.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initiale33413 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "OrderDetails_OrderId", "dbo.OrderDetails");
            DropIndex("dbo.Products", new[] { "OrderDetails_OrderId" });
            RenameColumn(table: "dbo.Orders", name: "Customer_Id", newName: "CustomerID");
            RenameIndex(table: "dbo.Orders", name: "IX_Customer_Id", newName: "IX_CustomerID");
            AddColumn("dbo.OrderDetails", "ProductID", c => c.Int(nullable: false));
            AddColumn("dbo.OrderDetails", "UnitPrice", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "RequiredDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "ShipAddress", c => c.String());
            AddColumn("dbo.Orders", "ShipCity", c => c.String());
            AddColumn("dbo.Orders", "ShipRegion", c => c.String());
            CreateIndex("dbo.OrderDetails", "ProductID");
            AddForeignKey("dbo.OrderDetails", "ProductID", "dbo.Products", "ProductId", cascadeDelete: true);
            DropColumn("dbo.Products", "OrderDetails_OrderId");
            DropTable("dbo.ShippingDetails");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ShippingDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        City = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Products", "OrderDetails_OrderId", c => c.Int());
            DropForeignKey("dbo.OrderDetails", "ProductID", "dbo.Products");
            DropIndex("dbo.OrderDetails", new[] { "ProductID" });
            DropColumn("dbo.Orders", "ShipRegion");
            DropColumn("dbo.Orders", "ShipCity");
            DropColumn("dbo.Orders", "ShipAddress");
            DropColumn("dbo.Orders", "RequiredDate");
            DropColumn("dbo.OrderDetails", "UnitPrice");
            DropColumn("dbo.OrderDetails", "ProductID");
            RenameIndex(table: "dbo.Orders", name: "IX_CustomerID", newName: "IX_Customer_Id");
            RenameColumn(table: "dbo.Orders", name: "CustomerID", newName: "Customer_Id");
            CreateIndex("dbo.Products", "OrderDetails_OrderId");
            AddForeignKey("dbo.Products", "OrderDetails_OrderId", "dbo.OrderDetails", "OrderId");
        }
    }
}
