namespace BasakWeb.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialesz1111 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Collections", "Silindi", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Collections", "Silindi");
        }
    }
}
