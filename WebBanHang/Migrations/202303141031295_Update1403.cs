namespace WebBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update1403 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductImage",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Image = c.String(),
                        IsDefault = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductImage", "ProductId", "dbo.Product");
            DropIndex("dbo.ProductImage", new[] { "ProductId" });
            DropTable("dbo.ProductImage");
        }
    }
}
