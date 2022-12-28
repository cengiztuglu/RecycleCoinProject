namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class type : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserProducts", "ProductName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserProducts", "ProductName", c => c.Int(nullable: false));
        }
    }
}
