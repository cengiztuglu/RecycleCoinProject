namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userproduct : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProducts",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        ProductName = c.String(),
                        ProductTypeID = c.Int(),
                        Login_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Logins", t => t.Login_UserID)
                .Index(t => t.Login_UserID);
            
            AddColumn("dbo.ProductInfoes", "userProduct_UserID", c => c.Int());
            CreateIndex("dbo.ProductInfoes", "userProduct_UserID");
            AddForeignKey("dbo.ProductInfoes", "userProduct_UserID", "dbo.UserProducts", "UserID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductInfoes", "userProduct_UserID", "dbo.UserProducts");
            DropForeignKey("dbo.UserProducts", "Login_UserID", "dbo.Logins");
            DropIndex("dbo.ProductInfoes", new[] { "userProduct_UserID" });
            DropIndex("dbo.UserProducts", new[] { "Login_UserID" });
            DropColumn("dbo.ProductInfoes", "userProduct_UserID");
            DropTable("dbo.UserProducts");
        }
    }
}
