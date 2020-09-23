namespace Shop.DataAcessSQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WatchModelCorrection : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Watches", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Watches", "Name", c => c.String(nullable: false, maxLength: 20));
        }
    }
}
