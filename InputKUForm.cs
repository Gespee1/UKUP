﻿using System;
using System.Data;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace РасчетКУ
{
    public partial class InputKUForm : Form
    {
        private SqlConnection _sqlConnection;
        private bool _showKU = false, _approved = false;
        private Int64 _KU_id, _Vendor_id;
        private List<Int64> ProdIds = new List<Int64>();
        private List<string> CategoryID = new List<string>();

        public InputKUForm()
        {
            InitializeComponent();
        }
        // Конструктор для изменения выбранного КУ в форме списка КУ
        public InputKUForm(Int64 KUId, Int64 VendorId)
        {
            InitializeComponent();
            _KU_id = KUId;
            _Vendor_id = VendorId;
            _showKU = true;

            create_button.Text = "Изменить";
            createNapprove_button.Text = "Изменить и утвердить";
            comboBox1.Enabled = false;
            status_textBox.Visible = true;
            status_label.Visible = true;
            cancel_button.Visible = true;
        }

        // Подключение к БД при открытии формы
        private void InputKUForm_Load(object sender, EventArgs e)
        {
            _sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB1"].ConnectionString);
            _sqlConnection.Open();

            //Загрузка данных о поставщиках в комбобокс
            SqlCommand command = new SqlCommand("SELECT Name FROM Vendors", _sqlConnection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                comboBox1.Items.Add(reader[0]);
            }
            reader.Close();

            // Настройка дат
            
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker3.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = " ";
            dateTimePicker2.CustomFormat = " ";
            dateTimePicker3.CustomFormat = " ";
            if (dateTimePicker1.Format != DateTimePickerFormat.Custom)
            {
                dateTimePicker2.MinDate = DateTime.Today.AddDays(1);
            }

            doResize();
            if (_showKU)
                showSelectedKU();
        }

        // Отображение КУ, выбранного из формы списка КУ
        private void showSelectedKU()
        {
            // Загрузка всех параметров КУ
            SqlCommand command = new SqlCommand($"SELECT Vendors.Name, [Percent], Period, Date_from, Date_to, Status, Description, " +
                $"(SELECT Name FROM Entities WHERE Entities.Entity_id = KU.Entity_id), Vend_account, Contract, Product_type, " +
                $"Docu_name, Docu_header, Transfer_to, Docu_account, Docu_title, Docu_code, Docu_date, Docu_subject, " +
                $"Tax, [Return], Ofactured, Pay_method, KU_type " +
                $"FROM KU, Vendors WHERE KU.Vendor_id = Vendors.Vendor_id AND KU_id = {_KU_id}", _sqlConnection);
            SqlDataReader reader = command.ExecuteReader();

            reader.Read();
            comboBox1.SelectedItem = reader[0].ToString();
            textBox1.Text = (Convert.ToDouble(reader[1]) / 10).ToString();
            comboBox2.SelectedItem = reader[2].ToString();
            dateTimePicker1.Format = DateTimePickerFormat.Long;
            dateTimePicker2.Format = DateTimePickerFormat.Long;
            dateTimePicker1.Value = Convert.ToDateTime(reader[3]);
            dateTimePicker2.Value = Convert.ToDateTime(reader[4]);
            status_textBox.Text = reader[5].ToString();
            richTextBox1.Text = reader[6].ToString();
            textBox2.Text = reader[7].ToString();
            textBox4.Text = reader[8].ToString();
            textBox5.Text = reader[9].ToString();
            textBox6.Text = reader[10].ToString();
            textBox7.Text = reader[11].ToString();
            textBox12.Text = reader[12].ToString();
            textBox8.Text = reader[13].ToString();
            textBox9.Text = reader[14].ToString();
            textBox10.Text = reader[15].ToString();
            textBox11.Text = reader[16].ToString();
            if(reader[17].ToString() != "")
                dateTimePicker3.Value = Convert.ToDateTime(reader[17]);
            richTextBox2.Text = reader[18].ToString();
            if(reader[19].ToString() != "")
                checkBox1.Checked = Convert.ToBoolean(reader[19]);
            if (reader[20].ToString() != "")
                checkBox2.Checked = Convert.ToBoolean(reader[20]);
            if (reader[21].ToString() != "")
                checkBox3.Checked = Convert.ToBoolean(reader[21]);
            comboBox5.SelectedItem = reader[22].ToString();
            comboBox4.SelectedItem = reader[23].ToString();
            reader.Close();

            if (status_textBox.Text == "Утверждено")
                _approved = true;

            // Если КУ в статусе "Утверждено"
            if (_approved)
            {
                create_button.Visible = false;
                createNapprove_button.Visible = false;
                close_button.Visible = true;
                comboBox1.Enabled = false;
                textBox1.Enabled = false;
                comboBox2.Enabled = false;
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
                status_textBox.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                dataGridView2.ReadOnly = true;
                dataGridView3.ReadOnly = true;
            }
            showProducerBrand(_Vendor_id);
            showExInProducts(_KU_id);
            showTerms(_KU_id);
        }

        // Добавление или изменение данных о КУ
        private void create_button_Click(object sender, EventArgs e)
        {

            if (!nullCheck())
                return;

            // Добавление или изменение информаци о коммерческих условиях
            if (create_button.Text == "Создать")
            {
                addKU("Создано");
            }
            else
            {
                updateKU("Создано");
            }
        }

        // Нажатие на кнопку создания(изменения) и утверждения
        private void createNapprove_button_Click(object sender, EventArgs e)
        {
            DialogResult result;

            result = MessageBox.Show($"Вы уверены, что хотите {createNapprove_button.Text} выбранное коммерческое условие?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (!nullCheck())
                    return;

                if (createNapprove_button.Text == "Создать и утвердить")
                {
                    // Создание и утверждение
                    addKU("Утверждено");
                }
                else
                {
                    // Изменение и утверждение
                    updateKU("Утверждено");
                }
            }
        }

        // Нажатие на кнопку закрытия КУ
        private void close_button_Click(object sender, EventArgs e)
        {
            DialogResult result;

            result = MessageBox.Show("Вы уверены, что хотите изменить статус КУ на 'Закрыто' ?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                SqlCommand command = new SqlCommand($"UPDATE KU SET Status = 'Закрыто' WHERE KU_id = {_KU_id}", _sqlConnection);
                command.ExecuteNonQuery();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            
        }

        // Нажатие на кнопку отмены при изменении КУ
        private void cancel_button_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // Проверка на пустые поля при нажатии на кнопки
        private bool nullCheck()
        {
            // Проверка, выбран ли поставщик + введены ли данные
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Поставщик не выбран!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if ((textBox1.Text == "") || (comboBox2.SelectedIndex == -1))
            {
                MessageBox.Show("Введите данные!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if ((dateTimePicker1.Format == DateTimePickerFormat.Custom) || (dateTimePicker2.Format == DateTimePickerFormat.Custom))
            {
                MessageBox.Show("Введите даты!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;

        }

        // Добавление КУ в БД
        private void addKU(string status)
        {
            // Проверка на неповторность временного периода
            List<DateTime> dateFrom = new List<DateTime>(), dateTo = new List<DateTime>();
            DateTime currDateFrom = dateTimePicker1.Value, currDateTo = dateTimePicker2.Value;

            SqlCommand command = new SqlCommand($"SELECT Date_from, Date_to FROM KU WHERE Vendor_id = " +
                $"(SELECT Vendor_id FROM Vendors WHERE Name = '{comboBox1.SelectedItem}')", _sqlConnection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                dateFrom.Add(Convert.ToDateTime(reader[0]));
                dateTo.Add(Convert.ToDateTime(reader[1]));
            }
            reader.Close();

            // цикл с проверкой
            for (int i = 0; i < dateFrom.Count; i++)
            {
                if (dateFrom[i] < currDateTo && currDateFrom < dateTo[i])
                {
                    MessageBox.Show($"В базе данных уже содержится информация о коммерческих условиях поставщика '{comboBox1.SelectedItem}' в обозначенный период с " +
                        $"{currDateFrom.ToShortDateString()} по {currDateTo.ToShortDateString()}", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // Создание КУ
            command = new SqlCommand(
           $"INSERT INTO KU (Vendor_id, [Percent], Period, Date_from, Date_to, Status, Entity_id, Vend_account, Description, Contract, Product_type, Docu_name, Docu_header, " +
           $"Transfer_to, Docu_account, Docu_title, Docu_code, Docu_date, Docu_subject, Tax, [Return], Ofactured, Pay_Method, KU_type)" +
           $" VALUES ((SELECT Vendor_id FROM Vendors WHERE Name = '{comboBox1.SelectedItem}'), " +
           $"'{(int)(Convert.ToDouble(textBox1.Text) * 10)}', '{comboBox2.SelectedItem}', '{dateTimePicker1.Value.ToShortDateString()}', '{dateTimePicker2.Value.ToShortDateString()}', '{status}', " +
           $"(SELECT Entity_id FROM Entities WHERE Name = '{textBox2.Text}'), '{textBox4.Text}', '{richTextBox1.Text}', '{textBox5.Text}', '{textBox6.Text}', '{textBox7.Text}', " +
           $"'{textBox12.Text}', '{textBox8.Text}', '{textBox9.Text}', '{textBox10.Text}', '{textBox11.Text}', '{dateTimePicker3.Value.ToShortDateString()}', '{richTextBox2.Text}', " +
           $"'{checkBox1.Checked}', '{checkBox2.Checked}', '{checkBox3.Checked}', '{comboBox5.SelectedItem}', '{comboBox4.SelectedItem}')", _sqlConnection);
            command.ExecuteNonQuery();

            command = new SqlCommand($"SELECT KU_id FROM KU WHERE Vendor_id = (SELECT Vendor_id FROM Vendors WHERE Name = '{comboBox1.SelectedItem}') AND Date_from = '{dateTimePicker1.Value.ToShortDateString()}' AND Date_to = '{dateTimePicker2.Value.ToShortDateString()}'", _sqlConnection);
            _KU_id = Convert.ToInt64(command.ExecuteScalar());

            //Запись условий бонуса в БД
            for ( int i = 0; i < dataGridView1.RowCount; i++)
            {
                command = new SqlCommand(
              $"INSERT INTO Terms (KU_id, Fixed, Criteria, [Percent/Amount], Total) VALUES ('{_KU_id}', '{dataGridView1.Rows[i].Cells["FixSum"].Value}'," +
              $" '{dataGridView1.Rows[i].Cells["Criterion"].Value}', '{dataGridView1.Rows[i].Cells["PercentSum"].Value}', '{dataGridView1.Rows[i].Cells["Total"].Value}')", _sqlConnection);
                command.ExecuteNonQuery();
            }
            //ПРОБНЫЙ МЕТОД ДЛЯ СОХРАНЕНИЯ iN/EX!!!!!!!!!!!!!!!!!!!
            AddInExBD();
            

            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            textBox1.Text = "";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
        }

        // Изменение КУ в БД
        private void updateKU(string status)
        {
            // Проверка на неповторность временного периода
            List<DateTime> dateFrom = new List<DateTime>(), dateTo = new List<DateTime>();
            DateTime currDateFrom = dateTimePicker1.Value, currDateTo = dateTimePicker2.Value;

            SqlCommand command = new SqlCommand($"SELECT Date_from, Date_to FROM KU WHERE Vendor_id = " +
                $"(SELECT Vendor_id FROM Vendors WHERE Name = '{comboBox1.SelectedItem}') AND KU_id != {_KU_id}", _sqlConnection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                dateFrom.Add(Convert.ToDateTime(reader[0]));
                dateTo.Add(Convert.ToDateTime(reader[1]));
            }
            reader.Close();

            // цикл с проверкой
            for (int i = 0; i < dateFrom.Count; i++)
            {
                if (dateFrom[i] < currDateTo && currDateFrom < dateTo[i])
                {
                    MessageBox.Show($"В базе данных уже содержится информация о коммерческих условиях поставщика '{comboBox1.SelectedItem}' в обозначенный период с " +
                        $"{currDateFrom.ToShortDateString()} по {currDateTo.ToShortDateString()}", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            command = new SqlCommand(
                    $"UPDATE KU SET [Percent] = '{(int)(Convert.ToDouble(textBox1.Text) * 10)}', Period = '{comboBox2.SelectedItem}', " +
                    $"Date_from = '{dateTimePicker1.Value.ToShortDateString()}', Date_to = '{dateTimePicker2.Value.ToShortDateString()}', Status = '{status}', " +
                    $"Entity_id = (SELECT Entity_id FROM Entities WHERE Name = '{textBox2.Text}'), Vend_account = '{textBox4.Text}', Description = '{richTextBox1.Text}', Contract = '{textBox5.Text}', " +
                    $"Product_type = '{textBox6.Text}', Docu_name = '{textBox7.Text}', Docu_header = '{textBox12.Text}', Transfer_to = '{textBox8.Text}', Docu_account = '{textBox9.Text}', " +
                    $"Docu_title = '{textBox10.Text}', Docu_code = '{textBox11.Text}', Docu_date = '{dateTimePicker3.Value.ToShortDateString()}', Docu_subject = '{richTextBox2.Text}', " +
                    $"Tax = '{checkBox1.Checked}', [Return] = '{checkBox2.Checked}', Ofactured = '{checkBox3.Checked}', Pay_method = '{comboBox5.SelectedItem}', KU_type = '{comboBox4.SelectedItem}'" +
                    $" WHERE KU_id = {_KU_id}", _sqlConnection);
            command.ExecuteNonQuery();

            //Перезапись условий бонуса в БД
            command = new SqlCommand($"DELETE FROM Terms WHERE KU_id = '{_KU_id}'", _sqlConnection);
            command.ExecuteNonQuery();
            
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                command = new SqlCommand(
              $"INSERT INTO Terms (KU_id, Fixed, Criteria, [Percent/Amount], Total) VALUES ('{_KU_id}', '{dataGridView1.Rows[i].Cells["FixSum"].Value}'," +
              $" '{dataGridView1.Rows[i].Cells["Criterion"].Value}', '{dataGridView1.Rows[i].Cells["PercentSum"].Value}', '{dataGridView1.Rows[i].Cells["Total"].Value}')", _sqlConnection);
                command.ExecuteNonQuery();
            }
            //Запись добавленных и исключенных
            AddInExBD();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }




        // Изменение минимальной даты окончания, в зависимости от выбранной даты начала
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.MinDate = dateTimePicker1.Value.AddDays(1);
            dateTimePicker1.Format = DateTimePickerFormat.Long;
        }
        // Изменение значения 2 календаря
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.Format = DateTimePickerFormat.Long;
        }
        // Изменение значения 3 календаря
        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker3.Format = DateTimePickerFormat.Long;
        }

        // Ограничение ввода процента
        private void textBox_KeyPress_only_float_numbers(object sender, KeyPressEventArgs e) // Ограничение на ввод только дробных чисел
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8 && number != 44) //разрешение ввода чисел, запятой и backspace
            {
                e.Handled = true;
            }
        }

               
        // ПЕРЕНОС

        //Отображение производителя и марки в combobox в таблицах искл и вкл товаров
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (comboBox1.SelectedIndex > -1 & _showKU == false)
            {
                dataGridView2.Rows.Clear();
                dataGridView3.Rows.Clear();
                //Вызываю метод отображения Производителя и марки
                SqlCommand command = new SqlCommand($"SELECT Vendor_id FROM Vendors WHERE Vendors.Name = '{comboBox1.SelectedItem}'", _sqlConnection);
                _Vendor_id = Convert.ToInt64(command.ExecuteScalar());
                showProducerBrand(_Vendor_id);

                //Добавление условия "Все" при создании ку
                dataGridView2.Rows.Clear();
                dataGridView2.Rows.Add();
                dataGridView2.Rows[0].Cells["TypeP"].Value = "Все";

            }

        }

        //Включение производителя и марки в combobox в таблицах искл и вкл товаров
        private void showProducerBrand(Int64 VendorId)
        {
            DataGridViewComboBoxColumn combo1 = dataGridView2.Columns["ProducerP"] as DataGridViewComboBoxColumn;
            DataGridViewComboBoxColumn combo2 = dataGridView2.Columns["BrandP"] as DataGridViewComboBoxColumn;
            DataGridViewComboBoxColumn combo3 = dataGridView3.Columns["ProducerM"] as DataGridViewComboBoxColumn;
            DataGridViewComboBoxColumn combo4 = dataGridView3.Columns["BrandM"] as DataGridViewComboBoxColumn;
            combo1.Items.Clear();
            combo2.Items.Clear();
            combo3.Items.Clear();
            combo4.Items.Clear();

            SqlCommand command = new SqlCommand($"SELECT DISTINCT Producer, Brand_name FROM Products, Assortment Where Products.Product_id = Assortment.Product_id AND Vendor_id = {VendorId} ", _sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                combo1.Items.Add(reader[0]);
                combo2.Items.Add(reader[1]);
                combo3.Items.Add(reader[0]);
                combo4.Items.Add(reader[1]);

            }
            reader.Close();
        }

        // Отображение добавленных и исключенных из расчета продуктов
        private void showExInProducts(Int64 KUId)
        {
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
            SqlCommand command = new SqlCommand($"SELECT * FROM Included_products WHERE KU_id = {KUId}", _sqlConnection);

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                dataGridView2.Rows.Add();
                dataGridView2.Rows[dataGridView2.RowCount - 1].Cells[0].Value = reader[0];
                dataGridView2.Rows[dataGridView2.RowCount - 1].Cells[1].Value = reader[1];
                dataGridView2.Rows[dataGridView2.RowCount - 1].Cells[2].Value = reader[2];
                dataGridView2.Rows[dataGridView2.RowCount - 1].Cells[3].Value = reader[3];
                dataGridView2.Rows[dataGridView2.RowCount - 1].Cells[4].Value = reader[4];
                (dataGridView2.Rows[dataGridView2.RowCount - 1].Cells[5] as DataGridViewComboBoxCell).Value = reader[5].ToString();
                (dataGridView2.Rows[dataGridView2.RowCount - 1].Cells[6] as DataGridViewComboBoxCell).Value = reader[6].ToString();

                // Запрет выбора произв и торг марки для товаров
                if (dataGridView2.Rows[dataGridView2.RowCount - 1].Cells[2].Value.ToString() == "Товары")
                {
                    dataGridView2.Rows[dataGridView2.RowCount - 1].Cells[5].ReadOnly = true;
                    dataGridView2.Rows[dataGridView2.RowCount - 1].Cells[6].ReadOnly = true;
                }
            }
            reader.Close();

            command = new SqlCommand($"SELECT * FROM Excluded_products WHERE KU_id = {KUId}", _sqlConnection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                dataGridView3.Rows.Add();
                dataGridView3.Rows[dataGridView3.RowCount - 1].Cells[0].Value = reader[0];
                dataGridView3.Rows[dataGridView3.RowCount - 1].Cells[1].Value = reader[1];
                dataGridView3.Rows[dataGridView3.RowCount - 1].Cells[2].Value = reader[2];
                dataGridView3.Rows[dataGridView3.RowCount - 1].Cells[3].Value = reader[3];
                dataGridView3.Rows[dataGridView3.RowCount - 1].Cells[4].Value = reader[4];
                (dataGridView3.Rows[dataGridView3.RowCount - 1].Cells[5] as DataGridViewComboBoxCell).Value = reader[5].ToString();
                (dataGridView3.Rows[dataGridView3.RowCount - 1].Cells[6] as DataGridViewComboBoxCell).Value = reader[6].ToString();

                // Запрет выбора произв и торг марки для товаров
                if (dataGridView3.Rows[dataGridView3.RowCount - 1].Cells[2].Value.ToString() == "Товары")
                {
                    dataGridView3.Rows[dataGridView3.RowCount - 1].Cells[5].ReadOnly = true;
                    dataGridView3.Rows[dataGridView3.RowCount - 1].Cells[6].ReadOnly = true;
                }
            }
            reader.Close();
        }

        //отображение условий ретро
        private void showTerms(Int64 KUId)
        {
            dataGridView1.Rows.Clear();
            SqlCommand command = new SqlCommand($"SELECT * FROM Terms WHERE KU_id = {KUId}", _sqlConnection);

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                dataGridView1.Rows.Add();
                (dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["FixSum"] as DataGridViewCheckBoxCell).Value = reader[2];
                dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Criterion"].Value = reader[3];
                dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["PercentSum"].Value = reader[4];
                dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Total"].Value = reader[5];
                           
            }
            reader.Close();
        }

        // Кнопка "Добавить все"
        private void button4_Click(object sender, EventArgs e)
        {
            addLine("Все");
        }

        //Открытие формы выбора категории
        private void btnSelectCategory_Click(object sender, EventArgs e)
        {
            CategoryID.Clear();

            Form selectCategoryForm = new SelectCategoryForm(ref CategoryID);
            selectCategoryForm.ShowDialog();

             if (selectCategoryForm.DialogResult == DialogResult.OK)
               addLine("Категория");

        }

        // Открытие формы выбора продуктов
        private void button5_Click(object sender, EventArgs e)
        {
            if (_Vendor_id != 0)
            {

                int selectedVendorId = Convert.ToInt32(_Vendor_id);
                ProdIds.Clear();

                Form SelectForm = new SelectProductForm(selectedVendorId, ref ProdIds);
                SelectForm.ShowDialog();

                // Добавление строк с товарами 
                if (SelectForm.DialogResult == DialogResult.OK)
                    addLine("Товары");
            }
            else
            {
                MessageBox.Show("Выберите поставщика", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Поиск названия категории
        private string findNameById(string id)
        {
            SqlCommand command = new SqlCommand($"SELECT * FROM Classifier WHERE L1 = '{id}' OR L2 = '{id}' OR L3 = '{id}' OR L4 = '{id}'", _sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            for (int i = 0; i <= 6; i += 2)
            {
                if (dt.Rows[0][i].ToString() == id)
                {
                    return dt.Rows[0][i + 1].ToString();
                }
            }

            return "NULL";
        }

        //кнопка удаления вкл/иск
        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult result;
            if (tabControl1.SelectedIndex == 0)
            {
                if (dataGridView2.RowCount < 1)
                {
                    MessageBox.Show("Нечего удалять", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                result = MessageBox.Show($"Вы уверены, что хотите удалить условие '{dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells["TypeP"].Value}' ?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                    return;

                dataGridView2.Rows.RemoveAt(dataGridView2.CurrentRow.Index);
                
            }
            else
            {
                if (dataGridView3.RowCount < 1)
                {
                    MessageBox.Show("Нечего удалять", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                result = MessageBox.Show($"Вы уверены, что хотите удалить условие '{dataGridView3.Rows[dataGridView3.CurrentRow.Index].Cells["TypeM"].Value}' ?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                    return;

                dataGridView3.Rows.RemoveAt(dataGridView2.CurrentRow.Index);
                
            }
            //showExInProducts(Convert.ToInt64(_KU_id));
        }

        
        // Добавление строк в таблицы включения и исключения
        private void addLine(string type)
        {
            Int64 KU_id = Convert.ToInt64(_KU_id);
            Int16 tabPageId = Convert.ToInt16(tabControl1.SelectedIndex);
            SqlCommand command;
            switch (type)
            {
                case "Все":
                    if (tabPageId == 0)
                    {
                        for (int i = 0; i < dataGridView2.RowCount; i++)
                        {
                            if (dataGridView2.Rows[i].Cells["TypeP"].Value.ToString() == "Все")
                            {
                                MessageBox.Show("Данное условие уже добавлено!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        dataGridView2.Rows.Add();
                        dataGridView2.Rows[dataGridView2.RowCount - 1].Cells["TypeP"].Value = "Все";
                    
                    }
                    else
                    {
                        DialogResult result = DialogResult.Yes;
                        // Проверка, есть ли условие "все" в условиях на добавление
                        for (int i = 0; i < dataGridView2.RowCount; i++)
                        {
                            if (dataGridView2.Rows[i].Cells["TypeP"].Value.ToString() == "Все" && (dataGridView2.Rows[i].Cells["ProducerP"] as DataGridViewComboBoxCell).Value is null && (dataGridView2.Rows[i].Cells["BrandP"] as DataGridViewComboBoxCell).Value is null)
                                result = MessageBox.Show("В условиях на добавление есть условие 'Все', если добавить условие 'Все' для исключения, ни один товар не будет выбран.\nВы уверены, что хотите добавить это условие?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        }
                        if (result == DialogResult.Yes)
                        {
                            for (int i = 0; i < dataGridView3.RowCount; i++)
                            {
                                if (dataGridView3.Rows[i].Cells["TypeM"].Value.ToString() == "Все")
                                {
                                    MessageBox.Show("Данное условие уже добавлено!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                            }
                            dataGridView3.Rows.Add();
                            dataGridView3.Rows[dataGridView3.RowCount - 1].Cells["TypeM"].Value = "Все";
                           
                        }
                    }

                    break;
                case "Категория":
                    if (tabPageId == 0)
                    {
                        dataGridView2.Rows.Add();
                        dataGridView2.Rows[dataGridView2.RowCount - 1].Cells["TypeP"].Value = type;
                        dataGridView2.Rows[dataGridView2.RowCount - 1].Cells["Attribute1P"].Value = CategoryID[0];
                        dataGridView2.Rows[dataGridView2.RowCount - 1].Cells["Attribute2P"].Value = findNameById(CategoryID[0]);
                   
                    }
                    else
                    {
                        dataGridView3.Rows.Add();
                        dataGridView3.Rows[dataGridView3.RowCount - 1].Cells["TypeM"].Value = type;
                        dataGridView3.Rows[dataGridView3.RowCount - 1].Cells["Attribute1M"].Value = CategoryID[0];
                        dataGridView3.Rows[dataGridView3.RowCount - 1].Cells["Attribute2M"].Value = findNameById(CategoryID[0]);
                       
                    }
                   
                    break;
                case "Товары":
                    for (int i = 0; i < ProdIds.Count; i++)
                    {
                        string _ProdName;
                        if (tabPageId == 0)
                        {
                            dataGridView2.Rows.Add();
                            dataGridView2.Rows[dataGridView2.RowCount - 1].Cells["TypeP"].Value = type;
                            dataGridView2.Rows[dataGridView2.RowCount - 1].Cells["Attribute1P"].Value = ProdIds[i];
                            command = new SqlCommand($"SELECT Name FROM Products WHERE Product_id = {ProdIds[i]}", _sqlConnection);
                            _ProdName = command.ExecuteScalar().ToString();
                            dataGridView2.Rows[dataGridView2.RowCount - 1].Cells["Attribute2P"].Value = _ProdName;

                            if (dataGridView2.Rows[dataGridView2.RowCount - 1].Cells["TypeP"].Value.ToString() == "Товары")
                            {
                                dataGridView2.Rows[dataGridView2.RowCount - 1].Cells["ProducerP"].ReadOnly = true;
                                dataGridView2.Rows[dataGridView2.RowCount - 1].Cells["BrandP"].ReadOnly = true;
                            }
                           
                        }
                        else
                        {
                            dataGridView3.Rows.Add();
                            dataGridView3.Rows[dataGridView3.RowCount - 1].Cells["TypeM"].Value = type;
                            dataGridView3.Rows[dataGridView3.RowCount - 1].Cells["Attribute1M"].Value = ProdIds[i];
                            command = new SqlCommand($"SELECT Name FROM Products WHERE Product_id = {ProdIds[i]}", _sqlConnection);
                            _ProdName = command.ExecuteScalar().ToString();
                            dataGridView3.Rows[dataGridView3.RowCount - 1].Cells["Attribute2M"].Value = _ProdName;

                            if (dataGridView3.Rows[dataGridView3.RowCount - 1].Cells["TypeM"].Value.ToString() == "Товары")
                            {
                                dataGridView3.Rows[dataGridView3.RowCount - 1].Cells["ProducerM"].ReadOnly = true;
                                dataGridView3.Rows[dataGridView3.RowCount - 1].Cells["BrandM"].ReadOnly = true;
                            }
                          
                        }
                     
                    }

                    break;
            }
          
        }

        //Запись в бд для in/ex через создание ку
        private void AddInExBD()
        {
           
            SqlCommand command;
            if (create_button.Text.ToString() == "Изменить")
            {
        
                command = new SqlCommand($"DELETE FROM Included_products WHERE KU_id = '{_KU_id}'", _sqlConnection);
                command.ExecuteNonQuery();
                command = new SqlCommand($"DELETE FROM Excluded_products WHERE KU_id = '{_KU_id}'", _sqlConnection);
                command.ExecuteNonQuery();
            }
            for (int i = 0; i < dataGridView2.RowCount; i++)
            {
                
                
                 switch (dataGridView2.Rows[i].Cells["TypeP"].Value.ToString())
                 {
                        case "Все":
                            command = new SqlCommand($"INSERT INTO Included_products (KU_id, Type) VALUES ({_KU_id}, 'Все')", _sqlConnection);
                            command.ExecuteNonQuery();

                            //производитель и марка
                            if (!((dataGridView2.Rows[i].Cells["ProducerP"] as DataGridViewComboBoxCell).Value is null))
                            {
                                command = new SqlCommand($"UPDATE Included_products SET Producer = '{dataGridView2.Rows[i].Cells["ProducerP"].Value.ToString()}' WHERE KU_id = '{_KU_id}' AND Type = '{dataGridView2.Rows[i].Cells["TypeP"].Value}'", _sqlConnection);
                                command.ExecuteNonQuery();
                            }

                            if (!((dataGridView2.Rows[i].Cells["BrandP"] as DataGridViewComboBoxCell).Value is null))
                            {
                                command = new SqlCommand($"UPDATE Included_products SET Brand_name = '{dataGridView2.Rows[i].Cells["BrandP"].Value.ToString()}' WHERE KU_id = '{_KU_id}' AND Type = '{dataGridView2.Rows[i].Cells["TypeP"].Value}'", _sqlConnection);
                                command.ExecuteNonQuery();
                            }
                                break;

                        case "Категория":

                           command = new SqlCommand($"INSERT INTO Included_products (KU_id, Type, Attribute_1, Attribute_2) VALUES (" +
                            $"{_KU_id}, 'Категория', '{dataGridView2.Rows[i].Cells["Attribute1P"].Value}', '{dataGridView2.Rows[i].Cells["Attribute2P"].Value}')", _sqlConnection);
                            command.ExecuteNonQuery();

                            //производитель и марка
                            if (!((dataGridView2.Rows[i].Cells["ProducerP"] as DataGridViewComboBoxCell).Value is null))
                            {
                                command = new SqlCommand($"UPDATE Included_products SET Producer = '{dataGridView2.Rows[i].Cells["ProducerP"].Value.ToString()}' WHERE KU_id = '{_KU_id}' AND Type = '{dataGridView2.Rows[i].Cells["TypeP"].Value}'" +
                                    $" AND Attribute_1 = '{dataGridView2.Rows[i].Cells["Attribute1P"].Value}' AND Attribute_2 = '{dataGridView2.Rows[i].Cells["Attribute2P"].Value}'", _sqlConnection);
                                command.ExecuteNonQuery();
                            }

                            if (!((dataGridView2.Rows[i].Cells["BrandP"] as DataGridViewComboBoxCell).Value is null))
                            {
                                command = new SqlCommand($"UPDATE Included_products SET Brand_name = '{dataGridView2.Rows[i].Cells["BrandP"].Value.ToString()}' WHERE KU_id = '{_KU_id}' AND Type = '{dataGridView2.Rows[i].Cells["TypeP"].Value}' " +
                                    $" AND Attribute_1 = '{dataGridView2.Rows[i].Cells["Attribute1P"].Value}' AND Attribute_2 = '{dataGridView2.Rows[i].Cells["Attribute2P"].Value}'", _sqlConnection);
                                command.ExecuteNonQuery();
                            }
                                break;

                        case "Товары":

                            command = new SqlCommand($"INSERT INTO Included_products (KU_id, Type, Attribute_1, Attribute_2) VALUES (" +
                            $"{_KU_id}, 'Товары', '{dataGridView2.Rows[i].Cells["Attribute1P"].Value}', '{dataGridView2.Rows[i].Cells["Attribute2P"].Value}')", _sqlConnection);
                            command.ExecuteNonQuery();

                            //производитель и марка
                             if (!((dataGridView2.Rows[i].Cells["ProducerP"] as DataGridViewComboBoxCell).Value is null))
                             {
                            command = new SqlCommand($"UPDATE Included_products SET Producer = '{dataGridView2.Rows[i].Cells["ProducerP"].Value.ToString()}' WHERE KU_id = '{_KU_id}' AND Type = '{dataGridView2.Rows[i].Cells["TypeP"].Value}'" +
                                $" AND Attribute_1 = '{dataGridView2.Rows[i].Cells["Attribute1P"].Value}' AND Attribute_2 = '{dataGridView2.Rows[i].Cells["Attribute2P"].Value}'", _sqlConnection);
                            command.ExecuteNonQuery();
                             }

                             if (!((dataGridView2.Rows[i].Cells["BrandP"] as DataGridViewComboBoxCell).Value is null))
                             {
                            command = new SqlCommand($"UPDATE Included_products SET Brand_name = '{dataGridView2.Rows[i].Cells["BrandP"].Value.ToString()}' WHERE KU_id = '{_KU_id}' AND Type = '{dataGridView2.Rows[i].Cells["TypeP"].Value}' " +
                                $" AND Attribute_1 = '{dataGridView2.Rows[i].Cells["Attribute1P"].Value}' AND Attribute_2 = '{dataGridView2.Rows[i].Cells["Attribute2P"].Value}'", _sqlConnection);
                            command.ExecuteNonQuery();
                             }
                                break;

                 }
                
              
            }
            //таблица исключения
            for (int i = 0; i < dataGridView3.RowCount; i++)
            {
                switch (dataGridView3.Rows[i].Cells["TypeM"].Value.ToString())
                {
                    case "Все":
                        command = new SqlCommand($"INSERT INTO Excluded_products (KU_id, Type) VALUES ({_KU_id}, 'Все')", _sqlConnection);
                        command.ExecuteNonQuery();

                        //производитель и марка
                        if (!((dataGridView3.Rows[i].Cells["ProducerM"] as DataGridViewComboBoxCell).Value is null))
                        {
                            command = new SqlCommand($"UPDATE Excluded_products SET Producer = '{dataGridView3.Rows[i].Cells["ProducerM"].Value.ToString()}' WHERE KU_id = '{_KU_id}' AND Type = '{dataGridView3.Rows[i].Cells["TypeM"].Value}'", _sqlConnection);
                            command.ExecuteNonQuery();
                        }

                        if (!((dataGridView3.Rows[i].Cells["BrandM"] as DataGridViewComboBoxCell).Value is null))
                        {
                            command = new SqlCommand($"UPDATE Excluded_products SET Brand_name = '{dataGridView3.Rows[i].Cells["BrandM"].Value.ToString()}' WHERE KU_id = '{_KU_id}' AND Type = '{dataGridView3.Rows[i].Cells["TypeM"].Value}'", _sqlConnection);
                            command.ExecuteNonQuery();
                        }
                        break;

                    case "Категория":

                        command = new SqlCommand($"INSERT INTO Excluded_products (KU_id, Type, Attribute_1, Attribute_2) VALUES (" +
                            $"{_KU_id}, 'Категория', '{dataGridView3.Rows[i].Cells["Attribute1M"].Value}', '{dataGridView3.Rows[i].Cells["Attribute2M"].Value}')", _sqlConnection);
                        command.ExecuteNonQuery();

                        //производитель и марка
                        if (!((dataGridView3.Rows[i].Cells["ProducerM"] as DataGridViewComboBoxCell).Value is null))
                        {
                            command = new SqlCommand($"UPDATE Excluded_products SET Producer = '{dataGridView3.Rows[i].Cells["ProducerM"].Value.ToString()}' WHERE KU_id = '{_KU_id}' AND Type = '{dataGridView3.Rows[i].Cells["TypeM"].Value}'" +
                                $" AND Attribute_1 = '{dataGridView3.Rows[i].Cells["Attribute1M"].Value}' AND Attribute_2 = '{dataGridView3.Rows[i].Cells["Attribute2M"].Value}'", _sqlConnection);
                            command.ExecuteNonQuery();
                        }

                        if (!((dataGridView3.Rows[i].Cells["BrandM"] as DataGridViewComboBoxCell).Value is null))
                        {
                            command = new SqlCommand($"UPDATE Excluded_products SET Brand_name = '{dataGridView3.Rows[i].Cells["BrandM"].Value.ToString()}' WHERE KU_id = '{_KU_id}' AND Type = '{dataGridView3.Rows[i].Cells["TypeM"].Value}' " +
                                $" AND Attribute_1 = '{dataGridView3.Rows[i].Cells["Attribute1M"].Value}' AND Attribute_2 = '{dataGridView3.Rows[i].Cells["Attribute2M"].Value}'", _sqlConnection);
                            command.ExecuteNonQuery();
                        }
                        break;

                    case "Товары":

                        command = new SqlCommand($"INSERT INTO Excluded_products (KU_id, Type, Attribute_1, Attribute_2) VALUES (" +
                            $"{_KU_id}, 'Товары', '{dataGridView3.Rows[i].Cells["Attribute1M"].Value}', '{dataGridView3.Rows[i].Cells["Attribute2M"].Value}')", _sqlConnection);
                        command.ExecuteNonQuery();

                        //производитель и марка
                        if (!((dataGridView3.Rows[i].Cells["ProducerM"] as DataGridViewComboBoxCell).Value is null))
                        {
                            command = new SqlCommand($"UPDATE Excluded_products SET Producer = '{dataGridView3.Rows[i].Cells["ProducerM"].Value.ToString()}' WHERE KU_id = '{_KU_id}' AND Type = '{dataGridView3.Rows[i].Cells["TypeM"].Value}'" +
                                $" AND Attribute_1 = '{dataGridView3.Rows[i].Cells["Attribute1M"].Value}' AND Attribute_2 = '{dataGridView3.Rows[i].Cells["Attribute2M"].Value}'", _sqlConnection);
                            command.ExecuteNonQuery();
                        }

                        if (!((dataGridView3.Rows[i].Cells["BrandM"] as DataGridViewComboBoxCell).Value is null))
                        {
                            command = new SqlCommand($"UPDATE Excluded_products SET Brand_name = '{dataGridView3.Rows[i].Cells["BrandM"].Value.ToString()}' WHERE KU_id = '{_KU_id}' AND Type = '{dataGridView3.Rows[i].Cells["TypeM"].Value}' " +
                                $" AND Attribute_1 = '{dataGridView3.Rows[i].Cells["Attribute1M"].Value}' AND Attribute_2 = '{dataGridView3.Rows[i].Cells["Attribute2M"].Value}'", _sqlConnection);
                            command.ExecuteNonQuery();
                        }
                        break;


                }
               
            }
            
        }

    
        // Удаление данных из комбобоксов в таблицах
        private void InputKUForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataGridView dgv;

            // Отслеживание нажатия на delete и backspace
            if (e.KeyChar == (char)Keys.Delete || e.KeyChar == (char)Keys.Back)
            {
                if (tabControl1.SelectedIndex == 0)
                    dgv = dataGridView2;
                else
                    dgv = dataGridView3;

                if (dgv.Focused)
                {
                    if (dgv.RowCount > 0 && dgv.CurrentCell.ColumnIndex > dgv.ColumnCount - 3)
                        (dgv.Rows[dgv.CurrentRow.Index].Cells[dgv.CurrentCell.ColumnIndex] as DataGridViewComboBoxCell).Value = "";

                }
            }
        }

        // Условия бонуса
        //
        // Добавление строки
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();
        }
        //Удаление строки
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
        }


        // КНОПКИ МЕНЮ
        //
        //Открытие формы списка КУ с помощью кнопки на верхней панели
        private void списокКУToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form FormKUList = new KUListForm();

            FormKUList.Show();

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


        // Изменение размеров формы
        private void InputKUForm_Resize(object sender, EventArgs e)
        {
            doResize();
        }

        // Настройки адаптивного UI формы
        private void doResize()
        {
            label1.Location = new System.Drawing.Point(Convert.ToInt32((panel1.Width - label1.Width) / 2), label1.Location.Y);

            panel2.Height = Height - 400;
            TabPage activePage = tabControl2.SelectedTab;
            int distance = Convert.ToInt32((activePage.Width - groupBox1.Width - groupBox2.Width - groupBox3.Width - groupBox4.Width) / 5);
            int distanceY = Convert.ToInt32((activePage.Height - groupBox2.Height) / 2);
            
            groupBox1.Location = new System.Drawing.Point(distance, distanceY);
            groupBox2.Location = new System.Drawing.Point(groupBox1.Location.X + groupBox1.Width + distance, distanceY);
            groupBox3.Location = new System.Drawing.Point(groupBox2.Location.X + groupBox2.Width + distance, distanceY);
            groupBox4.Location = new System.Drawing.Point(groupBox3.Location.X + groupBox3.Width + distance, distanceY);

            panel3.Height = panel4.Location.Y - panel3.Location.Y;
            tabControl1.Height = panel3.Height;

            dataGridView1.Height = activePage.Height - 12;
        }


        // Закрытие подключения к БД
        private void InputKUForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _sqlConnection.Close();
        }

    }
}