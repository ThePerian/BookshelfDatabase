using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using BookshelfDAL.Titles;

namespace BookshelfDAL.ConnectedLayer
{
    public class InventoryDAL
    {
        private SqlConnection _sqlConnection = null;

        public void OpenConnection(string connectionString)
        {
            _sqlConnection = new SqlConnection { ConnectionString = connectionString };
            _sqlConnection.Open();
        }

        public void CloseConnection()
        {
            _sqlConnection.Close();
        }

        public void InsertBook(int id, string name, string author, bool read)
        {
            //Сформировать строку запроса
            string sqlString = "Insert Into Inventory" +
                $"(Author, Name, Read) Values ('{author}', '{name}', '{read}')";
            //Выполнить запрос
            using (SqlCommand command = new SqlCommand(sqlString))
                command.ExecuteNonQuery();
        }

        public void InsertBook(NewBook book)
        {
            //Сформировать строку запроса
            string sqlString = "Insert Into Inventory" +
                "(Author, Name, Read) Values" +
                $"('{book.Author}', '{book.Name}', '{book.Read}')";
            //Выполнить запрос
            using (SqlCommand command = new SqlCommand(sqlString))
                command.ExecuteNonQuery();
        }
    }
}
