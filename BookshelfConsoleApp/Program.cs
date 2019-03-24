using System;
using BookshelfConsoleApp.EF;
using static System.Console;

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
                    context.Inventory.Remove(bookToRemove);
                    context.SaveChanges();
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
                foreach(Book item in context.Inventory)
                    WriteLine(item);
            }
        }
    }
}
