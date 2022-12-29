namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Wallets", "Sha256", c => c.String(nullable: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Wallets", "Sha256", c => c.String());
        }
    }
}
