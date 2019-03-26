using System;
using System.Collections.Generic;
using System.Data.Entity;
using BookshelfDALEF.Models;

namespace BookshelfDALEF.EF
{
    class DataInitializer : DropCreateDatabaseAlways<BookshelfEntities>
    {
        //Инициализировать базу начальными данными
        protected override void Seed(BookshelfEntities context)
        {
            var stores = new List<Store>
            {
                new Store{ ShortName = "Ozon", URL = "ozon.ru" },
                new Store{ ShortName = "Book24", URL = "book24.ru" },
                new Store{ ShortName = "Читай-город", URL = "chitai-gorod.ru" }
            };
            stores.ForEach(x => context.Stores.Add(x));

            var books = new List<Inventory>
            {
                new Inventory{ Author = "Билл Уиллингхэм",
                    BookName = "Сказки. Книга 6", ReadStatus = false },
                new Inventory{ Author = "Стив Макконнелл",
                    BookName = "Совершенный код. Мастер-класс", ReadStatus = false },
                new Inventory{ Author = "Джеральд Бром",
                    BookName = "Похититель детей", ReadStatus = false }
            };
            books.ForEach(x => context.Inventory.Add(x));

            var orders = new List<Order>
            {
                new Order{ Book = books[0], Store = stores[0]},
                new Order{ Book = books[1], Store = stores[1]},
                new Order{ Book = books[2], Store = stores[3]},
            };
            orders.ForEach(x => context.Orders.Add(x));

            context.Wishlist.Add(
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
