namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wallet : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Wallets", "totalCarbon");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Wallets", "totalCarbon", c => c.Int());
        }
    }
}
