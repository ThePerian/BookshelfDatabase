using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsDataBinding
{
    public partial class MainForm : Form
    {
        List<Book> listBooks = null;
        DataTable inventoryTable = new DataTable();
        DataView tolkienOnlyView;

        public MainForm()
        {
            InitializeComponent();
            listBooks = new List<Book>
            {
                new Book { Id = 1, BookName = "Хоббит", Author = "Джон Толкин", ReadStatus = true},
                new Book { Id = 2, BookName = "Танец с драконами",
                    Author = "Джордж Мартин", ReadStatus = true},
                new Book {Id = 3, BookName = "Хроники Амбера",
                    Author = "Роджер Желязны", ReadStatus = false},
            };
            CreateDataTable();
            CreateDataView();
        }

        void CreateDataTable()
        {
            //Создать схему таблицы
            DataColumn bookIdCol = new DataColumn("Id", typeof(int));
            DataColumn bookNameCol = new DataColumn("BookName", typeof(string))
            { Caption = "Book name" };
            DataColumn bookAuthorCol = new DataColumn("Author", typeof(string));
            DataColumn bookReadStatusCol = new DataColumn("ReadStatus", typeof(bool))
            { Caption = "Read status" };
            inventoryTable.Columns.AddRange(
                new[] { bookIdCol, bookNameCol, bookAuthorCol, bookReadStatusCol });

            //Пройти по элементам списка для создания строк
            foreach (var elem in listBooks)
            {
                DataRow row = inventoryTable.NewRow();
                row["Id"] = elem.Id;
                row["BookName"] = elem.BookName;
                row["Author"] = elem.Author;
                row["ReadStatus"] = elem.ReadStatus;
                inventoryTable.Rows.Add(row);
            }

            //Привязать объект DataTable к bookInventoryGridView
            bookInventoryGridView.DataSource = inventoryTable;
        }

        private void btnRemoveRow_Click(object sender, EventArgs e)
        {
            try
            {
                //Найти корректную строку для удаления
                DataRow[] rowToDelete =
                    inventoryTable.Select($"Id={int.Parse(txtRowToRemove.Text)}");

                //Удалить строку
                rowToDelete[0].Delete();
                inventoryTable.AcceptChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDisplayAuthor_Click(object sender, EventArgs e)
        {
            //Построить фильтр на основе пользовательского ввода
            string filter = $"Author Like '%{txtAuthorToView.Text}%'";
            //Найти все строки, удовлетворяющие фильтру
            DataRow[] authors = inventoryTable.Select(filter, "BookName ASC");
            //Показать полученные результаты
            if (authors.Length == 0)
                MessageBox.Show("Авторов не найдено!", "Ошибка выборки");
            else
            {
                string authorString = null;
                for (int i = 0; i < authors.Length; i++)
                    authorString += $"{authors[i]["BookName"]}\n";
                //Вывести все результаты в окне сообщений
                MessageBox.Show(authorString, $"Найдены книги автора {txtAuthorToView.Text}:");
            }
        }

        private void btnChangeReads_Click(object sender, EventArgs e)
        {
            //Убедиться, что пользователь уверен в своих действиях
            if (MessageBox.Show("Вы уверены?", "Подтверждение", MessageBoxButtons.YesNo)
                != DialogResult.Yes)
                return;
            //Построить фильтр
            string filter = "";
            //Найти все строки, соответствующие фильтру
            DataRow[] authors = inventoryTable.Select(filter);
            //Отметить книги как прочитанные
            for (int i = 0; i < authors.Length; i++)
                authors[i]["ReadStatus"] = true;
        }

        private void CreateDataView()
        {
            //Установить таблицу, которая используется для создания этого представления
            tolkienOnlyView = new DataView(inventoryTable);
            //Сконфигурировать представление с применением фильтра
            tolkienOnlyView.RowFilter = "Author = 'Джон Толкин'";
            //Привязать к новому элементу DataGridView
            tolkienOnlyGridView.DataSource = tolkienOnlyView;
        }
    }
}
