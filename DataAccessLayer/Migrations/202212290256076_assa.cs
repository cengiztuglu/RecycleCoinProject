namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class assa : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WalletLogins", "Wallet_UserID", "dbo.Wallets");
            DropForeignKey("dbo.WalletLogins", "Login_UserID", "dbo.Logins");
            DropIndex("dbo.WalletLogins", new[] { "Wallet_UserID" });
            DropIndex("dbo.WalletLogins", new[] { "Login_UserID" });
            DropTable("dbo.WalletLogins");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.WalletLogins",
                c => new
                    {
                        Wallet_UserID = c.Int(nullable: false),
                        Login_UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Wallet_UserID, t.Login_UserID });
            
            CreateIndex("dbo.WalletLogins", "Login_UserID");
            CreateIndex("dbo.WalletLogins", "Wallet_UserID");
            AddForeignKey("dbo.WalletLogins", "Login_UserID", "dbo.Logins", "UserID", cascadeDelete: true);
            AddForeignKey("dbo.WalletLogins", "Wallet_UserID", "dbo.Wallets", "UserID", cascadeDelete: true);
        }
    }
}
