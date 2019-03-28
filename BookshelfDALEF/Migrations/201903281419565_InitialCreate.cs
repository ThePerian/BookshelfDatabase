namespace BookshelfDALEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Inventory",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        Author = c.String(maxLength: 50),
                        BookName = c.String(maxLength: 50),
                        ReadStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BookId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        StoreId = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Inventory", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Stores", t => t.StoreId, cascadeDelete: true)
                .Index(t => t.StoreId)
                .Index(t => t.BookId);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        StoreId = c.Int(nullable: false, identity: true),
                        ShortName = c.String(maxLength: 50),
                        URL = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.StoreId);
            
            CreateTable(
                "dbo.Wishlists",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        Author = c.String(maxLength: 50),
                        BookName = c.String(maxLength: 50),
                        StoreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "StoreId", "dbo.Stores");
            DropForeignKey("dbo.Orders", "BookId", "dbo.Inventory");
            DropIndex("dbo.Orders", new[] { "BookId" });
            DropIndex("dbo.Orders", new[] { "StoreId" });
            DropTable("dbo.Wishlists");
            DropTable("dbo.Stores");
            DropTable("dbo.Orders");
            DropTable("dbo.Inventory");
        }
    }
}
