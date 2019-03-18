using System;
using System.Data;
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
                "(Author, Name, Read)" +
                "Values (@Author, @Name, @Read)";
            //Выполнить запрос
            using (SqlCommand command = new SqlCommand(sqlString, _sqlConnection))
            {
                //Заполнить коллекцию параметров
                SqlParameter parameter = new SqlParameter
                {
                    ParameterName = "@Author",
                    Value = author,
                    SqlDbType = SqlDbType.Char,
                    Size = 50
                };
                command.Parameters.Add(parameter);

                command.Parameters.Add("@Name", SqlDbType.Char, 50);
                command.Parameters.AddWithValue("@Name", name);

                parameter = new SqlParameter("@Read", SqlDbType.Bit, 1);
                parameter.Value = read;
                command.Parameters.Add(parameter);

                command.ExecuteNonQuery();
            }
        }

        public void InsertBook(NewBook book)
        {
            //Сформировать строку запроса
            string sqlString = "Insert Into Inventory" +
                "(Author, Name, Read) Values" +
                $"('{book.Author}', '{book.Name}', '{book.Read}')";
            //Выполнить запрос
            using (SqlCommand command = new SqlCommand(sqlString, _sqlConnection))
                command.ExecuteNonQuery();
        }

        public void DeleteBook(int id)
        {
            string sqlString = $"Delete from Inventory where BookId = '{id}'";
            using (SqlCommand command = new SqlCommand(sqlString, _sqlConnection))
            {
                try
                {
                    command.ExecuteNonQuery();
                }
                catch(SqlException ex)
                {
                    //Нельзя удалить книгу, которая уже заказана
                    Exception error = new Exception("That book is already ordered!", ex);
                    throw error;
                }
            }
        }

        public void UpdateBookReadStatus(int id, bool read)
        {
            string sqlString = $"Update Inventory Set Read = '{read}' Where BookId = '{id}'";
            using (SqlCommand command = new SqlCommand(sqlString, _sqlConnection))
                command.ExecuteNonQuery();
        }

        public List<NewBook> GetAllInventoryAsList()
        {
            //Здесь будут храниться записи
            List<NewBook> inventory = new List<NewBook>();

            //Подготовить строку запроса
            string sqlString = "Select * from Inventory";
            using (SqlCommand command = new SqlCommand(sqlString, _sqlConnection))
            {
                //Выполнить запрос и прочитать данные
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    inventory.Add(new NewBook
                    {
                        BookId = (int)dataReader["BookId"],
                        Name = (string)dataReader["Name"],
                        Author = (string)dataReader["Author"],
                        Read = (bool)dataReader["Read"]
                    });
                }
                dataReader.Close();
            }
            return inventory;
        }

        public DataTable GetAllInventoryAsDataTable()
        {
            //Здесь будут храниться записи
            DataTable inventory = new DataTable();

            //Подготовить строку запроса
            string sqlString = "Select * from Inventory";
            using (SqlCommand command = new SqlCommand(sqlString, _sqlConnection))
            {
                //Выполнить запрос и прочитать данные
                SqlDataReader dataReader = command.ExecuteReader();
                inventory.Load(dataReader);
                dataReader.Close();
            }

            return inventory;
        }

        public string LookUpBookName(int bookId)
        {
            string bookName;

            //Установить имя хранимой процедуры
            using (SqlCommand command = new SqlCommand("GetName", _sqlConnection))
            {
                command.CommandType = CommandType.StoredProcedure;
                //Входной параметр
                SqlParameter parameter = new SqlParameter
                {
                    ParameterName = "@bookId",
                    SqlDbType = SqlDbType.Int,
                    Value = bookId,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parameter);
                //Выходной параметр
                parameter = new SqlParameter
                {
                    ParameterName = "@name",
                    SqlDbType = SqlDbType.Char,
                    Size = 50,
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(parameter);

                //Выполнить хранимую процедуру
                command.ExecuteNonQuery();

                //Возвратить выходной параметр
                bookName = (string)command.Parameters["@name"].Value;
            }

            return bookName;
        }
    }
}
