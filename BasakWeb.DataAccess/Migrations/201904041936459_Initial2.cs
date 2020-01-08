namespace BasakWeb.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Collection_ID", "dbo.Collections");
            DropIndex("dbo.Products", new[] { "Collection_ID" });
            AlterColumn("dbo.Products", "Collection_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "Collection_Id");
            AddForeignKey("dbo.Products", "Collection_Id", "dbo.Collections", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Collection_Id", "dbo.Collections");
            DropIndex("dbo.Products", new[] { "Collection_Id" });
            AlterColumn("dbo.Products", "Collection_Id", c => c.Int());
            CreateIndex("dbo.Products", "Collection_ID");
            AddForeignKey("dbo.Products", "Collection_ID", "dbo.Collections", "ID");
        }
    }
}
