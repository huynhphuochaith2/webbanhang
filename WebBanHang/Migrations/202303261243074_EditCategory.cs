namespace WebBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Category", "Link", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Category", "Link");
        }
    }
}
