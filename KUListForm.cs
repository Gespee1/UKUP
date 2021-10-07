using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Collections.Generic;

namespace РасчетКУ
{
    public partial class KUListForm : Form
    {
        private SqlConnection _sqlConnection;
        private List<Int64> ProdIds = new List<Int64>();
        private List<string> CategoryID = new List<string>();
        public KUListForm()
        {
            InitializeComponent();
        }

        // Подключение к БД
        private void KUListForm_Load(object sender, EventArgs e)
        {
            _sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB1"].ConnectionString);
            _sqlConnection.Open();

            showKUList();
            

        }

        // Добавление КУ
        private void button1_Click(object sender, EventArgs e)
        {
            Form FormInputKU = new InputKUForm();

            FormInputKU.ShowDialog();

            if(FormInputKU.DialogResult == DialogResult.OK || FormInputKU.DialogResult == DialogResult.Cancel)
                showKUList();
        }

        // Изменение выбранного КУ
        private void button2_Click(object sender, EventArgs e)
        {
            Form FormInputKu = new InputKUForm(Convert.ToInt64(advancedDataGridView1.Rows[advancedDataGridView1.CurrentRow.Index].Cells["KU_id"].Value), Convert.ToInt64(advancedDataGridView1.Rows[advancedDataGridView1.CurrentRow.Index].Cells["Vendor_id"].Value));
            FormInputKu.ShowDialog();

            if(FormInputKu.DialogResult == DialogResult.OK)
                showKUList();
        }

        // Удаление выбранного КУ
        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result;
            DataGridViewRow row = advancedDataGridView1.Rows[advancedDataGridView1.CurrentRow.Index];

            result = MessageBox.Show("Вы уверены, что хотите удалить информацию о коммерческих условиях с поставщиком " + row.Cells["Name"].Value.ToString() + " ?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
                return;

            // Удаление привязанных к КУ значений в других таблицах
            SqlCommand command = new SqlCommand($"DELETE FROM Included_products WHERE KU_id = {row.Cells["KU_id"].Value}", _sqlConnection);
            command.ExecuteNonQuery();
            command = new SqlCommand($"DELETE FROM Excluded_products WHERE KU_id = {row.Cells["KU_id"].Value}", _sqlConnection);
            command.ExecuteNonQuery();

            // Удаление самого КУ
            command = new SqlCommand("DELETE FROM KU WHERE KU_id = " + row.Cells["KU_id"].Value.ToString(), _sqlConnection);
            command.ExecuteNonQuery();

            showKUList();
                          
        }

        
        //Фильтр товаров
        private void advancedDataGridView1_FilterStringChanged(object sender, EventArgs e)
        {
            (advancedDataGridView1.DataSource as DataTable).DefaultView.RowFilter = advancedDataGridView1.FilterString;

        }

        // Сортировка товаров
        private void advancedDataGridView1_SortStringChanged(object sender, EventArgs e)
        {
            (advancedDataGridView1.DataSource as DataTable).DefaultView.Sort = advancedDataGridView1.SortString;

        }
            
            
       
 
        // Вывод списка КУ
        private void showKUList()
        {
            SqlCommand command = new SqlCommand("SELECT KU.KU_id, Vendors.Vendor_id, Vendors.Name, KU.[Percent], KU.Date_from, KU.Date_to, KU.Period, Status FROM KU, Vendors WHERE KU.Vendor_id = Vendors.Vendor_id", _sqlConnection);

            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = command;
            adapt.Fill(dt);
            // Изменение данных о процентах для правильного отображения
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i][3] = Convert.ToDouble(dt.Rows[i][3]) / 10;
            }
            advancedDataGridView1.DataSource = dt;
            advancedDataGridView1.Columns["Vendor_id"].Visible = false;
        }
          
             
        //
        // МЕНЮ
        //
        // Открытие формы ввода коммерческих условий
        private void вводКУToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form FormInputKU = new InputKUForm();

            FormInputKU.Show();
        }

        //Открытие формы списка поставщиков с помощью кнопки на верхней панели
        private void поставщикиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form FormVendorsList = new ListForm();

            FormVendorsList.Show();
        }

        //Открытие графика КУ с помощью кнопки на верхней панели
        private void графикКУToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form FormKUGraph = new KUGraphForm();

            FormKUGraph.Show();
        }

        // Кнопка меню для создания графика по выбранной КУ
        private void создатьГрафикToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Проверка статуса выбранного КУ
            if(advancedDataGridView1.Rows[advancedDataGridView1.CurrentRow.Index].Cells["Status"].Value.ToString() != "Утверждено")
            {
                MessageBox.Show("КУ должно быть утверждено, чтобы создать по нему график!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Actions actions = new Actions();
            if(actions.addGraphToCurrentKU(Convert.ToInt64(advancedDataGridView1.Rows[advancedDataGridView1.CurrentRow.Index].Cells["KU_id"].Value)) == true)
                MessageBox.Show($"Для КУ с номером: {advancedDataGridView1.Rows[advancedDataGridView1.CurrentRow.Index].Cells["KU_id"].Value} успешно создан график.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Кнопка меню для создания графика по всем КУ
        private void создатьГрафикДляВсехToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Actions actions = new Actions();
            if(actions.addGraphs() == true)
                MessageBox.Show("Графики созданы для всех утвержденных КУ.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Открытие формы графика
        private void показатьГрафикToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form GraphForm = new KUGraphForm();
            GraphForm.Show();
        }


        // Закрытие соединения с БД при закрытии
        private void KUListForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _sqlConnection.Close();
        }

        
    }
}
