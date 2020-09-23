namespace Shop.DataAcessSQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NameCorrections : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ProductCategories", newName: "Brands");
            AddColumn("dbo.CartItems", "WatchId", c => c.String());
            AddColumn("dbo.OrderItems", "WatchId", c => c.String());
            AddColumn("dbo.OrderItems", "WatchName", c => c.String());
            AddColumn("dbo.OrderItems", "WatchPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.CartItems", "ProductId");
            DropColumn("dbo.OrderItems", "ProductId");
            DropColumn("dbo.OrderItems", "ProductName");
            DropColumn("dbo.OrderItems", "ProductPrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderItems", "ProductPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.OrderItems", "ProductName", c => c.String());
            AddColumn("dbo.OrderItems", "ProductId", c => c.String());
            AddColumn("dbo.CartItems", "ProductId", c => c.String());
            DropColumn("dbo.OrderItems", "WatchPrice");
            DropColumn("dbo.OrderItems", "WatchName");
            DropColumn("dbo.OrderItems", "WatchId");
            DropColumn("dbo.CartItems", "WatchId");
            RenameTable(name: "dbo.Brands", newName: "ProductCategories");
        }
    }
}
