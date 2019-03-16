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
            WriteLine("*** Чтение данных из базы ***\n");

            //Создание строки подключения
            var connectionStringBuilder = new SqlConnectionStringBuilder
            {
                InitialCatalog = "Bookshelf",
                DataSource = @"(local)\SQLEXPRESS",
                ConnectTimeout = 30,
                IntegratedSecurity = true
            };

            //Создать и открыть подключение
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionStringBuilder.ConnectionString;
                connection.Open();
                ShowConnectionStatus(connection);

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

        static void ShowConnectionStatus(SqlConnection connection)
        {
            WriteLine("*** Информация о текущем объекте подключения ***");
            WriteLine($"Местоположение базы данных: {connection.DataSource}");
            WriteLine($"Имя базы данных: {connection.Database}");
            WriteLine($"Состояние подключения: {connection.State}\n");
        }
    }
}
