namespace WebBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateActive : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Category", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.News", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Posts", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Product", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "IsActive");
            DropColumn("dbo.Posts", "IsActive");
            DropColumn("dbo.News", "IsActive");
            DropColumn("dbo.Category", "IsActive");
        }
    }
}
