namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Changes",
                c => new
                    {
                        ConvertID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(),
                        Amount = c.Int(),
                        ProccesDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ConvertID)
                .ForeignKey("dbo.Logins", t => t.UserID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                        Role = c.String(),
                        UserTypeID = c.Int(),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.User_Type", t => t.UserTypeID)
                .Index(t => t.UserTypeID);
            
            CreateTable(
                "dbo.Procs",
                c => new
                    {
                        ProccesID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        ProccesDate = c.DateTime(nullable: false),
                        TotalPrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProccesID)
                .ForeignKey("dbo.Logins", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.User_Type",
                c => new
                    {
                        UserTypeID = c.Int(nullable: false, identity: true),
                        UserType = c.String(),
                    })
                .PrimaryKey(t => t.UserTypeID);
            
            CreateTable(
                "dbo.UserInfoes",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Surname = c.String(maxLength: 50),
                        PhoneNumber = c.String(maxLength: 50),
                        Sha256 = c.String(),
                        Balance = c.Double(nullable: true),
                        Login_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Logins", t => t.Login_UserID)
                .Index(t => t.Login_UserID);
            
            CreateTable(
                "dbo.Wallets",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        RcBalance = c.Double(nullable: false),
                        Sha256 = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.PendigTransactions",
                c => new
                    {
                        TransactionID = c.Int(nullable: false, identity: true),
                        FromAddres = c.String(),
                        ToAddres = c.String(),
                    })
                .PrimaryKey(t => t.TransactionID);
            
            CreateTable(
                "dbo.ProductInfoes",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        ProductTypeID = c.Int(),
                        ProductCarbon = c.Int(),
                        ProductStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.ProductTypes", t => t.ProductTypeID)
                .Index(t => t.ProductTypeID);
            
            CreateTable(
                "dbo.ProductTypes",
                c => new
                    {
                        ProductTypeID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                    })
                .PrimaryKey(t => t.ProductTypeID);
            
            CreateTable(
                "dbo.UserProducts",
                c => new
                    {
                        ConvertID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        ProductBalance = c.Int(nullable: false),
                        ProductName = c.String(),
                        ProductStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ConvertID);
            
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
            DropForeignKey("dbo.ProductInfoes", "ProductTypeID", "dbo.ProductTypes");
            DropForeignKey("dbo.WalletLogins", "Login_UserID", "dbo.Logins");
            DropForeignKey("dbo.WalletLogins", "Wallet_UserID", "dbo.Wallets");
            DropForeignKey("dbo.UserInfoes", "Login_UserID", "dbo.Logins");
            DropForeignKey("dbo.Logins", "UserTypeID", "dbo.User_Type");
            DropForeignKey("dbo.Procs", "UserID", "dbo.Logins");
            DropForeignKey("dbo.Changes", "UserID", "dbo.Logins");
            DropIndex("dbo.WalletLogins", new[] { "Login_UserID" });
            DropIndex("dbo.WalletLogins", new[] { "Wallet_UserID" });
            DropIndex("dbo.ProductInfoes", new[] { "ProductTypeID" });
            DropIndex("dbo.UserInfoes", new[] { "Login_UserID" });
            DropIndex("dbo.Procs", new[] { "UserID" });
            DropIndex("dbo.Logins", new[] { "UserTypeID" });
            DropIndex("dbo.Changes", new[] { "UserID" });
            DropTable("dbo.WalletLogins");
            DropTable("dbo.UserProducts");
            DropTable("dbo.ProductTypes");
            DropTable("dbo.ProductInfoes");
            DropTable("dbo.PendigTransactions");
            DropTable("dbo.Wallets");
            DropTable("dbo.UserInfoes");
            DropTable("dbo.User_Type");
            DropTable("dbo.Procs");
            DropTable("dbo.Logins");
            DropTable("dbo.Changes");
        }
    }
}
