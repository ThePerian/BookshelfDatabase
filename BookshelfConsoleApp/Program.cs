using System;
using System.Linq;
using BookshelfConsoleApp.EF;
using static System.Console;
using System.Data;
using System.Data.Entity;

namespace BookshelfConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("***Using Entity Framework***\n");

            int bookId = AddNewRecord();

            if (bookId < 0)
                WriteLine("Не удалось добавить запись");
            else
                WriteLine($"Создана запись {bookId}");
            PrintAllInventory();

            RemoveRecord(bookId);
            WriteLine($"Удалена запись {bookId}");
            PrintAllInventory();

            WriteLine("Все книги Дж. Р. Р. Мартина:");
            PrintAllMartin();

            ReadKey();
        }

        private static int AddNewRecord()
        {
            using (var context = new BookshelfEntities())
            {
                try
                {
                    var book = new Book()
                    {
                        Author = "Брэндон Сандэрсон",
                        BookName = "Обреченное королевство",
                        ReadStatus = false
                    };
                    context.Inventory.Add(book);
                    context.SaveChanges();

                    return book.BookId;
                }
                catch(Exception ex)
                {
                    WriteLine(ex.InnerException.Message);
                    return -1;
                }
            }
        }

        private static void RemoveRecord(int bookId)
        {
            using (var context = new BookshelfEntities())
            {
                try
                {
                    var bookToRemove = context.Inventory.Find(bookId);
                    if (bookToRemove != null)
                    {
                        context.Inventory.Remove(bookToRemove);
                        context.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    WriteLine(ex.Message);
                }
            }
        }

        private static void PrintAllInventory()
        {
            using (var context = new BookshelfEntities())
            {
                //Получить все данные из таблицы Inventory
                var allData = context.Inventory.ToArray();

                //Получить проекцию новых данных
                var bookAuthors = from item in allData select new { item.BookName, item.Author };
                foreach (var item in bookAuthors)
                    WriteLine(item);
            }
        }

        private static void PrintAllMartin()
        {
            using (var context = new BookshelfEntities())
            {
                //Получить все данные из таблицы Inventory
                var allData = context.Inventory.ToArray();

                //Получить проекцию новых данных
                var bookMartin = 
                    from item in allData where item.Author == "Дж. Р. Р. Мартин" select item;
                foreach (var item in bookMartin)
                    WriteLine(item);
            }
        }

        private static void RemoveRecordUsingEntityState(int bookId)
        {
            using (var context = new BookshelfEntities())
            {
                Book bookToRemove = new Book() { BookId = bookId };
                context.Entry(bookToRemove).State = EntityState.Deleted;
                try
                {
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    WriteLine(ex.Message);
                }
            }
        }
    }
}
