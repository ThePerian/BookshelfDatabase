﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace MultitabledDataSetApp
{
    public partial class MainForm : Form
    {
        private DataSet _bookshelfDataSet = new DataSet("Bookshelf");

        private SqlCommandBuilder _sqlCbInventory;
        private SqlCommandBuilder _sqlCbStores;
        private SqlCommandBuilder _sqlCbOrders;

        private SqlDataAdapter _inventoryAdapter;
        private SqlDataAdapter _storesAdapter;
        private SqlDataAdapter _ordersAdapter;

        private string _connectionString;

        public MainForm()
        {
            InitializeComponent();
            //Получить строку подключения
            _connectionString =
                ConfigurationManager.ConnectionStrings["BookshelfSqlProvider"].ConnectionString;
            //Создать объекты адаптеров
            _inventoryAdapter = new SqlDataAdapter("Select * from Inventory", _connectionString);
            _storesAdapter = new SqlDataAdapter("Select * from Stores", _connectionString);
            _ordersAdapter = new SqlDataAdapter("Select * from Orders", _connectionString);
            //Автоматически сгенерировать команды
            _sqlCbInventory = new SqlCommandBuilder(_inventoryAdapter);
            _sqlCbOrders = new SqlCommandBuilder(_ordersAdapter);
            _sqlCbStores = new SqlCommandBuilder(_storesAdapter);
            //Заполнить таблицы
            _inventoryAdapter.Fill(_bookshelfDataSet, "Inventory");
            _storesAdapter.Fill(_bookshelfDataSet, "Stores");
            _ordersAdapter.Fill(_bookshelfDataSet, "Orders");
            //Построить отношения между таблицами
            BuildTableRelationship();
            //Привязаться к сеткам
            inventoryGridView.DataSource = _bookshelfDataSet.Tables["Inventory"];
            storesGridView.DataSource = _bookshelfDataSet.Tables["Stores"];
            ordersGridView.DataSource = _bookshelfDataSet.Tables["Orders"];
        }

        private void BuildTableRelationship()
        {
            //Создать объект отношения между данными StoreOrder
            DataRelation dataRelation = new DataRelation("StoreOrder",
                _bookshelfDataSet.Tables["Stores"].Columns["StoreId"],
                _bookshelfDataSet.Tables["Orders"].Columns["StoreId"]);
            _bookshelfDataSet.Relations.Add(dataRelation);

            //Создать объект отношения между данными InventoryOrder
            dataRelation = new DataRelation("InventoryOrder",
                _bookshelfDataSet.Tables["Inventory"].Columns["BookId"],
                _bookshelfDataSet.Tables["Orders"].Columns["BookId"]);
            _bookshelfDataSet.Relations.Add(dataRelation);
        }

        private void btnUpdateDatabase_Click(object sender, EventArgs e)
        {
            try
            {
                _inventoryAdapter.Update(_bookshelfDataSet, "Inventory");
                _storesAdapter.Update(_bookshelfDataSet, "Stores");
                _ordersAdapter.Update(_bookshelfDataSet, "Orders");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGetOrderInfo_Click(object sender, EventArgs e)
        {
            string orderInfo = string.Empty;
            //Получить идентификатор магазина
            int storeId = int.Parse(txtStoreId.Text);

            //На основе ID получить подходящую строку из таблицы Stores
            var storeRows = _bookshelfDataSet.Tables["Stores"].Select($"StoreId = {storeId}");
            orderInfo +=
                $"Магазин {storeRows[0]["StoreId"]}: " +
                $"{storeRows[0]["ShortName"].ToString().Trim()} " +
                $"({storeRows[0]["URL"].ToString().Trim()})\n";

            //Перейти из таблицы Stores в таблицу Orders
            var orderRows = storeRows[0].GetChildRows(_bookshelfDataSet.Relations["StoreOrder"]);

            //Пройти по всем заказам в данном магазине
            foreach(DataRow order in orderRows)
            {
                orderInfo += $"----\nНомер заказа: {order["OrderID"]}\n";

                //Получить книгу, на которую ссылается этот заказ
                DataRow[] inventoryRows =
                    order.GetParentRows(_bookshelfDataSet.Relations["InventoryOrder"]);

                //Получить информацию для книги из этого заказа
                DataRow book = inventoryRows[0];
                orderInfo += $"Автор: {book["Author"]}\n";
                orderInfo += $"Название: {book["BookName"]}\n";
            }
            MessageBox.Show(orderInfo, "Детали заказа");
        }
    }
}
