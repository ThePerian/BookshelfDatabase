using System;
using BookshelfDAL.ConnectedLayer;
using BookshelfDAL.Titles;
using static System.Console;

namespace AdoNetTransaction
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("*** Пример транзакции ***\n");

            //Способ позволить транзакции успешно выполниться или отказать
            bool throwEx = true;
            int bookId;

            Write("Введите ID книги: ");
            bookId = int.Parse(ReadLine());
            Write("Хотите ли сгенерировать исключение? (Y/N): ");
            var userAnswer = ReadLine();
            if (userAnswer?.ToLower() == "n")
                throwEx = false;

            var dal = new InventoryDAL();
            dal.OpenConnection(@"Data Source=(local)\SQLEXPRESS;Integrated Security=SSPI;" +
                "Initial Catalog=Bookshelf");

            //Перенести книгу с указанным идентификатором из одной таблицы в другую
            dal.ProcessPurchase(throwEx, bookId);
            WriteLine("Транзакция проведена. Нажмите любую клавишу для завершения...");
            ReadKey();
        }
    }
}
