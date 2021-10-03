﻿using System;
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

            showVendorsList();
        }

        // Закрытие соединения с БД
        private void VendorsListForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _sqlConnection.Close();
        }


        // Вывод списка поставщиков
        private void showVendorsList()
        {
            SqlCommand command = new SqlCommand("SELECT Name As 'Поставщик', " +
                "(SELECT Name FROM Entities Where Entities.Entity_id = Vendors.Entity_id) As 'Юридическое лицо' FROM Vendors", _sqlConnection);
            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = command;
            adapt.Fill(dt);
            advancedDataGridView1.DataSource = dt;
            //advancedDataGridView1.Columns["Vendor_id"].Visible = false;
            //advancedDataGridView1.Columns["Entity_id"].Visible = false;
        }

        //Фильтр поставщиков
        private void advancedDataGridView1_FilterStringChanged(object sender, EventArgs e)
        {
            (advancedDataGridView1.DataSource as DataTable).DefaultView.RowFilter = advancedDataGridView1.FilterString;
        }

        // Сортировка поставщиков
        private void advancedDataGridView1_SortStringChanged(object sender, EventArgs e)
        {
            (advancedDataGridView1.DataSource as DataTable).DefaultView.Sort = advancedDataGridView1.SortString;
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

    }
}
