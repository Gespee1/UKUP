using System;
using System.Data;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Diagnostics;

namespace РасчетКУ
{
    public partial class InputKUForm : Form
    {
        private SqlConnection _sqlConnection;
        private bool _showKU = false, _approved = false;
        private Int64 _KU_id, _Vendor_id;
        private List<Int64> ProdIds = new List<Int64>();
        private List<string> CategoryID = new List<string>();
        private DataTable BrandProd = new DataTable();
        private Stopwatch _timer = new Stopwatch();
        private delegate void _del(string item); // Делегат для обращения к объектам одного потока из другого потока

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

            buttonCreate.Text = "Изменить";
            buttonCreateNApprove.Text = "Изменить и утвердить";
            comboBoxVendor.Enabled = false;
            textBoxStatus.Visible = true;
            labelStatus.Visible = true;
            buttonCancel.Visible = true;
        }

        // Отдельные потоки
        //
        // Поток 1. Загрузка поставщиков
        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            
            //Загрузка данных о поставщиках в комбобокс
            SqlCommand command = new SqlCommand("SELECT DISTINCT Name FROM Vendors", _sqlConnection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                if (comboBoxVendor.InvokeRequired)
                    comboBoxVendor.Invoke(new _del((s) => comboBoxVendor.Items.Add(s)), reader[0]);
            }
            reader.Close();
        }
        // Поток 1. Отображение данных о КУ
        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            loadProducerBrand();
            if (_showKU)
                showSelectedKU();
        }


        // Подключение к БД при открытии формы
        private void InputKUForm_Load(object sender, EventArgs e)
        {
            _sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB1"].ConnectionString);
            _sqlConnection.Open();

            if (!backgroundWorker1.IsBusy)
                backgroundWorker1.RunWorkerAsync();

            // Настройка дат
            dateTimePickerDateFrom.Format = DateTimePickerFormat.Custom;
            dateTimePickerDateTo.Format = DateTimePickerFormat.Custom;
            dateTimePickerDocDate.Format = DateTimePickerFormat.Custom;
            dateTimePickerDateFrom.CustomFormat = " ";
            dateTimePickerDateTo.CustomFormat = " ";
            dateTimePickerDocDate.CustomFormat = " ";
            if (dateTimePickerDateFrom.Format != DateTimePickerFormat.Custom)
            {
                dateTimePickerDateTo.MinDate = DateTime.Today.AddDays(1);
            }

            doResize();
        }

        // Отображение КУ, выбранного из формы списка КУ
        private void showSelectedKU()
        {
            // Загрузка всех параметров КУ
            SqlCommand command = new SqlCommand($"SELECT Vendors.Name, Period, Date_from, Date_to, Status, Description, " +
                $"(SELECT Name FROM Entities WHERE Entities.Entity_id = KU.Entity_id), Vend_account, Contract, Product_type, " +
                $"Docu_name, Docu_header, Transfer_to, Docu_account, Docu_title, Docu_code, Docu_date, Docu_subject, " +
                $"Tax, [Return], Ofactured, Pay_method, KU_type " +
                $"FROM KU, Vendors WHERE KU.Vendor_id = Vendors.Vendor_id AND KU_id = {_KU_id}", _sqlConnection);
            SqlDataReader reader = command.ExecuteReader();

            reader.Read();
            comboBoxVendor.SelectedItem = reader[0].ToString();
            comboBoxPeriod.SelectedItem = reader[1].ToString();
            dateTimePickerDateFrom.Format = DateTimePickerFormat.Long;
            dateTimePickerDateTo.Format = DateTimePickerFormat.Long;
            dateTimePickerDateFrom.Value = Convert.ToDateTime(reader[2]);
            dateTimePickerDateTo.Value = Convert.ToDateTime(reader[3]);
            textBoxStatus.Text = reader[4].ToString();
            richTextBoxDescription.Text = reader[5].ToString();
            textBoxEntity.Text = reader[6].ToString();
            textBoxVendAccount.Text = reader[7].ToString();
            textBoxContract.Text = reader[8].ToString();
            textBoxProductType.Text = reader[9].ToString();
            textBoxDocName.Text = reader[10].ToString();
            textBoxDocHeader.Text = reader[11].ToString();
            textBoxTransferTo.Text = reader[12].ToString();
            textBoxDocAccount.Text = reader[13].ToString();
            textBoxDocTitle.Text = reader[14].ToString();
            textBoxDocCode.Text = reader[15].ToString();
            if(reader[16].ToString() != "")
                dateTimePickerDocDate.Value = Convert.ToDateTime(reader[16]);
            richTextBoxDocSubject.Text = reader[17].ToString();
            if(reader[18].ToString() != "")
                checkBoxTax.Checked = Convert.ToBoolean(reader[18]);
            if (reader[19].ToString() != "")
                checkBoxReturn.Checked = Convert.ToBoolean(reader[19]);
            if (reader[20].ToString() != "")
                checkBoxOfactured.Checked = Convert.ToBoolean(reader[20]);
            comboBoxPayMethod.SelectedItem = reader[21].ToString();
            comboBoxKUType.SelectedItem = reader[22].ToString();
            reader.Close();

            if (textBoxStatus.Text == "Утверждено")
                _approved = true;

            // Если КУ в статусе "Утверждено"
            if (_approved)
            {
                buttonCreate.Visible = false;
                buttonCreateNApprove.Visible = false;
                buttonClose.Visible = true;
                comboBoxVendor.Enabled = false;
                comboBoxPeriod.Enabled = false;
                dateTimePickerDateFrom.Enabled = false;
                dateTimePickerDateTo.Enabled = false;
                textBoxStatus.Enabled = false;
                buttonAddAll.Enabled = false;
                buttonAddProduct.Enabled = false;
                buttonAddCategory.Enabled = false;
                buttonDelete.Enabled = false;
                dataGridViewIncluded.ReadOnly = true;
                dataGridViewExcluded.ReadOnly = true;
            }

            showExInProducts(_KU_id);
            showTerms(_KU_id);
        }

        // Добавление или изменение данных о КУ
        private void create_button_Click(object sender, EventArgs e)
        {

            if (!nullCheck())
                return;

            // Добавление или изменение информаци о коммерческих условиях
            if (buttonCreate.Text == "Создать")
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

            result = MessageBox.Show($"Вы уверены, что хотите {buttonCreateNApprove.Text} выбранное коммерческое условие?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (!nullCheck())
                    return;

                if (buttonCreateNApprove.Text == "Создать и утвердить")
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
            if (comboBoxVendor.SelectedIndex == -1)
            {
                MessageBox.Show("Поставщик не выбран!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (comboBoxPeriod.SelectedIndex == -1)
            {
                MessageBox.Show("Введите данные!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if ((dateTimePickerDateFrom.Format == DateTimePickerFormat.Custom) || (dateTimePickerDateTo.Format == DateTimePickerFormat.Custom))
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
            DateTime currDateFrom = dateTimePickerDateFrom.Value, currDateTo = dateTimePickerDateTo.Value;

            SqlCommand command = new SqlCommand($"SELECT Date_from, Date_to FROM KU WHERE Vendor_id = " +
                $"(SELECT Vendor_id FROM Vendors WHERE Name = '{comboBoxVendor.SelectedItem}')", _sqlConnection);
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
                    MessageBox.Show($"В базе данных уже содержится информация о коммерческих условиях поставщика '{comboBoxVendor.SelectedItem}' в обозначенный период с " +
                        $"{currDateFrom.ToShortDateString()} по {currDateTo.ToShortDateString()}", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // Создание КУ
            command = new SqlCommand(
           $"INSERT INTO KU (Vendor_id, Period, Date_from, Date_to, Status, Entity_id, Vend_account, Description, Contract, Product_type, Docu_name, Docu_header, " +
           $"Transfer_to, Docu_account, Docu_title, Docu_code, Docu_date, Docu_subject, Tax, [Return], Ofactured, Pay_Method, KU_type)" +
           $" VALUES ((SELECT Vendor_id FROM Vendors WHERE Name = '{comboBoxVendor.SelectedItem}'), " +
           $"'{comboBoxPeriod.SelectedItem}', '{dateTimePickerDateFrom.Value.ToShortDateString()}', '{dateTimePickerDateTo.Value.ToShortDateString()}', '{status}', " +
           $"(SELECT Entity_id FROM Entities WHERE Name = '{textBoxEntity.Text}'), '{textBoxVendAccount.Text}', '{richTextBoxDescription.Text}', '{textBoxContract.Text}', '{textBoxProductType.Text}', '{textBoxDocName.Text}', " +
           $"'{textBoxDocHeader.Text}', '{textBoxTransferTo.Text}', '{textBoxDocAccount.Text}', '{textBoxDocTitle.Text}', '{textBoxDocCode.Text}', '{dateTimePickerDocDate.Value.ToShortDateString()}', '{richTextBoxDocSubject.Text}', " +
           $"'{checkBoxTax.Checked}', '{checkBoxReturn.Checked}', '{checkBoxOfactured.Checked}', '{comboBoxPayMethod.SelectedItem}', '{comboBoxKUType.SelectedItem}')", _sqlConnection);
            command.ExecuteNonQuery();

            command = new SqlCommand($"SELECT KU_id FROM KU WHERE Vendor_id = " +
                $"(SELECT Vendor_id FROM Vendors WHERE Name = '{comboBoxVendor.SelectedItem}') AND Date_from = '{dateTimePickerDateFrom.Value.ToShortDateString()}' AND " +
                $"Date_to = '{dateTimePickerDateTo.Value.ToShortDateString()}'", _sqlConnection);
            _KU_id = Convert.ToInt64(command.ExecuteScalar());

            //Запись условий бонуса в БД
            for ( int i = 0; i < dataGridViewTerms.RowCount; i++)
            {
                command = new SqlCommand(
              $"INSERT INTO Terms (KU_id, Fixed, Criteria, [Percent/Amount], Total) VALUES ('{_KU_id}', '{dataGridViewTerms.Rows[i].Cells["FixSum"].Value}'," +
              $" '{dataGridViewTerms.Rows[i].Cells["Criterion"].Value}', '{dataGridViewTerms.Rows[i].Cells["PercentSum"].Value}', '{dataGridViewTerms.Rows[i].Cells["Total"].Value}')", _sqlConnection);
                command.ExecuteNonQuery();
            }
            //ПРОБНЫЙ МЕТОД ДЛЯ СОХРАНЕНИЯ iN/EX!!!!!!!!!!!!!!!!!!!
            AddInExBD();
            

            comboBoxVendor.SelectedIndex = -1;
            comboBoxPeriod.SelectedIndex = -1;
            comboBoxKUType.SelectedIndex = -1;
            comboBoxPayMethod.SelectedIndex = -1;
            textBoxEntity.Text = "";
            textBoxVendAccount.Text = "";
            textBoxContract.Text = "";
            textBoxProductType.Text = "";
            textBoxDocName.Text = "";
            textBoxTransferTo.Text = "";
            textBoxDocAccount.Text = "";
            textBoxDocTitle.Text = "";
            textBoxDocCode.Text = "";
            textBoxDocHeader.Text = "";
            richTextBoxDescription.Text = "";
            richTextBoxDocSubject.Text = "";
            checkBoxTax.Checked = Convert.ToBoolean(0);
            checkBoxReturn.Checked = Convert.ToBoolean(0);
            checkBoxOfactured.Checked = Convert.ToBoolean(0);
            textBoxStatus.Text = "";
            dateTimePickerDateFrom.Format = DateTimePickerFormat.Custom;
            dateTimePickerDateTo.Format = DateTimePickerFormat.Custom;
            dateTimePickerDocDate.Format = DateTimePickerFormat.Custom;
            dataGridViewTerms.Rows.Clear();
            dataGridViewIncluded.Rows.Clear();
            dataGridViewExcluded.Rows.Clear();
        }

        // Изменение КУ в БД
        private void updateKU(string status)
        {
            // Проверка на неповторность временного периода
            List<DateTime> dateFrom = new List<DateTime>(), dateTo = new List<DateTime>();
            DateTime currDateFrom = dateTimePickerDateFrom.Value, currDateTo = dateTimePickerDateTo.Value;

            SqlCommand command = new SqlCommand($"SELECT Date_from, Date_to FROM KU WHERE Vendor_id = " +
                $"(SELECT Vendor_id FROM Vendors WHERE Name = '{comboBoxVendor.SelectedItem}') AND KU_id != {_KU_id}", _sqlConnection);
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
                    MessageBox.Show($"В базе данных уже содержится информация о коммерческих условиях поставщика '{comboBoxVendor.SelectedItem}' в обозначенный период с " +
                        $"{currDateFrom.ToShortDateString()} по {currDateTo.ToShortDateString()}", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            command = new SqlCommand(
                    $"UPDATE KU SET Period = '{comboBoxPeriod.SelectedItem}', Date_from = '{dateTimePickerDateFrom.Value.ToShortDateString()}', " +
                    $"Date_to = '{dateTimePickerDateTo.Value.ToShortDateString()}', Status = '{status}', Entity_id = (SELECT Entity_id FROM Entities WHERE Name = '{textBoxEntity.Text}'), " +
                    $"Vend_account = '{textBoxVendAccount.Text}', Description = '{richTextBoxDescription.Text}', Contract = '{textBoxContract.Text}', " +
                    $"Product_type = '{textBoxProductType.Text}', Docu_name = '{textBoxDocName.Text}', Docu_header = '{textBoxDocHeader.Text}', Transfer_to = '{textBoxTransferTo.Text}', Docu_account = '{textBoxDocAccount.Text}', " +
                    $"Docu_title = '{textBoxDocTitle.Text}', Docu_code = '{textBoxDocCode.Text}', Docu_date = '{dateTimePickerDocDate.Value.ToShortDateString()}', Docu_subject = '{richTextBoxDocSubject.Text}', " +
                    $"Tax = '{checkBoxTax.Checked}', [Return] = '{checkBoxReturn.Checked}', Ofactured = '{checkBoxOfactured.Checked}', Pay_method = '{comboBoxPayMethod.SelectedItem}', " +
                    $"KU_type = '{comboBoxKUType.SelectedItem}' WHERE KU_id = {_KU_id}", _sqlConnection);
            command.ExecuteNonQuery();

            //Перезапись условий бонуса в БД
            command = new SqlCommand($"DELETE FROM Terms WHERE KU_id = '{_KU_id}'", _sqlConnection);
            command.ExecuteNonQuery();
            
            for (int i = 0; i < dataGridViewTerms.RowCount; i++)
            {
                command = new SqlCommand(
              $"INSERT INTO Terms (KU_id, Fixed, Criteria, [Percent/Amount], Total) VALUES ('{_KU_id}', '{dataGridViewTerms.Rows[i].Cells["FixSum"].Value}'," +
              $" '{dataGridViewTerms.Rows[i].Cells["Criterion"].Value}', '{dataGridViewTerms.Rows[i].Cells["PercentSum"].Value}', '{dataGridViewTerms.Rows[i].Cells["Total"].Value}')", _sqlConnection);
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
            dateTimePickerDateTo.MinDate = dateTimePickerDateFrom.Value.AddDays(1);
            dateTimePickerDateFrom.Format = DateTimePickerFormat.Long;
        }
        // Изменение значения 2 календаря
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dateTimePickerDateTo.Format = DateTimePickerFormat.Long;
        }
        // Изменение значения 3 календаря
        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            dateTimePickerDocDate.Format = DateTimePickerFormat.Long;
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
            if (comboBoxVendor.SelectedIndex > -1 & _showKU == false)
            {
                dataGridViewIncluded.Rows.Clear();
                dataGridViewExcluded.Rows.Clear();
                //Вызываю метод отображения Производителя и марки
                //SqlCommand command = new SqlCommand($"SELECT Vendor_id FROM Vendors WHERE Vendors.Name = '{comboBox1.SelectedItem}'", _sqlConnection);
                //_Vendor_id = Convert.ToInt64(command.ExecuteScalar());
                //showProducerBrand();

                //Добавление условия "Все" при создании ку
                dataGridViewIncluded.Rows.Add();
                dataGridViewIncluded.Rows[0].Cells["TypeP"].Value = "Все";
            }
        }

        //Включение производителя и марки в combobox в таблицах искл и вкл товаров
        private void loadProducerBrand()
        {
            DataGridViewComboBoxColumn combo1 = dataGridViewIncluded.Columns["ProducerP"] as DataGridViewComboBoxColumn;
            DataGridViewComboBoxColumn combo2 = dataGridViewIncluded.Columns["BrandP"] as DataGridViewComboBoxColumn;
            DataGridViewComboBoxColumn combo3 = dataGridViewExcluded.Columns["ProducerM"] as DataGridViewComboBoxColumn;
            DataGridViewComboBoxColumn combo4 = dataGridViewExcluded.Columns["BrandM"] as DataGridViewComboBoxColumn;
            combo1.Items.Clear();
            combo2.Items.Clear();
            combo3.Items.Clear();
            combo4.Items.Clear();

            SqlCommand comm = new SqlCommand("SELECT DISTINCT ID, Producer, Brand FROM BrandProducer ORDER BY Producer", _sqlConnection);
            SqlDataAdapter adapt = new SqlDataAdapter(comm);
            
            adapt.Fill(BrandProd);
            
            for (int i = 0; i < BrandProd.Rows.Count; i++)
            {
                combo1.Items.Add(BrandProd.Rows[i][1]);
                combo2.Items.Add(BrandProd.Rows[i][2]);
                combo3.Items.Add(BrandProd.Rows[i][1]);
                combo4.Items.Add(BrandProd.Rows[i][2]);
            }
        }

        // Отображение добавленных и исключенных из расчета продуктов
        private void showExInProducts(Int64 KUId) // was: 470-532, mow: 470-524
        {
            int idx = 0;
            DataGridView dgv;
            SqlCommand command;
            SqlDataReader reader;

            while (idx < 2)
            {
                if(idx == 0)
                {
                    dgv = dataGridViewIncluded;
                    command = new SqlCommand($"SELECT * FROM Included_products WHERE KU_id = {KUId}", _sqlConnection);
                }
                else
                {
                    dgv = dataGridViewExcluded;
                    command = new SqlCommand($"SELECT * FROM Excluded_products WHERE KU_id = {KUId}", _sqlConnection);
                }
                dgv.Rows.Clear();

                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    dgv.Rows.Add();
                    dgv.Rows[dgv.RowCount - 1].Cells[0].Value = reader[0];
                    dgv.Rows[dgv.RowCount - 1].Cells[1].Value = reader[1];
                    dgv.Rows[dgv.RowCount - 1].Cells[2].Value = reader[2];
                    dgv.Rows[dgv.RowCount - 1].Cells[3].Value = reader[3];
                    dgv.Rows[dgv.RowCount - 1].Cells[4].Value = reader[4];
                    if (reader[5].ToString() != "")
                    {
                        for (int i = 0; i < BrandProd.Rows.Count; i++)
                        {
                            if ((Int64)reader[5] == (Int64)BrandProd.Rows[i][0])
                            {
                                (dgv.Rows[dgv.RowCount - 1].Cells[5] as DataGridViewComboBoxCell).Value = BrandProd.Rows[i][1].ToString();
                                (dgv.Rows[dgv.RowCount - 1].Cells[6] as DataGridViewComboBoxCell).Value = BrandProd.Rows[i][2].ToString();
                                break;
                            }
                        }
                    }

                    // Запрет выбора произв и торг марки для товаров
                    if (dgv.Rows[dgv.RowCount - 1].Cells[2].Value.ToString() == "Товары")
                    {
                        dgv.Rows[dgv.RowCount - 1].Cells[5].ReadOnly = true;
                        dgv.Rows[dgv.RowCount - 1].Cells[6].ReadOnly = true;
                    }
                }
                reader.Close();
                idx++;
            }
        }

        //отображение условий ретро
        private void showTerms(Int64 KUId)
        {
            dataGridViewTerms.Rows.Clear();
            SqlCommand command = new SqlCommand($"SELECT * FROM Terms WHERE KU_id = {KUId}", _sqlConnection);

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                dataGridViewTerms.Rows.Add();
                (dataGridViewTerms.Rows[dataGridViewTerms.RowCount - 1].Cells["FixSum"] as DataGridViewCheckBoxCell).Value = reader[2];
                dataGridViewTerms.Rows[dataGridViewTerms.RowCount - 1].Cells["Criterion"].Value = reader[3];
                dataGridViewTerms.Rows[dataGridViewTerms.RowCount - 1].Cells["PercentSum"].Value = reader[4];
                dataGridViewTerms.Rows[dataGridViewTerms.RowCount - 1].Cells["Total"].Value = reader[5];
                           
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
        private void button7_Click(object sender, EventArgs e) // was: 606-640, now: 606-633
        {
            DialogResult result;
            DataGridView dgv;
            string type = "";
            if (tabControlInEx.SelectedIndex == 0)
            {
                dgv = dataGridViewIncluded;
                type = "TypeP";
            }
            else
            {
                dgv = dataGridViewExcluded;
                type = "TypeM";
            }

            if (dgv.RowCount < 1)
            {
                MessageBox.Show("Нечего удалять", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            result = MessageBox.Show($"Вы уверены, что хотите удалить условие '{dgv.Rows[dgv.CurrentRow.Index].Cells[type].Value}' ?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
                return;

            dgv.Rows.RemoveAt(dgv.CurrentRow.Index);
        }

        
        // Добавление строк в таблицы включения и исключения
        private void addLine(string type)
        {
            
            //Int64 KU_id = _KU_id;
            Int16 tabPageId = Convert.ToInt16(tabControlInEx.SelectedIndex);
            SqlCommand command;
            switch (type)
            {
                case "Все":
                    if (tabPageId == 0)
                    {
                        for (int i = 0; i < dataGridViewIncluded.RowCount; i++)
                        {
                            if (dataGridViewIncluded.Rows[i].Cells["TypeP"].Value.ToString() == "Все")
                            {
                                MessageBox.Show("Данное условие уже добавлено!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        dataGridViewIncluded.Rows.Add();
                        dataGridViewIncluded.Rows[dataGridViewIncluded.RowCount - 1].Cells["TypeP"].Value = "Все";
                    
                    }
                    else
                    {
                        DialogResult result = DialogResult.Yes;
                        // Проверка, есть ли условие "все" в условиях на добавление
                        for (int i = 0; i < dataGridViewIncluded.RowCount; i++)
                        {
                            if (dataGridViewIncluded.Rows[i].Cells["TypeP"].Value.ToString() == "Все" && (dataGridViewIncluded.Rows[i].Cells["ProducerP"] as DataGridViewComboBoxCell).Value is null && (dataGridViewIncluded.Rows[i].Cells["BrandP"] as DataGridViewComboBoxCell).Value is null)
                                result = MessageBox.Show("В условиях на добавление есть условие 'Все', если добавить условие 'Все' для исключения, ни один товар не будет выбран.\nВы уверены, что хотите добавить это условие?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        }
                        if (result == DialogResult.Yes)
                        {
                            for (int i = 0; i < dataGridViewExcluded.RowCount; i++)
                            {
                                if (dataGridViewExcluded.Rows[i].Cells["TypeM"].Value.ToString() == "Все")
                                {
                                    MessageBox.Show("Данное условие уже добавлено!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                            }
                            dataGridViewExcluded.Rows.Add();
                            dataGridViewExcluded.Rows[dataGridViewExcluded.RowCount - 1].Cells["TypeM"].Value = "Все";
                           
                        }
                    }

                    break;
                case "Категория":
                    if (tabPageId == 0)
                    {
                        dataGridViewIncluded.Rows.Add();
                        dataGridViewIncluded.Rows[dataGridViewIncluded.RowCount - 1].Cells["TypeP"].Value = type;
                        dataGridViewIncluded.Rows[dataGridViewIncluded.RowCount - 1].Cells["Attribute1P"].Value = CategoryID[0];
                        dataGridViewIncluded.Rows[dataGridViewIncluded.RowCount - 1].Cells["Attribute2P"].Value = findNameById(CategoryID[0]);
                   
                    }
                    else
                    {
                        dataGridViewExcluded.Rows.Add();
                        dataGridViewExcluded.Rows[dataGridViewExcluded.RowCount - 1].Cells["TypeM"].Value = type;
                        dataGridViewExcluded.Rows[dataGridViewExcluded.RowCount - 1].Cells["Attribute1M"].Value = CategoryID[0];
                        dataGridViewExcluded.Rows[dataGridViewExcluded.RowCount - 1].Cells["Attribute2M"].Value = findNameById(CategoryID[0]);
                       
                    }
                   
                    break;
                case "Товары":
                    for (int i = 0; i < ProdIds.Count; i++)
                    {
                        string _ProdName;
                        if (tabPageId == 0)
                        {
                            dataGridViewIncluded.Rows.Add();
                            dataGridViewIncluded.Rows[dataGridViewIncluded.RowCount - 1].Cells["TypeP"].Value = type;
                            dataGridViewIncluded.Rows[dataGridViewIncluded.RowCount - 1].Cells["Attribute1P"].Value = ProdIds[i];
                            command = new SqlCommand($"SELECT Name FROM Products WHERE Product_id = {ProdIds[i]}", _sqlConnection);
                            _ProdName = command.ExecuteScalar().ToString();
                            dataGridViewIncluded.Rows[dataGridViewIncluded.RowCount - 1].Cells["Attribute2P"].Value = _ProdName;

                            if (dataGridViewIncluded.Rows[dataGridViewIncluded.RowCount - 1].Cells["TypeP"].Value.ToString() == "Товары")
                            {
                                dataGridViewIncluded.Rows[dataGridViewIncluded.RowCount - 1].Cells["ProducerP"].ReadOnly = true;
                                dataGridViewIncluded.Rows[dataGridViewIncluded.RowCount - 1].Cells["BrandP"].ReadOnly = true;
                            }
                           
                        }
                        else
                        {
                            dataGridViewExcluded.Rows.Add();
                            dataGridViewExcluded.Rows[dataGridViewExcluded.RowCount - 1].Cells["TypeM"].Value = type;
                            dataGridViewExcluded.Rows[dataGridViewExcluded.RowCount - 1].Cells["Attribute1M"].Value = ProdIds[i];
                            command = new SqlCommand($"SELECT Name FROM Products WHERE Product_id = {ProdIds[i]}", _sqlConnection);
                            _ProdName = command.ExecuteScalar().ToString();
                            dataGridViewExcluded.Rows[dataGridViewExcluded.RowCount - 1].Cells["Attribute2M"].Value = _ProdName;

                            if (dataGridViewExcluded.Rows[dataGridViewExcluded.RowCount - 1].Cells["TypeM"].Value.ToString() == "Товары")
                            {
                                dataGridViewExcluded.Rows[dataGridViewExcluded.RowCount - 1].Cells["ProducerM"].ReadOnly = true;
                                dataGridViewExcluded.Rows[dataGridViewExcluded.RowCount - 1].Cells["BrandM"].ReadOnly = true;
                            }
                          
                        }
                     
                    }

                    break;
            }
          
        }

        //Запись в бд для in/ex через создание ку
        private void AddInExBD() // was: 750-914, now: 750-869
        {
           
            SqlCommand command;
            if (buttonCreate.Text.ToString() == "Изменить")
            {
                command = new SqlCommand($"DELETE FROM Included_products WHERE KU_id = '{_KU_id}'", _sqlConnection);
                command.ExecuteNonQuery();
                command = new SqlCommand($"DELETE FROM Excluded_products WHERE KU_id = '{_KU_id}'", _sqlConnection);
                command.ExecuteNonQuery();
            }
            for (int i = 0; i < dataGridViewIncluded.RowCount; i++)
            {
                 switch (dataGridViewIncluded.Rows[i].Cells["TypeP"].Value.ToString())
                 {
                        case "Все":
                            command = new SqlCommand($"INSERT INTO Included_products (KU_id, Type) VALUES ({_KU_id}, 'Все')", _sqlConnection);
                            command.ExecuteNonQuery();

                            //производитель и марка
                            if (!((dataGridViewIncluded.Rows[i].Cells["ProducerP"] as DataGridViewComboBoxCell).Value is null))
                            {
                                command = new SqlCommand($"UPDATE Included_products SET BrandProdID = " +
                                    $"'{findBrandProdId(dataGridViewIncluded.Rows[i].Cells["ProducerP"].Value.ToString(), 1)}' WHERE KU_id = '{_KU_id}' AND Type = " +
                                    $"'{dataGridViewIncluded.Rows[i].Cells["TypeP"].Value}'", _sqlConnection);
                                command.ExecuteNonQuery();
                            }
                        break;

                        case "Категория":

                            command = new SqlCommand($"INSERT INTO Included_products (KU_id, Type, Attribute_1, Attribute_2) VALUES (" +
                            $"{_KU_id}, 'Категория', '{dataGridViewIncluded.Rows[i].Cells["Attribute1P"].Value}', '{dataGridViewIncluded.Rows[i].Cells["Attribute2P"].Value}')", _sqlConnection);
                            command.ExecuteNonQuery();

                            //производитель и марка
                            if (!((dataGridViewIncluded.Rows[i].Cells["ProducerP"] as DataGridViewComboBoxCell).Value is null))
                            {
                                command = new SqlCommand($"UPDATE Included_products SET BrandProdID = " +
                                    $"'{findBrandProdId(dataGridViewIncluded.Rows[i].Cells["ProducerP"].Value.ToString(), 1)}' WHERE KU_id = '{_KU_id}' AND Type = " +
                                    $"'{dataGridViewIncluded.Rows[i].Cells["TypeP"].Value}' AND Attribute_1 = '{dataGridViewIncluded.Rows[i].Cells["Attribute1P"].Value}' " +
                                    $"AND Attribute_2 = '{dataGridViewIncluded.Rows[i].Cells["Attribute2P"].Value}'", _sqlConnection);
                                command.ExecuteNonQuery();
                            }
                        break;

                        case "Товары":

                            command = new SqlCommand($"INSERT INTO Included_products (KU_id, Type, Attribute_1, Attribute_2) VALUES (" +
                            $"{_KU_id}, 'Товары', '{dataGridViewIncluded.Rows[i].Cells["Attribute1P"].Value}', '{dataGridViewIncluded.Rows[i].Cells["Attribute2P"].Value}')", _sqlConnection);
                            command.ExecuteNonQuery();

                            //производитель и марка
                             if (!((dataGridViewIncluded.Rows[i].Cells["ProducerP"] as DataGridViewComboBoxCell).Value is null))
                             {
                                command = new SqlCommand($"UPDATE Included_products SET BrandProdID = " +
                                    $"'{findBrandProdId(dataGridViewIncluded.Rows[i].Cells["ProducerP"].Value.ToString(), 1)}' WHERE KU_id = '{_KU_id}' AND Type = " +
                                    $"'{dataGridViewIncluded.Rows[i].Cells["TypeP"].Value}' AND Attribute_1 = '{dataGridViewIncluded.Rows[i].Cells["Attribute1P"].Value}' " +
                                    $"AND Attribute_2 = '{dataGridViewIncluded.Rows[i].Cells["Attribute2P"].Value}'", _sqlConnection);
                                command.ExecuteNonQuery();
                             }
                         break;
                 }
                
            }
            //таблица исключения
            for (int i = 0; i < dataGridViewExcluded.RowCount; i++)
            {
                switch (dataGridViewExcluded.Rows[i].Cells["TypeM"].Value.ToString())
                {
                    case "Все":
                        command = new SqlCommand($"INSERT INTO Excluded_products (KU_id, Type) VALUES ({_KU_id}, 'Все')", _sqlConnection);
                        command.ExecuteNonQuery();

                        //производитель и марка
                        if (!((dataGridViewExcluded.Rows[i].Cells["ProducerM"] as DataGridViewComboBoxCell).Value is null))
                        {
                            command = new SqlCommand($"UPDATE Excluded_products SET BrandProdID = " +
                                $"'{findBrandProdId(dataGridViewExcluded.Rows[i].Cells["ProducerM"].Value.ToString(), 1)}' WHERE KU_id = '{_KU_id}' AND Type = " +
                                $"'{dataGridViewExcluded.Rows[i].Cells["TypeM"].Value}'", _sqlConnection);
                            command.ExecuteNonQuery();
                        }
                        break;

                    case "Категория":

                        command = new SqlCommand($"INSERT INTO Excluded_products (KU_id, Type, Attribute_1, Attribute_2) VALUES (" +
                            $"{_KU_id}, 'Категория', '{dataGridViewExcluded.Rows[i].Cells["Attribute1M"].Value}', '{dataGridViewExcluded.Rows[i].Cells["Attribute2M"].Value}')", _sqlConnection);
                        command.ExecuteNonQuery();

                        //производитель и марка
                        if (!((dataGridViewExcluded.Rows[i].Cells["ProducerM"] as DataGridViewComboBoxCell).Value is null))
                        {
                            command = new SqlCommand($"UPDATE Excluded_products SET BrandProdID = " +
                                    $"'{findBrandProdId(dataGridViewExcluded.Rows[i].Cells["ProducerM"].Value.ToString(), 1)}' WHERE KU_id = '{_KU_id}' AND Type = " +
                                    $"'{dataGridViewExcluded.Rows[i].Cells["TypeM"].Value}' AND Attribute_1 = '{dataGridViewExcluded.Rows[i].Cells["Attribute1M"].Value}' " +
                                    $"AND Attribute_2 = '{dataGridViewExcluded.Rows[i].Cells["Attribute2M"].Value}'", _sqlConnection);
                            command.ExecuteNonQuery();
                        }
                        break;

                    case "Товары":

                        command = new SqlCommand($"INSERT INTO Excluded_products (KU_id, Type, Attribute_1, Attribute_2) VALUES (" +
                            $"{_KU_id}, 'Товары', '{dataGridViewExcluded.Rows[i].Cells["Attribute1M"].Value}', '{dataGridViewExcluded.Rows[i].Cells["Attribute2M"].Value}')", _sqlConnection);
                        command.ExecuteNonQuery();

                        //производитель и марка
                        if (!((dataGridViewExcluded.Rows[i].Cells["ProducerM"] as DataGridViewComboBoxCell).Value is null))
                        {
                            command = new SqlCommand($"UPDATE Excluded_products SET BrandProdID = " +
                                    $"'{findBrandProdId(dataGridViewExcluded.Rows[i].Cells["ProducerM"].Value.ToString(), 1)}' WHERE KU_id = '{_KU_id}' AND Type = " +
                                    $"'{dataGridViewExcluded.Rows[i].Cells["TypeM"].Value}' AND Attribute_1 = '{dataGridViewExcluded.Rows[i].Cells["Attribute1M"].Value}' " +
                                    $"AND Attribute_2 = '{dataGridViewExcluded.Rows[i].Cells["Attribute2M"].Value}'", _sqlConnection);
                            command.ExecuteNonQuery();
                        }
                        break;
                }
            }
        }


        // Поиск ID пары производитель-торговая марка
        private long findBrandProdId(string brandProdValue, int brandOrProd = 0) // brandOrProd = 0 - поиск по бренду, ...= 1 - поиск по производителю
        {
            for (int i = 0; i < BrandProd.Rows.Count; i++)
            {
                if (brandOrProd == 0 && BrandProd.Rows[i]["Brand"].ToString() == brandProdValue)
                    return Convert.ToInt64(BrandProd.Rows[i]["ID"]);
                else if (BrandProd.Rows[i]["Producer"].ToString() == brandProdValue)
                    return Convert.ToInt64(BrandProd.Rows[i]["ID"]);
            }
            return 0;
        }

        // Поиск произв. или торг. марки по паре
        private string findBrandProdByThemselfs(string brandProdValue, int brandOrProd = 0) // brandOrProd = 0 - поиск по бренду, ...= 1 - поиск по производителю
        {
            for (int i = 0; i < BrandProd.Rows.Count; i++)
            {
                if (brandOrProd == 0 && BrandProd.Rows[i]["Brand"].ToString() == brandProdValue)
                    return BrandProd.Rows[i]["Producer"].ToString();
                else if (BrandProd.Rows[i]["Producer"].ToString() == brandProdValue)
                    return BrandProd.Rows[i]["Brand"].ToString();
            }
            return "";
        }


        // Изменение значения ячеек производителя и торг. марки
        private void dataGridViewInEx_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = tabControlInEx.SelectedIndex == 0 ? dataGridViewIncluded : dataGridViewExcluded;
            string producer = tabControlInEx.SelectedIndex == 0 ? "ProducerP" : "ProducerM";
            string brand = tabControlInEx.SelectedIndex == 0 ? "BrandP" : "BrandM";

            if (dgv.CurrentCell.OwningColumn.Name == producer || dgv.CurrentCell.OwningColumn.Name == brand) // Если произошло изменение в целевых столбцах
            {
                if (dgv.CurrentCell.OwningColumn.Name == producer)
                    dgv.Rows[dgv.CurrentRow.Index].Cells[dgv.Columns[brand].Index].Value = findBrandProdByThemselfs($"{dgv.CurrentCell.Value}");
                else
                    dgv.Rows[dgv.CurrentRow.Index].Cells[dgv.Columns[producer].Index].Value = findBrandProdByThemselfs($"{dgv.CurrentCell.Value}", 1);
            }
        }
        


        // Удаление данных из комбобоксов в таблицах
        private void InputKUForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataGridView dgv;

            // Отслеживание нажатия на delete и backspace
            if (e.KeyChar == (char)Keys.Delete || e.KeyChar == (char)Keys.Back)
            {
                if (tabControlInEx.SelectedIndex == 0)
                    dgv = dataGridViewIncluded;
                else
                    dgv = dataGridViewExcluded;

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
            dataGridViewTerms.Rows.Add();
        }
        //Удаление строки
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridViewTerms.RowCount > 0)
                dataGridViewTerms.Rows.RemoveAt(dataGridViewTerms.CurrentRow.Index);
            else
                MessageBox.Show("Отсутствуют строки для удаления!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            labelMain.Location = new System.Drawing.Point(Convert.ToInt32((panel1.Width - labelMain.Width) / 2), labelMain.Location.Y);

            panel2.Height = Height - 400;
            TabPage activePage = tabControlMain.SelectedTab;
            int distance = Convert.ToInt32((activePage.Width - groupBoxDescription.Width - groupBoxDocument.Width - groupBoxSettings.Width - groupBoxPeriod.Width) / 5);
            int distanceY = Convert.ToInt32((activePage.Height - groupBoxDocument.Height) / 2);
            
            groupBoxDescription.Location = new System.Drawing.Point(distance, distanceY);
            groupBoxDocument.Location = new System.Drawing.Point(groupBoxDescription.Location.X + groupBoxDescription.Width + distance, distanceY);
            groupBoxSettings.Location = new System.Drawing.Point(groupBoxDocument.Location.X + groupBoxDocument.Width + distance, distanceY);
            groupBoxPeriod.Location = new System.Drawing.Point(groupBoxSettings.Location.X + groupBoxSettings.Width + distance, distanceY);

            panel3.Height = panel4.Location.Y - panel3.Location.Y;
            tabControlInEx.Height = panel3.Height;

            dataGridViewTerms.Height = activePage.Height - 12;
        }


        // Закрытие подключения к БД
        private void InputKUForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _sqlConnection.Close();
        }

    }
}