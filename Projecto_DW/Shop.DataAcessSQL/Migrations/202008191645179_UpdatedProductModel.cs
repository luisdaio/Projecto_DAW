namespace Shop.DataAcessSQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedProductModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Watches", "Image", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Watches", "Image", c => c.String(nullable: false));
        }
    }
}
