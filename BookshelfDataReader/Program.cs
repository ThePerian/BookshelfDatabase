using System;
using System.Data;
using System.Data.SqlClient;
using static System.Console;

namespace BookshelfDataReader
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("*** Using Data Readers ***\n");

            //Создать и открыть подключение
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString =
                    @"Data Source=(local)\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=Bookshelf";
                connection.Open();

                //Создать объект команды SQL
                string sqlString = "Select * From Inventory";
                SqlCommand sqlCommand = new SqlCommand(sqlString, connection);

                //Получить объект чтения данных
                using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        WriteLine($"->Автор: {dataReader["Author"]}, Название: {dataReader["Name"]}, Прочитано:" +
                            ((bool)dataReader["Read"] ? "Да" : "Нет"));
                    }
                }
            }
            ReadLine();
        }
    }
}
