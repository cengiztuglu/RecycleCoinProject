namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rcbalance : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Wallets", "RcBalance", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Wallets", "RcBalance");
        }
    }
}
