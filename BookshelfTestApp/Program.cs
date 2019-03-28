using System;
using System.Collections.Generic;
using System.Data.Entity;
using BookshelfDALEF.EF;
using BookshelfDALEF.Repos;
using BookshelfDALEF.Models;
using static System.Console;
using System.Linq;
using System.Data.Entity.Infrastructure;

namespace BookshelfTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new DataInitializer());
            WriteLine("*** Using ADO.NET EF Code First ***\n");

            var book1 = new Inventory()
            {
                Author = "Дж. Р. Р. Мартин",
                BookName = "Пламя и кровь. Кровь драконов",
                ReadStatus = true
            };
            var book2 = new Inventory()
            {
                Author = "Джеральд Бром",
                BookName = "Крампус, Повелитель Йоля",
                ReadStatus = false
            };
            var book3 = new Inventory()
            {
                Author = "Дж. Р. Р. Толкин",
                BookName = "Сильмариллион",
                ReadStatus = true
            };
            AddNewRecord(book1);
            AddNewRecordRange(new List<Inventory> { book2, book3});

            UpdateRecord(book1.BookId);

            PrintAllInventory();
            ShowAllOrders();
            ShowAllOrdersEagerlyFetched();

            PrintWholeInventoryAndWishlist();
            var wishlistRepo = new WishlistRepo();
            var book = wishlistRepo.GetOne(1);
            wishlistRepo.Context.Entry(book).State = EntityState.Detached;
            var purchasedBook = PurchaseBook(book);
            PrintWholeInventoryAndWishlist();

            ReadKey();
        }

        private static void PrintAllInventory()
        {
            using (var repo = new InventoryRepo())
            {
                foreach (Inventory item in repo.GetAll())
                    WriteLine(item);
            }
        }

        private static void AddNewRecord(Inventory book)
        {
            using (var repo = new InventoryRepo())
            {
                repo.Add(book);
            }
        }

        private static void AddNewRecordRange(IList<Inventory> books)
        {
            using (var repo = new InventoryRepo())
            {
                repo.AddRange(books);
            }
        }

        private static void UpdateRecord(int bookId)
        {
            using (var repo = new InventoryRepo())
            {
                var bookToUpdate = repo.GetOne(bookId);
                if (bookToUpdate != null)
                {
                    WriteLine("До изменений: " + repo.Context.Entry(bookToUpdate).State);
                    bookToUpdate.ReadStatus = !bookToUpdate.ReadStatus;
                    WriteLine("После изменений: " + repo.Context.Entry(bookToUpdate).State);
                    repo.Save(bookToUpdate);
                    WriteLine("После сохранения: " + repo.Context.Entry(bookToUpdate).State);
                }
            }
        }

        private static void ShowAllOrders()
        {
            using (var repo = new OrderRepo())
            {
                WriteLine("*** Ожидаемые заказы ***\n");
                foreach (var item in repo.GetAll())
                    WriteLine($"->в магазине {item.Store.ShortName} заказана книга {item.Book.BookName}");
            }
        }

        private static void ShowAllOrdersEagerlyFetched()
        {
            using (var context = new BookshelfEntities())
            {
                WriteLine("*** Ожидаемые заказы ***\n");
                var orders = context.Orders.Include(x => x.Store).Include(y => y.Book).ToList();
                foreach (var item in orders)
                    WriteLine($"->в магазине {item.Store.ShortName} заказана книга {item.Book.BookName}");
            }
        }

        private static Inventory PurchaseBook(Wishlist book)
        {
            using (var context = new BookshelfEntities())
            {
                context.Wishlist.Attach(book);
                context.Wishlist.Remove(book);
                var purchasedBook = new Inventory()
                {
                    Author = book.Author,
                    BookName = book.BookName,
                    ReadStatus = false
                };
                context.Inventory.Add(purchasedBook);
                try
                {
                    context.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    WriteLine(ex.Message);
                }

                return purchasedBook;
            }
        }

        private static void PrintWholeInventoryAndWishlist()
        {
            WriteLine("*** Inventory ***\n");
            using (var repo = new InventoryRepo())
            {
                foreach (var item in repo.GetAll())
                    WriteLine($"->{item.Author} \"{item.BookName}\"");
            }
            WriteLine("*** Wishlist ***\n");
            using (var repo = new WishlistRepo())
            {
                foreach (var item in repo.GetAll())
                    WriteLine($"->{item.Author} \"{item.BookName}\"");
            }
        }
    }
}
