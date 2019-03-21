using System;
using System.Data;
using System.Windows.Forms;
using BookshelfDAL.DisconnectedLayer;

namespace InventoryDALDCGUI
{
    public partial class MainForm : Form
    {
        InventoryDALDC _daldc = null;
        public MainForm()
        {
            InitializeComponent();
            string connectionString =
                @"Data Source=(local)\SQLEXPRESS;Integrated Security=true;" +
                "Initial Catalog=Bookshelf;Pooling=false";
            //Создать объект доступа к данным
            _daldc = new InventoryDALDC(connectionString);
            //Заполнить элемент управления GridView
            inventoryGridView.DataSource = _daldc.GetAllInventory();
        }

        private void btnUpdateInventory_Click(object sender, EventArgs e)
        {
            //Получить модифицированные данные из GridView
            DataTable modifiedTable = (DataTable)inventoryGridView.DataSource;

            try
            {
                //Зафиксировать изменения
                _daldc.UpdateInventory(modifiedTable);
                inventoryGridView.DataSource = _daldc.GetAllInventory();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
