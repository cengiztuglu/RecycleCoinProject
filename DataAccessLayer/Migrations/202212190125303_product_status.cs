namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class product_status : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductInfoes", "ProductStatus", c => c.Boolean(nullable:true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductInfoes", "ProductStatus");
        }
    }
}
