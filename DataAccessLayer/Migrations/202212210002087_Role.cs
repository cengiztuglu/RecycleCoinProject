namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Role : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Logins", "Role", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Logins", "Role");
        }
    }
}
