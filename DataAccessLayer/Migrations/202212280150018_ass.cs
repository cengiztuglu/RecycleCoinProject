namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Wallets", "Sha256", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Wallets", "Sha256");
        }
    }
}
