namespace BookshelfDALEF.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using BookshelfDALEF.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<BookshelfDALEF.EF.BookshelfEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "BookshelfDALEF.EF.BookshelfEntities";
        }

        protected override void Seed(BookshelfDALEF.EF.BookshelfEntities context)
        {
            var stores = new List<Store>
            {
                new Store{ ShortName = "Ozon", URL = "ozon.ru" },
                new Store{ ShortName = "Book24", URL = "book24.ru" },
                new Store{ ShortName = "Читай-город", URL = "chitai-gorod.ru" }
            };
            stores.ForEach(x => 
                context.Stores.AddOrUpdate(s => new { s.ShortName, s.URL }, x));
            
            var books = new List<Inventory>
            {
                new Inventory{ Author = "Билл Уиллингхэм",
                    BookName = "Сказки. Книга 6", ReadStatus = false },
                new Inventory{ Author = "Стив Макконнелл",
                    BookName = "Совершенный код. Мастер-класс", ReadStatus = false },
                new Inventory{ Author = "Джеральд Бром",
                    BookName = "Похититель детей", ReadStatus = false }
            };
            books.ForEach(x => 
                context.Inventory.AddOrUpdate(i => new { i.Author, i.BookName, i.ReadStatus }, x));
                
            var orders = new List<Order>
            {
                new Order{ Book = books[0], Store = stores[0]},
                new Order{ Book = books[1], Store = stores[1]},
                new Order{ Book = books[2], Store = stores[2]},
            };
            orders.ForEach(x => 
                context.Orders.AddOrUpdate(o => new { o.BookId, o.StoreId }, x));
                
            context.Wishlist.AddOrUpdate( w => new { w.Author, w.BookName },
                new Wishlist
                {
                    Author = "Джеффри Рихтер",
                    BookName = "CLR via C#",
                    StoreId = stores[0].StoreId
                });
            context.SaveChanges();
        }
    }
}
