using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace РасчетКУ
{
    public partial class ListForm : Form
    {
        private SqlConnection _sqlConnection;
        private bool invoice = false; //Выведены накладные
        public ListForm()
        {
            InitializeComponent();
        }

        // Открытие соединения с БД
        private void VendorsListForm_Load(object sender, EventArgs e)
        {
            _sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB1"].ConnectionString);
            _sqlConnection.Open();

            Size = MinimumSize;
            panel2.Visible = false;
            doResize();
            bool invoice = false; //Выведены накладные
        }
        
        

        // Вывод списка поставщиков
        private void vend_button_Click(object sender, EventArgs e)
        {
            invoice = false;
            Size = new System.Drawing.Size(1230, 700);
            panel2.Visible = true;

            SqlCommand command = new SqlCommand("SELECT Entity_id As 'Код юр. лица', Vendor_foreign_id As 'Внешний код поставщика', Name As 'Поставщик', " +
                "Urastic_name As 'Юридическое имя', [INN\\KPP] As 'ИНН\\КПП', Director_name As 'Директор', Urastic_address As 'Юр. адрес', Account As 'Счет', " +
                "Bank_name As 'Наименование банка', Bank_bik As 'БИК банка', Corr_account As 'Корр. аккаунт', Dir_party FROM Vendors", _sqlConnection);
            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = command;

            adapt.Fill(dt);
            advancedDataGridView.DataSource = dt;
            labelRows.Visible = true;
            labelRows.Text = $"Кол-во выведенных строк: {dt.Rows.Count}";
        }
        // Вывод классификатора
        private void buttonClassifier_Click(object sender, EventArgs e)
        {
            invoice = false;
            Size = new System.Drawing.Size(1230, 700);
            panel2.Visible = true;

            SqlCommand command = new SqlCommand("SELECT L1 As 'Код 1 категории', L1_name As 'Категория 1', L2 As 'Код 2 категории', L2_name As 'Категория 2', " +
                "L3 As 'Код 3 категории', L3_name As 'Категория 3', L4 As 'Код 4 категории', L4_name As 'Категория 4' FROM Classifier", _sqlConnection);
            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = command;

            adapt.Fill(dt);
            advancedDataGridView.DataSource = dt;
            labelRows.Visible = true;
            labelRows.Text = $"Кол-во выведенных строк: {dt.Rows.Count}";
        }
        // Вывод юр. лиц
        private void buttonEntities_Click(object sender, EventArgs e)
        {
            invoice = false;
            Size = new System.Drawing.Size(1000, 490);
            panel2.Visible = true;

            SqlCommand command = new SqlCommand("SELECT Name As 'Юр. лицо', Director_name As 'Имя директора', Urastic_name As 'Юр. имя', Urastic_address As 'Юр. адрес', " +
                "[INN\\KPP] As 'ИНН\\КПП', Bank_name As 'Название банка', Account As 'Счет', Corr_account As 'Корр. счет', Bank_bik As 'БИК банка' FROM Entities", 
                _sqlConnection);
            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = command;

            adapt.Fill(dt);
            advancedDataGridView.DataSource = dt;
            labelRows.Visible = true;
            labelRows.Text = $"Кол-во выведенных строк: {dt.Rows.Count}";
        }
        // Вывод списка продуктов
        private void buttonAllProducts_Click(object sender, EventArgs e)
        {
            invoice = false;
            Size = new System.Drawing.Size(600, 610);
            panel2.Visible = true;

            SqlCommand command = new SqlCommand("SELECT Product_id As 'Код товара', Foreign_id As 'Внешний код товара', Classifier_id As 'Код классификатора', Name As 'Наименование', Brand As 'Торговая марка', " +
                "Producer As 'Производитель' FROM Products " +
                "LEFT JOIN BrandProducer ON Products.BrandProdID = BrandProducer.ForeignID", _sqlConnection);
            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = command;

            adapt.Fill(dt);
            advancedDataGridView.DataSource = dt;
            labelRows.Visible = true;
            labelRows.Text = $"Кол-во выведенных строк: {dt.Rows.Count}";
        }

        //ВЫвод списка клиентов
        private void buttonCustomers_Click(object sender, EventArgs e)
        {
            invoice = false;
            Size = new System.Drawing.Size(1000, 490);
            panel2.Visible = true;

            SqlCommand command = new SqlCommand("SELECT Id As 'Код клиента', Customer_foreign_id As 'Внешний код клиента', Name As 'Имя клиента', Director_name As 'Имя директора', Urastic_name As 'Юр. имя'," +
                " Urastic_address As 'Юр. адрес', [INN\\KPP] As 'ИНН\\КПП', Bank_name As 'Название банка', Account As 'Счет', Corr_account As 'Корр. счет', Bank_bik As 'БИК банка', Dir_party As 'Дир.' FROM Customers",
                _sqlConnection);
            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = command;

            adapt.Fill(dt);
            advancedDataGridView.DataSource = dt;
            labelRows.Visible = true;
            labelRows.Text = $"Кол-во выведенных строк: {dt.Rows.Count}";
        }

        //Вывод списка накладных
        private void buttonInvoices_Click(object sender, EventArgs e)
        {
            invoice = true;
            Size = new System.Drawing.Size(1250, 700);
            panel2.Visible = true;

            SqlCommand command = new SqlCommand("SELECT Invoice_id As 'Код накладной', Vendor_id As 'Код поставщика', Invoice_name As 'Название накладной', Invoice_number As 'Номер накладной', Date As 'Дата'," +
                " Purch_number  As 'Номер закупки', Purch_date As 'Дата закупки', Doc_type As 'Тип документа', Invoice_status As 'Статус', Ofactured As 'Офактурена', Base As 'Налог', Exclude_return As 'Возврат', " +
                "KU_type As 'Тип КУ', Pay_type As 'Оплата' FROM Invoices", _sqlConnection);
            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = command;

            adapt.Fill(dt);
            advancedDataGridView.DataSource = dt;
            labelRows.Visible = true;
            labelRows.Text = $"Кол-во выведенных строк: {dt.Rows.Count}";
        }

        //Открытие товаров накладной при двойном нажатии
        private void advancedDataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((e.RowIndex < 0) || (invoice == false))  // DoubleClick по заголовку или на гриде без накладных
                return;

            string Invoice_id = Convert.ToString(advancedDataGridView.Rows[advancedDataGridView.CurrentRow.Index].Cells["Номер накладной"].Value);


            Form FormInvoiceProducts = new InvoiceProducts(Invoice_id);
            FormInvoiceProducts.ShowDialog();
        }

        // Вывод списка оказываемых услуг
        private void service_button_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"{Size.Width} {Size.Height}");
        }



        //Фильтр поставщиков
        private void advancedDataGridView1_FilterStringChanged(object sender, EventArgs e)
        {
            (advancedDataGridView.DataSource as DataTable).DefaultView.RowFilter = advancedDataGridView.FilterString;
            
            labelRows.Text = $"Кол-во выведенных строк: {advancedDataGridView.RowCount}";
        }

        // Сортировка поставщиков
        private void advancedDataGridView1_SortStringChanged(object sender, EventArgs e)
        {
            (advancedDataGridView.DataSource as DataTable).DefaultView.Sort = advancedDataGridView.SortString;

            labelRows.Text = $"Кол-во выведенных строк: {advancedDataGridView.RowCount}";
        }



        //Открытие формы списка КУ с помощью кнопки на верхней панели
        private void списокКУToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form FormKUList = new KUListForm();

            FormKUList.Show();

        }

        //Открытие графика КУ с помощью кнопки на верхней панели
        private void графикКУToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form FormKUGraph = new KUGraphForm();

            FormKUGraph.Show();
        }
        // Изменение размера формы
        private void ListForm_Resize(object sender, EventArgs e)
        {
            doResize();
        }
        // Изменение размера формы
        private void doResize()
        {
            labelMain.Location = new System.Drawing.Point(Convert.ToInt32((panel1.Width - labelMain.Width) / 2), labelMain.Location.Y);

            panel2.Height = ClientSize.Height - (panel1.Location.Y + panel1.Height);
        }

        // Закрытие соединения с БД
        private void VendorsListForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _sqlConnection.Close();
        }

        
    }
}
