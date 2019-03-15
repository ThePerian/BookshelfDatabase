using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using static System.Console;

namespace DataProviderFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("*** Example of Data Provider Factory ***\n");
            //Получить строку подключения и поставщика из app.config
            string dataProvider = ConfigurationManager.AppSettings["provider"];
            string connectionString = ConfigurationManager.AppSettings["connectionString"];

            //Получить фабрику поставщиков
            DbProviderFactory factory = DbProviderFactories.GetFactory(dataProvider);

            //Получить объект подключения
            using (DbConnection connection = factory.CreateConnection())
            {
                if (connection == null)
                {
                    ShowError("No connection to database");
                    return;
                }

                WriteLine($"Your connection object is a: {connection.GetType().Name}");
                connection.ConnectionString = connectionString;
                connection.Open();

                //Создать объект команды
                DbCommand command = factory.CreateCommand();
                if (command == null)
                {
                    ShowError("Unable to create command");
                    return;
                }

                WriteLine($"Your command object is a: {command.GetType().Name}");
                command.Connection = connection;
                command.CommandText = "Select * From Inventory";

                //Вывести данные с помощью объекта чтения данных
                using (DbDataReader dataReader = command.ExecuteReader())
                {
                    WriteLine($"Your data reader object is a: {dataReader.GetType().Name}");
                    WriteLine("\n*** Current Inventory ***");
                    while (dataReader.Read())
                        WriteLine($"-> Book #{dataReader["BookId"]} is written by {dataReader["Author"]}.");
                }
            }
            ReadLine();
        }

        private static void ShowError(string errorString)
        {
            WriteLine($"Program encountered an error: {errorString}");
            ReadLine();
        }
    }
}
