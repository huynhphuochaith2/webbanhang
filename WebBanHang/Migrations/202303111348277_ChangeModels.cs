namespace WebBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeModels : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Posts", "Alias", c => c.String(maxLength: 150));
            AlterColumn("dbo.Posts", "Image", c => c.String(maxLength: 250));
            AlterColumn("dbo.Posts", "SeoTitle", c => c.String(maxLength: 250));
            AlterColumn("dbo.Posts", "SeoDescription", c => c.String(maxLength: 500));
            AlterColumn("dbo.Posts", "SeoKeywords", c => c.String(maxLength: 250));
            AlterColumn("dbo.Product", "Alias", c => c.String(maxLength: 250));
            AlterColumn("dbo.Product", "ProductCode", c => c.String(maxLength: 50));
            AlterColumn("dbo.Product", "Image", c => c.String(maxLength: 250));
            AlterColumn("dbo.Product", "SeoTitle", c => c.String(maxLength: 250));
            AlterColumn("dbo.Product", "SeoDescription", c => c.String(maxLength: 50));
            AlterColumn("dbo.Product", "SeoKeywords", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Product", "SeoKeywords", c => c.String());
            AlterColumn("dbo.Product", "SeoDescription", c => c.String());
            AlterColumn("dbo.Product", "SeoTitle", c => c.String());
            AlterColumn("dbo.Product", "Image", c => c.String());
            AlterColumn("dbo.Product", "ProductCode", c => c.String());
            AlterColumn("dbo.Product", "Alias", c => c.String());
            AlterColumn("dbo.Posts", "SeoKeywords", c => c.String());
            AlterColumn("dbo.Posts", "SeoDescription", c => c.String());
            AlterColumn("dbo.Posts", "SeoTitle", c => c.String());
            AlterColumn("dbo.Posts", "Image", c => c.String());
            AlterColumn("dbo.Posts", "Alias", c => c.String());
        }
    }
}
