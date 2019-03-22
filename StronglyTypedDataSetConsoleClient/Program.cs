using System;
using BookshelfDAL.DataSets;
using BookshelfDAL.DataSets.BookshelfDataSetTableAdapters;
using static System.Console;
using System.Data;

namespace StronglyTypedDataSetConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("*** Использование строго типизированных DataSet ***\n");

            //Создать DataSet
            var table = new BookshelfDataSet.InventoryDataTable();
            //Информировать адаптер о команде Select и подключении
            var adapter = new InventoryTableAdapter();

            //Заполнить DataSet новой таблицей Inventory
            adapter.Fill(table);
            PrintInventory(table);

            //Добавить новую строку и вывести обновленную таблицу
            int newRecordId = AddRecord(table, adapter);
            table.Clear();
            adapter.Fill(table);
            PrintInventory(table);
            
            //Удалить только что добавленную строку и вывести обновленную таблицу
            RemoveRecord(table, adapter, newRecordId);
            table.Clear();
            adapter.Fill(table);
            PrintInventory(table);

            //Найти книгу по ID
            CallStoredProcedure();

            ReadKey();
        }

        static void PrintInventory(BookshelfDataSet.InventoryDataTable table)
        {
            for (int curCol = 0; curCol < table.Columns.Count; curCol++)
                Write(table.Columns[curCol].ColumnName + "\t");
            WriteLine();

            for (int curRow = 0; curRow < table.Rows.Count; curRow++)
            {
                for (int curCol = 0; curCol < table.Columns.Count; curCol++)
                    Write(table.Rows[curRow][curCol] + "\t");
                WriteLine();
            }
            WriteLine();
        }

        public static int AddRecord(BookshelfDataSet.InventoryDataTable table,
            InventoryTableAdapter adapter)
        {
            try
            {
                //Получить из таблицы новую строго типизированную строку
                BookshelfDataSet.InventoryRow newRow = table.NewInventoryRow();

                //Заполнить строку данными
                newRow.Author = "Анджей Сапковский";
                newRow.BookName = "Последнее желание";
                newRow.ReadStatus = true;

                //Вставить новую строку
                table.AddInventoryRow(newRow);

                //Обновить базу данных
                adapter.Update(table);

                newRow = (BookshelfDataSet.InventoryRow)table.Rows[table.Rows.Count - 1];

                return newRow.BookId;
            }
            catch(Exception ex)
            {
                WriteLine(ex.Message);
                return -1;
            }
        }

        public static void RemoveRecord(BookshelfDataSet.InventoryDataTable table,
            InventoryTableAdapter adapter, int rowId)
        {
            try
            {
                BookshelfDataSet.InventoryRow rowToDelete = table.FindByBookId(rowId);
                adapter.Delete(rowToDelete.BookId, 
                    rowToDelete.BookName, rowToDelete.Author, rowToDelete.ReadStatus);
            }
            catch(Exception ex)
            {
                WriteLine(ex.Message);
            }
        }

        public static void CallStoredProcedure()
        {
            try
            {
                var queriesTableAdapter = new QueriesTableAdapter();
                Write("Введите ID книги для поиска: ");
                int bookId = int.Parse(ReadLine() ?? "0");
                string bookName = "";
                queriesTableAdapter.GetName(bookId, ref bookName);
                WriteLine($"Указанный ID соответствует книге '{bookName.Trim()}'");
            }
            catch(Exception ex)
            {
                WriteLine(ex.Message);
            }
        }
    }
}
