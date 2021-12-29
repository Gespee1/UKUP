using System;
using System.Data;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace РасчетКУ
{
    public partial class SelectProductForm : Form
    {
        private SqlConnection _sqlConnection;
        private Int64 VendorId;
        private List<Int64> ProdId;

        public SelectProductForm()
        {
            InitializeComponent();
        }

        public SelectProductForm(Int64 id, ref List<Int64> prodId)
        {
            VendorId = id;
            ProdId = prodId;
            InitializeComponent();
        }

        // Подключение к БД, Вывод ассортимента поставщика
        private void SelectForm_Load(object sender, EventArgs e)
        {
            _sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB1"].ConnectionString);
            _sqlConnection.Open();

            // Отображение имени поставщика в шапке
            SqlCommand command = new SqlCommand($"SELECT Name FROM Vendors WHERE Vendor_id = {VendorId}", _sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            labelMain.Text = $"Товары поставщика {reader[0]}";
            reader.Close();

            command = new SqlCommand($"SELECT Name AS 'Наименование', Classifier_id AS 'Ид классификатора', BrandProdID AS 'Ид произв. и торг. марки' FROM Assortment, Products " +
                $"WHERE Assortment.Product_id = Products.Product_id AND Assortment.Vendor_id = {VendorId}", _sqlConnection);

            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = command;
            adapt.Fill(dt);
            advancedDataGridViewProducts.DataSource = dt;
            for (int i = 0; i < advancedDataGridViewProducts.ColumnCount; i++)
                advancedDataGridViewProducts.Columns[i].ReadOnly = true;

            advancedDataGridViewProducts.Columns.AddRange(new DataGridViewCheckBoxColumn());
            advancedDataGridViewProducts.Columns[advancedDataGridViewProducts.ColumnCount - 1].HeaderText = "Выбрать";
            advancedDataGridViewProducts.Columns[advancedDataGridViewProducts.ColumnCount - 1].Name = "checkBoxes";

            ADGV.ADGVColumnHeaderCell headCell = advancedDataGridViewProducts.Columns[advancedDataGridViewProducts.ColumnCount - 1].HeaderCell as ADGV.ADGVColumnHeaderCell;
            headCell.FilterEnabled = false;
            
            showRowCount();
            doResize();
        }

        // Фильтрация товаров
        private void advancedDataGridView1_FilterStringChanged(object sender, EventArgs e)
        {
            (advancedDataGridViewProducts.DataSource as DataTable).DefaultView.RowFilter = advancedDataGridViewProducts.FilterString;
            showRowCount();
        }

        // Сортировка товаров
        private void advancedDataGridView1_SortStringChanged(object sender, EventArgs e)
        {
            (advancedDataGridViewProducts.DataSource as DataTable).DefaultView.Sort = advancedDataGridViewProducts.SortString;
            showRowCount();
        }

        // Показать общее кол-во отображенных строк
        private void showRowCount()
        {
            labelShownProducts.Text = "Отображено товаров: " + advancedDataGridViewProducts.RowCount;
        }

        // Добавление выбранных товаров
        private void button1_Click(object sender, EventArgs e)
        {
            bool emptyFlag = true;
            for(int i = 0; i < advancedDataGridViewProducts.RowCount; i++)
            {
                if(Convert.ToBoolean(advancedDataGridViewProducts.Rows[i].Cells["checkBoxes"].Value) == true)
                {
                    SqlCommand command = new SqlCommand($"SELECT Product_id FROM Products WHERE Name = '{advancedDataGridViewProducts.Rows[i].Cells["Name"].Value}'", _sqlConnection);
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    ProdId.Add(Convert.ToInt64(reader[0]));
                    reader.Close();
                    emptyFlag = false;
                }
            }
            if (emptyFlag)
                MessageBox.Show("Не выбрано ни одного товара для добавления!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
                
        }

        // Кнопка отмены
        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // Закрытие подключения к БД
        private void SelectForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _sqlConnection.Close();
        }

        private void SelectProductForm_Resize(object sender, EventArgs e)
        {
            doResize();
        }

        // Изменение размера формы
        private void doResize()
        {
            panel2.Height = buttonAddSelected.Location.Y - panel1.Height;
        }
    }
}
