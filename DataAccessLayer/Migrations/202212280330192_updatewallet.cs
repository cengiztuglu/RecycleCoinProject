namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatewallet : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Wallets", "RcBalance", c => c.Double(nullable: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Wallets", "RcBalance", c => c.Int(nullable: false));
        }
    }
}
