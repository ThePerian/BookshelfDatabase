namespace BookshelfDALEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Timestamps : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Inventory", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Orders", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Stores", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Wishlists", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            CreateIndex("dbo.Wishlists", new[] { "Author", "BookName" }, unique: true, name: "IDX_Wishlist_FullName");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Wishlists", "IDX_Wishlist_FullName");
            DropColumn("dbo.Wishlists", "Timestamp");
            DropColumn("dbo.Stores", "Timestamp");
            DropColumn("dbo.Orders", "Timestamp");
            DropColumn("dbo.Inventory", "Timestamp");
        }
    }
}
