namespace BasakWeb.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CartLines",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Product_ProductId = c.Int(),
                        Cart_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Products", t => t.Product_ProductId)
                .ForeignKey("dbo.Carts", t => t.Cart_ID)
                .Index(t => t.Product_ProductId)
                .Index(t => t.Cart_ID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitPriceOld = c.Decimal(precision: 18, scale: 2),
                        Picture = c.String(nullable: false),
                        ProductDescription = c.String(),
                        Discount = c.Int(nullable: false),
                        Collection_ID = c.Int(),
                        OrderDetails_OrderId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Collections", t => t.Collection_ID)
                .ForeignKey("dbo.OrderDetails", t => t.OrderDetails_OrderId)
                .Index(t => t.Collection_ID)
                .Index(t => t.OrderDetails_OrderId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false),
                        Picture = c.String(),
                        CategoryDescription = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Collections",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CollectionName = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Orders", t => t.OrderId)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        ShippedDate = c.DateTime(nullable: false),
                        Customer_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.ApplicationUsers", t => t.Customer_Id)
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "dbo.ApplicationUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Address = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserRoles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.IdentityRoles", t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id);
            
            CreateTable(
                "dbo.IdentityRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CategoryProducts",
                c => new
                    {
                        Category_CategoryId = c.Int(nullable: false),
                        Product_ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Category_CategoryId, t.Product_ProductId })
                .ForeignKey("dbo.Categories", t => t.Category_CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_ProductId, cascadeDelete: true)
                .Index(t => t.Category_CategoryId)
                .Index(t => t.Product_ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRoles", "IdentityRole_Id", "dbo.IdentityRoles");
            DropForeignKey("dbo.Products", "OrderDetails_OrderId", "dbo.OrderDetails");
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "Customer_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserRoles", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserLogins", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserClaims", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.Products", "Collection_ID", "dbo.Collections");
            DropForeignKey("dbo.CartLines", "Cart_ID", "dbo.Carts");
            DropForeignKey("dbo.CartLines", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.CategoryProducts", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.CategoryProducts", "Category_CategoryId", "dbo.Categories");
            DropIndex("dbo.CategoryProducts", new[] { "Product_ProductId" });
            DropIndex("dbo.CategoryProducts", new[] { "Category_CategoryId" });
            DropIndex("dbo.IdentityUserRoles", new[] { "IdentityRole_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserLogins", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaims", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Orders", new[] { "Customer_Id" });
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropIndex("dbo.Products", new[] { "OrderDetails_OrderId" });
            DropIndex("dbo.Products", new[] { "Collection_ID" });
            DropIndex("dbo.CartLines", new[] { "Cart_ID" });
            DropIndex("dbo.CartLines", new[] { "Product_ProductId" });
            DropTable("dbo.CategoryProducts");
            DropTable("dbo.IdentityRoles");
            DropTable("dbo.IdentityUserRoles");
            DropTable("dbo.IdentityUserLogins");
            DropTable("dbo.IdentityUserClaims");
            DropTable("dbo.ApplicationUsers");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Collections");
            DropTable("dbo.Carts");
            DropTable("dbo.Categories");
            DropTable("dbo.Products");
            DropTable("dbo.CartLines");
        }
    }
}
