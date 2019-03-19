using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using BookshelfDAL.Titles;
using static System.Console;

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
                "(Author, BookName, ReadStatus)" +
                "Values (@Author, @BookName, @ReadStatus)";
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

                parameter = new SqlParameter
                {
                    ParameterName = "@BookName",
                    Value = name,
                    SqlDbType = SqlDbType.Char,
                    Size = 50
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@ReadStatus", SqlDbType.Bit, 1);
                parameter.Value = read?1:0;
                command.Parameters.Add(parameter);

                command.ExecuteNonQuery();
            }
        }

        public void InsertBook(NewBook book)
        {
            //Сформировать строку запроса
            string sqlString = "Insert Into Inventory" +
                "(Author, BookName, ReadStatus) Values" +
                $"('{book.Author}', '{book.BookName}', '{book.ReadStatus}')";
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
            string sqlString = $"Update Inventory Set ReadStatus = '{(read?1:0)}' Where BookId = '{id}'";
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
                        BookName = (string)dataReader["BookName"],
                        Author = (string)dataReader["Author"],
                        ReadStatus = (bool)dataReader["ReadStatus"]
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
                    ParameterName = "@bookName",
                    SqlDbType = SqlDbType.Char,
                    Size = 50,
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(parameter);

                //Выполнить хранимую процедуру
                command.ExecuteNonQuery();

                //Возвратить выходной параметр
                bookName = (string)command.Parameters["@bookName"].Value;
            }

            return bookName;
        }

        public void ProcessPurchase(bool throwEx, int bookId)
        {
            //Определить название книги и имя автора по идентификатору
            string bookName;
            string author;
            var cmdSelect =
                new SqlCommand($"Select * from Wishlist where BookId = {bookId}", _sqlConnection);
            using (var dataReader = cmdSelect.ExecuteReader())
            {
                if (dataReader.HasRows)
                {
                    dataReader.Read();
                    bookName = (string)dataReader["BookName"];
                    author = (string)dataReader["Author"];
                }
                else
                    return;
            }

            //Создать объекты комманд для каждого шага операции
            var cmdRemove =
                new SqlCommand($"Delete from Wishlist where BookId = {bookId}", _sqlConnection);

            var cmdInsert =
                new SqlCommand($"Insert into Inventory" +
                $"(BookName, Author, ReadStatus) Values('{bookName}', '{author}', '0')",
                _sqlConnection);

            SqlTransaction transaction = null;
            try
            {
                transaction = _sqlConnection.BeginTransaction();
                //Включить команды в транзакцию
                cmdInsert.Transaction = transaction;
                cmdRemove.Transaction = transaction;
                //Выполнить команды
                cmdInsert.ExecuteNonQuery();
                cmdRemove.ExecuteNonQuery();
                //Эмулировать ошибку
                if (throwEx)
                {
                    throw new Exception("Ошибка базы данных! Транзакция не удалась!");
                }
                //Зафиксировать транзакцию
                transaction.Commit();
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
                //Любая ошибка приводит к откату транзакции
                transaction?.Rollback();
            }
        }
    }
}
