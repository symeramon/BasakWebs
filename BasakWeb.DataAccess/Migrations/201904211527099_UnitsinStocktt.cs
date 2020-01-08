namespace BasakWeb.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UnitsinStocktt : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CategoryProducts", "Category_CategoryId", "dbo.Categories");
            DropForeignKey("dbo.CategoryProducts", "Product_ProductId", "dbo.Products");
            DropIndex("dbo.CategoryProducts", new[] { "Category_CategoryId" });
            DropIndex("dbo.CategoryProducts", new[] { "Product_ProductId" });
            DropTable("dbo.CategoryProducts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CategoryProducts",
                c => new
                    {
                        Category_CategoryId = c.Int(nullable: false),
                        Product_ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Category_CategoryId, t.Product_ProductId });
            
            CreateIndex("dbo.CategoryProducts", "Product_ProductId");
            CreateIndex("dbo.CategoryProducts", "Category_CategoryId");
            AddForeignKey("dbo.CategoryProducts", "Product_ProductId", "dbo.Products", "ProductId", cascadeDelete: true);
            AddForeignKey("dbo.CategoryProducts", "Category_CategoryId", "dbo.Categories", "CategoryId", cascadeDelete: true);
        }
    }
}
