namespace Shop.DataAcessSQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelCorrections : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Watches", newName: "Watches");
            AddColumn("dbo.Watches", "Brand", c => c.String(nullable: false));
            DropColumn("dbo.Watches", "Category");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Watches", "Category", c => c.String(nullable: false));
            DropColumn("dbo.Watches", "Brand");
            RenameTable(name: "dbo.Watches", newName: "Watches");
        }
    }
}
