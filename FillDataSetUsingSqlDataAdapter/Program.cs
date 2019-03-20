using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using static System.Console;
using System.Data.Common;

namespace FillDataSetUsingSqlDataAdapter
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("*** Использование Data Adapter ***\n");
            string connectionString = @"Data Source=(local)\SQLEXPRESS;" +
                "Integrated Security=SSPI;Initial Catalog=Bookshelf";
            DataSet dataSet = new DataSet("Bookshelf");
            SqlDataAdapter adapter =
                new SqlDataAdapter("Select * from Inventory", connectionString);
            //Отобразить имена столбцов на дружественные пользователю имена
            DataTableMapping tableMapping =
                adapter.TableMappings.Add("Inventory", "Current Inventory");
            tableMapping.ColumnMappings.Add("BookId", "Book ID");
            tableMapping.ColumnMappings.Add("BookName", "Book name");
            tableMapping.ColumnMappings.Add("ReadStatus", "Read status");
            adapter.Fill(dataSet, "Inventory");
            PrintDataSet(dataSet);
            ReadKey();
        }

        static void PrintDataSet(DataSet dataSet)
        {
            WriteLine($"DataSet называется: {dataSet.DataSetName}");
            foreach (DictionaryEntry entry in dataSet.ExtendedProperties)
                Write($"Ключ = {entry.Key}, Значение = {entry.Value}");
            WriteLine();
            foreach (DataTable dataTable in dataSet.Tables)
            {
                WriteLine($"=>таблица {dataTable.TableName}:");
                for (int curCol = 0; curCol < dataTable.Columns.Count; curCol++)
                    Write($"{dataTable.Columns[curCol].ColumnName}\t");
                WriteLine("\n--------------------------------------------------");
                for (int curRow = 0; curRow < dataTable.Rows.Count; curRow++)
                {
                    for (int curCol = 0; curCol < dataTable.Columns.Count; curCol++)
                        Write($"{dataTable.Rows[curRow][curCol].ToString().Trim()}\t");
                    WriteLine();
                }
            }
        }
    }
}
