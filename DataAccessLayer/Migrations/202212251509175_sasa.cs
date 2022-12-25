namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sasa : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserProducts", "Login_UserID", "dbo.Logins");
            DropIndex("dbo.UserProducts", new[] { "Login_UserID" });
            DropPrimaryKey("dbo.UserProducts");
            AddColumn("dbo.UserProducts", "ConvertID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.UserProducts", "ProductBalance", c => c.Int(nullable: false));
            AlterColumn("dbo.UserProducts", "UserID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.UserProducts", "ConvertID");
            DropColumn("dbo.UserProducts", "ProductID");
            DropColumn("dbo.UserProducts", "ProductName");
            DropColumn("dbo.UserProducts", "ProductCarbonBalance");
            DropColumn("dbo.UserProducts", "Login_UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserProducts", "Login_UserID", c => c.Int());
            AddColumn("dbo.UserProducts", "ProductCarbonBalance", c => c.Int(nullable: false));
            AddColumn("dbo.UserProducts", "ProductName", c => c.String());
            AddColumn("dbo.UserProducts", "ProductID", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.UserProducts");
            AlterColumn("dbo.UserProducts", "UserID", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.UserProducts", "ProductBalance");
            DropColumn("dbo.UserProducts", "ConvertID");
            AddPrimaryKey("dbo.UserProducts", "UserID");
            CreateIndex("dbo.UserProducts", "Login_UserID");
            AddForeignKey("dbo.UserProducts", "Login_UserID", "dbo.Logins", "UserID");
        }
    }
}
