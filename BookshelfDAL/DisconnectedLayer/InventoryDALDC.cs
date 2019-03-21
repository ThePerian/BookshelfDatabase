using System;
using System.Data;
using System.Data.SqlClient;

namespace BookshelfDAL.DisconnectedLayer
{
    public class InventoryDALDC
    {
        private string _connectionString;
        private SqlDataAdapter _adapter = null;

        public InventoryDALDC(string connectionString)
        {
            _connectionString = connectionString;
            ConfigureAdapter(out _adapter);
        }

        private void ConfigureAdapter(out SqlDataAdapter adapter)
        {
            //Создать адаптер и настроить SelectCommand
            adapter = new SqlDataAdapter("Select * from Inventory", _connectionString);

            //Динамически получить остальные объекты команд во время выполнения
            var builder = new SqlCommandBuilder(adapter);
        }

        public DataTable GetAllInventory()
        {
            DataTable inventory = new DataTable("Inventory");
            //Получить все записи в таблице Inventory
            _adapter.Fill(inventory);
            return inventory;
        }

        public void UpdateInventory(DataTable modifiedTable)
        {
            //Проверить RowState у каждой строки таблицы и при необходимости внести изменения
            _adapter.Update(modifiedTable);
        }

        
    }
}
