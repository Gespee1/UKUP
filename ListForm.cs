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
        }
        
        

        // Вывод списка поставщиков
        private void vend_button_Click(object sender, EventArgs e)
        {
            Size = new System.Drawing.Size(776, 489);
            panel2.Visible = true;

            SqlCommand command = new SqlCommand("SELECT Entity_id As 'Код юр. лица', Vendor_foreign_id As 'Внешний код поставщика', Name As 'Поставщик', " +
                "Urastic_name As 'Юридическое имя', [INN\\KPP] As 'ИНН\\КПП', Director_name As 'Директор', Urastic_address As 'Юр. адрес', Account As 'Счет', " +
                "Bank_name As 'Наименование банка', Bank_bik As 'Поставщик', Corr_account As 'Корр. аккаунт', Dir_party FROM Vendors", _sqlConnection);
            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = command;
            adapt.Fill(dt);
            advancedDataGridView.DataSource = dt;
        }

        // Вывод списка оказываемых услуг
        private void service_button_Click(object sender, EventArgs e)
        {

        }



        //Фильтр поставщиков
        private void advancedDataGridView1_FilterStringChanged(object sender, EventArgs e)
        {
            (advancedDataGridView.DataSource as DataTable).DefaultView.RowFilter = advancedDataGridView.FilterString;
        }

        // Сортировка поставщиков
        private void advancedDataGridView1_SortStringChanged(object sender, EventArgs e)
        {
            (advancedDataGridView.DataSource as DataTable).DefaultView.Sort = advancedDataGridView.SortString;
        }


        // Открытие формы ввода коммерческих условий
        private void вводКУToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form FormInputKU = new InputKUForm();

            FormInputKU.Show();
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
