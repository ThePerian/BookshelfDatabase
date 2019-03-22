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

            var table = new BookshelfDataSet.InventoryDataTable();
            var adapter = new InventoryTableAdapter();

            adapter.Fill(table);
            PrintInventory(table);
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
        }
    }
}
