namespace WebBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateQC : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Quancao", "IsHot", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Quancao", "IsHot");
        }
    }
}
