namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _as : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserInfoes", "Balance", c => c.Double(nullable: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserInfoes", "Balance", c => c.Int(nullable: false));
        }
    }
}
