using System;
using static System.Console;
using BookshelfDAL.ConnectedLayer;
using BookshelfDAL.Titles;
using System.Configuration;
using System.Data;

namespace BookshelfCUIClient
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("*** The Bookshelf Console UI ***\n");
            //Получить строку подключения из файла App.config
            string connectionString =
                ConfigurationManager.ConnectionStrings["BookshelfSqlProvider"].ConnectionString;
            bool userDone = false;
            string userCommand = "";
            //Создать объект BookshelfDAL
            InventoryDAL inventoryDAL = new InventoryDAL();
            inventoryDAL.OpenConnection(connectionString);
            //Запрашивать команды у пользователя до получения команды выхода
            try
            {
                ShowInstructions();
                do
                {
                    Write("\nПожалуйста, введите команду:");
                    userCommand = ReadLine();
                    WriteLine();
                    switch (userCommand?.ToUpper() ?? "")
                    {
                        case "I":
                            InsertNewBook(inventoryDAL);
                            break;
                        case "U":
                            UpdateBookReadStatus(inventoryDAL);
                            break;
                        case "D":
                            DeleteBook(inventoryDAL);
                            break;
                        case "L":
                            ListInventory(inventoryDAL);
                            break;
                        case "H":
                        case "?":
                            ShowInstructions();
                            break;
                        case "N":
                            LookUpBookName(inventoryDAL);
                            break;
                        case "Q":
                            userDone = true;
                            break;
                        default:
                            WriteLine("Неизвестная команда\n");
                            break;
                    }
                } while (!userDone);
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
                WriteLine("Нажмите любую клавишу для завершения работы...");
                ReadKey();
            }
            finally
            {
                inventoryDAL.CloseConnection();
            }
        }

        private static void ShowInstructions()
        {
            WriteLine("I: Добавить новую книгу.\n"
                + "U: Отметить книгу как прочитанную.\n"
                + "D: Удалить существующую книгу.\n"
                + "L: Вывести список всех книг.\n"
                + "H or ?: Вывести эту информацию.\n"
                + "N: Вывести название книги.\n"
                + "Q: Выход из программы.\n");
        }

        private static void ListInventory(InventoryDAL inventoryDAL)
        {
            //Получить список книг
            DataTable dataTable = inventoryDAL.GetAllInventoryAsDataTable();
            //Передать полученную таблицу во вспомогательную функцию для отображения
            DisplayTable(dataTable);
        }

        private static void DisplayTable(DataTable dataTable)
        {
            for (int currentCol = 0; currentCol < dataTable.Columns.Count; currentCol++)
            {
                Write($"{dataTable.Columns[currentCol].ColumnName}\t");
            }
            WriteLine("\n-----------------------------------------------------------");
            for (int currentRow = 0; currentRow < dataTable.Rows.Count; currentRow++)
            {
                for (int currentCol = 0; currentCol < dataTable.Columns.Count; currentCol++)
                {
                    Write($"{dataTable.Rows[currentRow][currentCol]}\t");
                }
                WriteLine();
            }
        }

        private static void DeleteBook(InventoryDAL inventoryDAL)
        {
            //Получить идентификатор книги для удаления
            int id = GetBookId();
            //Попытка удаления книги по ID
            try
            {
                inventoryDAL.DeleteBook(id);
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }
        }

        private static void InsertNewBook(InventoryDAL inventoryDAL)
        {
            //Получить данные о новой книге
            int newBookId = GetBookId();
            Write("Введите название: ");
            var newBookName = ReadLine().TrimEnd();
            Write("Введите имя автора: ");
            var newBookAuthor = ReadLine().TrimEnd();
            bool newBookRead = GetBookReadStatus();
            //Передать информацию библиотеке доступа к данным
            inventoryDAL.InsertBook(newBookId, newBookName, newBookAuthor, newBookRead);
        }

        private static void UpdateBookReadStatus(InventoryDAL inventoryDAL)
        {
            int bookId = GetBookId();
            bool bookRead = GetBookReadStatus();

            inventoryDAL.UpdateBookReadStatus(bookId, bookRead);
        }

        private static void LookUpBookName(InventoryDAL inventoryDAL)
        {
            int bookId = GetBookId();
            WriteLine(
                $"Название книги с ID {bookId}: \"{inventoryDAL.LookUpBookName(bookId).TrimEnd()}\"");
        }

        private static int GetBookId()
        {
            Write("Введите ID книги: ");
            var bookId = int.Parse(ReadLine() ?? "0");
            return bookId;
        }

        private static bool GetBookReadStatus()
        {
            Write("Была ли прочитана данная книга?(y/n): ");
            char bookReadAnswer = ReadLine().ToLower()[0];
            bool bookRead = bookReadAnswer.Equals('y') ? true : false;
            return bookRead;
        }
    }
}
