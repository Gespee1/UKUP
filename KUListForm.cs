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
            doResize();
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
            Form FormInputKu = new InputKUForm(Convert.ToInt64(advancedDataGridViewKUList.Rows[advancedDataGridViewKUList.CurrentRow.Index].Cells["Код КУ"].Value), 
                Convert.ToInt64(advancedDataGridViewKUList.Rows[advancedDataGridViewKUList.CurrentRow.Index].Cells["Код поставщика"].Value));
            FormInputKu.ShowDialog();

            if(FormInputKu.DialogResult == DialogResult.OK)
                showKUList();
        }

        //Изменение выбранного КУ (двойное нажатие)
        private void advancedDataGridView1_DoubleClick(object sender, EventArgs e)
        {
            Form FormInputKu = new InputKUForm(Convert.ToInt64(advancedDataGridViewKUList.Rows[advancedDataGridViewKUList.CurrentRow.Index].Cells["Код КУ"].Value), 
                Convert.ToInt64(advancedDataGridViewKUList.Rows[advancedDataGridViewKUList.CurrentRow.Index].Cells["Код поставщика"].Value));
            FormInputKu.ShowDialog();

            if (FormInputKu.DialogResult == DialogResult.OK)
                showKUList();
        }

        // Удаление выбранного КУ
        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result;
            DataGridViewRow row = advancedDataGridViewKUList.Rows[advancedDataGridViewKUList.CurrentRow.Index];

            result = MessageBox.Show("Вы уверены, что хотите удалить информацию о коммерческих условиях с поставщиком " + 
                row.Cells["Наименование поставщика"].Value.ToString() + " ?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
                return;

            // Удаление привязанных к КУ значений в других таблицах
            SqlCommand command = new SqlCommand($"DELETE FROM Included_products WHERE KU_id = {row.Cells["Код КУ"].Value}", _sqlConnection);
            command.ExecuteNonQuery();
            command = new SqlCommand($"DELETE FROM Excluded_products WHERE KU_id = {row.Cells["Код КУ"].Value}", _sqlConnection);
            command.ExecuteNonQuery();
            command = new SqlCommand($"DELETE FROM KU_graph WHERE KU_id = {row.Cells["Код КУ"].Value}", _sqlConnection);
            command.ExecuteNonQuery();

            // Удаление самого КУ
            command = new SqlCommand("DELETE FROM KU WHERE KU_id = " + row.Cells["Код КУ"].Value.ToString(), _sqlConnection);
            command.ExecuteNonQuery();

            showKUList();
                          
        }

        
        //Фильтр товаров
        private void advancedDataGridView1_FilterStringChanged(object sender, EventArgs e)
        {
            (advancedDataGridViewKUList.DataSource as DataTable).DefaultView.RowFilter = advancedDataGridViewKUList.FilterString;

        }

        // Сортировка товаров
        private void advancedDataGridView1_SortStringChanged(object sender, EventArgs e)
        {
            (advancedDataGridViewKUList.DataSource as DataTable).DefaultView.Sort = advancedDataGridViewKUList.SortString;

        }
            
            
       
 
        // Вывод списка КУ
        private void showKUList()
        {
            SqlCommand command = new SqlCommand("SELECT KU.KU_id As 'Код КУ', Vendors.Vendor_id As 'Код поставщика', Vendors.Name As 'Наименование поставщика', " +
                "KU.Date_from As 'Дата от', KU.Date_to As 'Дата по', KU.Period As 'Период', Status As 'Статус' FROM KU, Vendors " +
                "WHERE KU.Vendor_id = Vendors.Vendor_id", _sqlConnection);

            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = command;
            adapt.Fill(dt);
            advancedDataGridViewKUList.DataSource = dt;
            advancedDataGridViewKUList.Columns["Код поставщика"].Visible = false;
        }

        // Обновление списка КУ при переходе на форму     
        private void KUListForm_Activated(object sender, EventArgs e)
        {
            //showKUList();
        }


        //
        // МЕНЮ
        //
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
            if(advancedDataGridViewKUList.Rows[advancedDataGridViewKUList.CurrentRow.Index].Cells["Статус"].Value.ToString() != "Утверждено")
            {
                MessageBox.Show("КУ должно быть утверждено, чтобы создать по нему график!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Actions actions = new Actions();
            if(actions.addGraphToCurrentKU(Convert.ToInt64(advancedDataGridViewKUList.Rows[advancedDataGridViewKUList.CurrentRow.Index].Cells["Код КУ"].Value)) == true)
                MessageBox.Show($"Для КУ с номером: {advancedDataGridViewKUList.Rows[advancedDataGridViewKUList.CurrentRow.Index].Cells["Код КУ"].Value} успешно создан график.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        // UI
        //
        // Вызов метода изменения размера формы
        private void KUListForm_Resize(object sender, EventArgs e)
        {
            doResize();
        }

        private void doResize()
        {
            panel1.Size = new System.Drawing.Size(Size.Width - 170, Size.Height);

            labelMain.Location = new System.Drawing.Point(Convert.ToInt32((panel4.Width - labelMain.Width) / 2), labelMain.Location.Y) ;
        }

        
    }
}
