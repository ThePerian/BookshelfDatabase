using System;
using System.Collections.Generic;
using System.Data.Entity;
using BookshelfDALEF.Models;

namespace BookshelfDALEF.EF
{
    public class DataInitializer : DropCreateDatabaseAlways<BookshelfEntities>
    {
        //Инициализировать базу начальными данными
        protected override void Seed(BookshelfEntities context)
        {
            var stores = new List<Store>
            {
                new Store{ ShortName = "Ozon", URL = "ozon.ru" },
                new Store{ ShortName = "Book24", URL = "book24.ru" },
                new Store{ ShortName = "Читай-город", URL = "chitai-gorod.ru" },
                new Store{ ShortName = "Фантастика", URL = "ffan.ru" }
            };
            stores.ForEach(x => context.Stores.Add(x));

            var books = new List<Inventory>
            {
                new Inventory
                {
                    Author = "Дж. Р. Р. Мартин",
                    BookName = "Пламя и кровь. Кровь драконов",
                    ReadStatus = true
                },
                new Inventory
                {
                    Author = "Билл Уиллингхэм",
                    BookName = "Сказки. Книга 6",
                    ReadStatus = false
                },
                new Inventory
                {
                    Author = "Стив Макконнелл",
                    BookName = "Совершенный код. Мастер-класс",
                    ReadStatus = false
                },
                new Inventory
                {
                    Author = "Джеральд Бром",
                    BookName = "Похититель детей",
                    ReadStatus = false
                }
            };
            books.ForEach(x => context.Inventory.Add(x));

            var wishes = new List<Wishlist>
            {
                new Wishlist
                {
                    Author = "Дэниел Уоллес",
                    BookName = "Книга Ситхов и Путь Джедая"
                },
                new Wishlist
                {
                    Author = "Джеффри Рихтер",
                    BookName = "CLR via C#"
                },
                new Wishlist
                {
                    Author = "Марк Миллар",
                    BookName = "Росомаха. Старик Логан",
                    Store = stores[0]
                }
            };
            wishes.ForEach(x => context.Wishlist.Add(x));

            var orders = new List<Order>
            {
                new Order{ Book = wishes[0], Store = stores[2]},
                new Order{ Book = wishes[1], Store = stores[1]},
                new Order{ Book = wishes[2], Store = wishes[2].Store},
            };
            orders.ForEach(x => context.Orders.Add(x));
        }
    }
}
