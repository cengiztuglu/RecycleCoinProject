namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Wallets",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        totalCarbon = c.Int(),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.WalletLogins",
                c => new
                    {
                        Wallet_UserID = c.Int(nullable: false),
                        Login_UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Wallet_UserID, t.Login_UserID })
                .ForeignKey("dbo.Wallets", t => t.Wallet_UserID, cascadeDelete: true)
                .ForeignKey("dbo.Logins", t => t.Login_UserID, cascadeDelete: true)
                .Index(t => t.Wallet_UserID)
                .Index(t => t.Login_UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WalletLogins", "Login_UserID", "dbo.Logins");
            DropForeignKey("dbo.WalletLogins", "Wallet_UserID", "dbo.Wallets");
            DropIndex("dbo.WalletLogins", new[] { "Login_UserID" });
            DropIndex("dbo.WalletLogins", new[] { "Wallet_UserID" });
            DropTable("dbo.WalletLogins");
            DropTable("dbo.Wallets");
        }
    }
}
