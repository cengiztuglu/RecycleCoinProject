namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProducts", "ProductName", c => c.Int(nullable: false));
            AddColumn("dbo.UserProducts", "ProductStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserProducts", "ProductStatus");
            DropColumn("dbo.UserProducts", "ProductName");
        }
    }
}
