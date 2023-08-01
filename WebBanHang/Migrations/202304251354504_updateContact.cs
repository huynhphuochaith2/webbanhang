namespace WebBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateContact : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contact", "Phone", c => c.String());
            AddColumn("dbo.Contact", "Alias", c => c.String());
            DropColumn("dbo.Contact", "Website");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contact", "Website", c => c.String());
            DropColumn("dbo.Contact", "Alias");
            DropColumn("dbo.Contact", "Phone");
        }
    }
}
