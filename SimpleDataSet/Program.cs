using System;
using System.Data;
using static System.Console;
using System.Collections;

namespace SimpleDataSet
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("*** Использование DataSet ***\n");

            DataSet booksInventoryDS = new DataSet("Book Inventory");

            booksInventoryDS.ExtendedProperties["TimeStamp"] = DateTime.Now;
            booksInventoryDS.ExtendedProperties["DataSetID"] = Guid.NewGuid();
            booksInventoryDS.ExtendedProperties["Title"] = "Home Library";

            FillDataSet(booksInventoryDS);
            PrintDataSet(booksInventoryDS);

            ReadKey();
        }

        static void FillDataSet(DataSet dataSet)
        {
            //Создать столбцы и добавить в таблицу
            //для ключевого столбца ID указать уникальность и автоинкремент начиная с 1 с шагом 1
            DataColumn bookIdColumn = new DataColumn("BookID", typeof(int))
            {
                Caption = "Book ID",
                ReadOnly = true,
                AllowDBNull = false,
                Unique = true,
                AutoIncrement = true,
                AutoIncrementSeed = 1,
                AutoIncrementStep = 1
            };

            DataColumn bookNameColumn = new DataColumn("BookName", typeof(string))
            {
                Caption = "Book name"
            };
            DataColumn bookAuthorColumn = new DataColumn("Author", typeof(string));
            DataColumn bookReadStatusColumn = new DataColumn("ReadStatus", typeof(bool));

            DataTable inventoryTable = new DataTable("Inventory");
            inventoryTable.Columns.AddRange(
                new[] { bookIdColumn, bookNameColumn, bookAuthorColumn, bookReadStatusColumn });

            //Добавить строки в созданную таблицу
            DataRow bookRow = inventoryTable.NewRow();
            bookRow["BookName"] = "Зов Ктулху";
            bookRow["Author"] = "Говард Филлипс Лавкрафт";
            bookRow["ReadStatus"] = true;
            inventoryTable.Rows.Add(bookRow);

            bookRow = inventoryTable.NewRow();
            bookRow[1] = "Хребты безумия";
            bookRow[2] = "Говард Филлипс Лавкрафт";
            bookRow[3] = false;
            inventoryTable.Rows.Add(bookRow);

            //Установить первичный ключ
            inventoryTable.PrimaryKey = new[] { inventoryTable.Columns[0] };

            //Добавить таблицу в DataSet
            dataSet.Tables.Add(inventoryTable);
        }

        static void PrintDataSet(DataSet dataSet)
        {
            WriteLine($"DataSet называется: {dataSet.DataSetName}");
            foreach (DictionaryEntry entry in dataSet.ExtendedProperties)
                WriteLine($"Ключ = {entry.Key}, Значение = {entry.Value}");
            WriteLine();

            foreach (DataTable table in dataSet.Tables)
            {
                WriteLine($"=> таблица {table.TableName}:");
                for (int curCol = 0; curCol < table.Columns.Count; curCol++)
                    Write($"{table.Columns[curCol].ColumnName}\t");
                WriteLine("\n--------------------------------------------------");

                PrintTable(table);
            }
        }

        static void PrintTable(DataTable dataTable)
        {
            DataTableReader dataTableReader = dataTable.CreateDataReader();
            while(dataTableReader.Read())
            {
                for (int i = 0; i < dataTableReader.FieldCount; i++)
                    Write($"{dataTableReader.GetValue(i).ToString().Trim()}\t");
                WriteLine();
            }
            dataTableReader.Close();
        }
    }
}
