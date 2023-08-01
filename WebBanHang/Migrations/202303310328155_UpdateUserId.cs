namespace WebBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Order", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Order", "UserId");
        }
    }
}
