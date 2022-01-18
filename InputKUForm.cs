using System;
using System.Data;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace РасчетКУ
{
    public partial class InputKUForm : Form
    {
        private SqlConnection _sqlConnection;
        private bool _showKU = false, _approved = false, _wasChanged = false, _formLoadDone = false, _allowFormClose = false;
        private Int64 _KU_id, _Vendor_id, _Entity_id;
        private List<Int64> _ProdIds = new List<Int64>();
        private List<string> _CategoryID = new List<string>();
        private DataTable _BrandProd = new DataTable(), _Vendors = new DataTable(), _Entities = new DataTable();
        private Stopwatch _timer = new Stopwatch();
        private delegate void _del(string item); // Делегаты для обращения к объектам одного потока из другого потока
        private delegate void _delInt(int item);
        private delegate void _delObj(object item);
        

        //
        // Конструкторы
        //
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

            textBoxKUCode.Text = _KU_id.ToString();
            buttonCreate.Text = "Изменить";
            buttonCreateNApprove.Text = "Изменить и утвердить";
            comboBoxVendor.Enabled = false;
            textBoxStatus.Visible = true;
            labelStatus.Visible = true;
            buttonCancel.Visible = true;
        }



        // Отдельные потоки
        //
        // Поток 1. Загрузка комбобоксов
        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            // Загрузка данных о поставщиках из БД
            SqlCommand command = new SqlCommand("SELECT Name, max(Vendor_id) AS 'ID' FROM Vendors GROUP BY Name ORDER BY max(Vendor_id)", _sqlConnection);
            SqlDataAdapter adapt = new SqlDataAdapter(command);
            adapt.Fill(_Vendors);
            
            /*if (comboBoxVendor.InvokeRequired)
            {
                comboBoxVendor.Invoke(new _delObj((s) => comboBoxVendor.DataSource = s), _Vendors);
                comboBoxVendor.Invoke(new _del((s) => comboBoxVendor.DisplayMember = s), "Name");
                comboBoxVendor.Invoke(new _del((s) => comboBoxVendor.ValueMember = s), "Name");
                comboBoxVendor.Invoke(new _delInt((s) => comboBoxVendor.SelectedIndex = s), -1);
            }*/
            
            // Загрузка данных о юр. лицах в комбобокс
            command = new SqlCommand("SELECT Entity_id, Director_name FROM Entities WHERE Director_name != 'NULL'", _sqlConnection);
            adapt.SelectCommand = command;
            adapt.Fill(_Entities);

            if (comboBoxEntity.InvokeRequired)
            {
                comboBoxEntity.Invoke(new _delObj((s) => comboBoxEntity.DataSource = s), _Entities);
                comboBoxEntity.Invoke(new _del((s) => comboBoxEntity.DisplayMember = s), "Director_name");
                comboBoxEntity.Invoke(new _del((s) => comboBoxEntity.ValueMember = s), "Director_name");
                comboBoxEntity.Invoke(new _delInt((s) => comboBoxEntity.SelectedIndex = s), -1);
            }
            loadProducerBrand();
        }
        
        // Поток 1. Завершение и отображение данных о КУ
        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            // Загрузка данных о поставщиках в комбобокс
            comboBoxVendor.DataSource = _Vendors;
            comboBoxVendor.DisplayMember = "Name";
            comboBoxVendor.ValueMember = "Name";
            comboBoxVendor.SelectedIndex = -1;

            if (!_approved) // Если не утверждено
            {
                comboBoxVendor.Enabled = true;
                comboBoxEntity.Enabled = true;
                dataGridViewIncluded.Enabled = true;
                dataGridViewExcluded.Enabled = true;
            }
            if (_showKU) // Если КУ уже создано
            {
                SqlCommand command = new SqlCommand($"SELECT Name FROM Vendors WHERE Vendor_id = {_Vendor_id}", _sqlConnection);
                comboBoxVendor.SelectedText = command.ExecuteScalar().ToString();

                if(_Entity_id != 0)
                {
                    command = new SqlCommand($"SELECT Director_name FROM Entities WHERE Entity_id = {_Entity_id}", _sqlConnection);
                    comboBoxEntity.SelectedText = command.ExecuteScalar().ToString();
                }
            }

            _formLoadDone = true;
        }


        // Первоначальная настройка формы при её загрузке
        private void InputKUForm_Load(object sender, EventArgs e)
        {
            _sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB1"].ConnectionString);

            comboBoxVendor.Enabled = false;
            dataGridViewIncluded.Enabled = false;
            dataGridViewExcluded.Enabled = false;

            _sqlConnection.Open();

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

            if (_showKU)
                showSelectedKU();
            else
            {
                if (!backgroundWorker1.IsBusy)
                    backgroundWorker1.RunWorkerAsync();
            }

        }



        //
        // Первая вкладка
        //

        // Отображение КУ, выбранного из формы списка КУ
        private void showSelectedKU()
        {
            // Загрузка всех параметров КУ
            SqlCommand command = new SqlCommand($"SELECT Period, Date_from, Date_to, Status, Description, " +
                $"KU.Entity_id, Vend_account, Contract, Product_type, " +
                $"Docu_name, Docu_header, Transfer_to, Docu_account, Docu_title, Docu_code, Docu_date, Docu_subject, " +
                $"Tax, [Return], Ofactured, Pay_method, KU_type " +
                $"FROM KU, Vendors WHERE KU.Vendor_id = Vendors.Vendor_id AND KU_id = {_KU_id}", _sqlConnection);
            SqlDataReader reader = command.ExecuteReader();

            reader.Read();
            //comboBoxVendor.SelectedItem = reader[0].ToString();
            comboBoxPeriod.SelectedItem = reader[0].ToString();
            dateTimePickerDateFrom.Format = DateTimePickerFormat.Long;
            dateTimePickerDateFrom.Value = Convert.ToDateTime(reader[1]);
            if (reader[2].ToString() != "")
            {
                dateTimePickerDateTo.Format = DateTimePickerFormat.Long;
                dateTimePickerDateTo.Value = Convert.ToDateTime(reader[2]);
            }
            textBoxStatus.Text = reader[3].ToString();
            richTextBoxDescription.Text = reader[4].ToString();
            if (reader[5].ToString() != "")
                _Entity_id = Convert.ToInt64(reader[5]);
            else
                _Entity_id = 0;
            textBoxVendAccount.Text = reader[6].ToString();
            textBoxContract.Text = reader[7].ToString();
            comboBoxProductType.SelectedItem = reader[8].ToString();
            textBoxDocName.Text = reader[9].ToString();
            textBoxDocHeader.Text = reader[10].ToString();
            textBoxTransferTo.Text = reader[11].ToString();
            textBoxDocAccount.Text = reader[12].ToString();
            textBoxDocTitle.Text = reader[13].ToString();
            textBoxDocCode.Text = reader[14].ToString();
            if(reader[15].ToString() != "")
                dateTimePickerDocDate.Value = Convert.ToDateTime(reader[15]);
            richTextBoxDocSubject.Text = reader[16].ToString();
            if(reader[17].ToString() != "")
                checkBoxTax.Checked = Convert.ToBoolean(reader[17]);
            if (reader[18].ToString() != "")
                checkBoxReturn.Checked = Convert.ToBoolean(reader[18]);
            if (reader[19].ToString() != "")
                checkBoxOfactured.Checked = Convert.ToBoolean(reader[19]);
            comboBoxPayMethod.SelectedItem = reader[20].ToString();
            comboBoxKUType.SelectedItem = reader[21].ToString();
            reader.Close();

            if (textBoxStatus.Text == "Утверждено")
                _approved = true;

            // Если КУ в статусе "Утверждено"
            if (_approved)
            {
                buttonCreate.Visible = false;
                buttonCreateNApprove.Visible = false;
                buttonClose.Visible = true;
                buttonUnapprove.Visible = true;
                comboBoxVendor.Enabled = false;
                comboBoxPeriod.Enabled = false;
                comboBoxProductType.Enabled = false;
                comboBoxPayMethod.Enabled = false;
                comboBoxKUType.Enabled = false;
                dateTimePickerDateFrom.Enabled = false;
                dateTimePickerDateTo.Enabled = false;
                dateTimePickerDocDate.Enabled = false;
                richTextBoxDescription.Enabled = false;
                richTextBoxDocSubject.Enabled = false;
                textBoxStatus.Enabled = false;
                textBoxContract.Enabled = false;
                textBoxDocName.Enabled = false;
                textBoxTransferTo.Enabled = false;
                textBoxDocAccount.Enabled = false;
                textBoxDocTitle.Enabled = false;
                textBoxDocCode.Enabled = false;
                textBoxContract.Enabled = false;
                textBoxDocHeader.Enabled = false;
                buttonAddAll.Enabled = false;
                buttonAddProduct.Enabled = false;
                buttonAddCategory.Enabled = false;
                buttonDelete.Enabled = false;
                buttonAddTerm.Enabled = false;
                buttonDelTerm.Enabled = false;
                checkBoxTax.Enabled = false;
                checkBoxReturn.Enabled = false;
                checkBoxOfactured.Enabled = false;
                dataGridViewTerms.Enabled = false;
                //dataGridViewIncluded.ReadOnly = true;
                //dataGridViewExcluded.ReadOnly = true;
            }

            showExInProducts(_KU_id);
            showTerms(_KU_id);
            // Запуск потока по загрузке данных
            if (!backgroundWorker1.IsBusy)
                backgroundWorker1.RunWorkerAsync();
        }

        // Добавление/изменение КУ в БД
        private void addOrUpdateKU(string status, bool addOrUpdate = true) // addOrUpdate: true -> add, false -> update
        {
            // Проверка на неповторность временного периода
            List<DateTime> dateFrom = new List<DateTime>(), dateTo = new List<DateTime>();
            DateTime currDateFrom = dateTimePickerDateFrom.Value, currDateTo = dateTimePickerDateTo.Value;

            SqlCommand command = 
                addOrUpdate == true ? new SqlCommand($"SELECT Date_from, Date_to FROM KU WHERE Vendor_id = {findVendorIdByName(comboBoxVendor.Text)}", _sqlConnection)
                : new SqlCommand($"SELECT Date_from, Date_to FROM KU WHERE Vendor_id = " +
                $"{findVendorIdByName(comboBoxVendor.Text)} AND KU_id != {_KU_id}", _sqlConnection);
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
                    MessageBox.Show($"В базе данных уже содержится информация о коммерческих условиях поставщика '{comboBoxVendor.Text}' в обозначенный период с " +
                        $"{currDateFrom.ToShortDateString()} по {currDateTo.ToShortDateString()}", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            string date_to;
            // Создание КУ
            if (dateTimePickerDateTo.Format == DateTimePickerFormat.Custom)
            {
               date_to = "NULL";
            }
            else
            {
                date_to = "'" + Convert.ToString(dateTimePickerDateTo.Value) + "'";
            }
            
            command = addOrUpdate == true ? new SqlCommand(
                $"INSERT INTO KU (Vendor_id, Period, Date_from, Date_to, Status, Entity_id, Vend_account, Description, Contract, Product_type, Docu_name, Docu_header, " +
                $"Transfer_to, Docu_account, Docu_title, Docu_code, Docu_date, Docu_subject, Tax, [Return], Ofactured, Pay_Method, KU_type)" +
                $" VALUES ({findVendorIdByName(comboBoxVendor.Text)}, '{comboBoxPeriod.SelectedItem}', '{dateTimePickerDateFrom.Value.ToShortDateString()}', " +
                $"{date_to}, '{status}', {findEntityIdByName(comboBoxEntity.Text)}, " +
                $"'{textBoxVendAccount.Text}', '{richTextBoxDescription.Text}', '{textBoxContract.Text}', '{comboBoxProductType.SelectedItem}', '{textBoxDocName.Text}', " +
                $"'{textBoxDocHeader.Text}', '{textBoxTransferTo.Text}', '{textBoxDocAccount.Text}', '{textBoxDocTitle.Text}', '{textBoxDocCode.Text}', " +
                $"'{dateTimePickerDocDate.Value.ToShortDateString()}', '{richTextBoxDocSubject.Text}', '{checkBoxTax.Checked}', '{checkBoxReturn.Checked}', " +
                $"'{checkBoxOfactured.Checked}', '{comboBoxPayMethod.SelectedItem}', '{comboBoxKUType.SelectedItem}')", _sqlConnection)
                : new SqlCommand( // Изменение КУ
                $"UPDATE KU SET Period = '{comboBoxPeriod.SelectedItem}', Date_from = '{dateTimePickerDateFrom.Value.ToShortDateString()}', " +
                $"Date_to = '{dateTimePickerDateTo.Value.ToShortDateString()}', Status = '{status}', Entity_id = " +
                $"{findEntityIdByName(comboBoxEntity.Text)}, Vend_account = '{textBoxVendAccount.Text}', " +
                $"Description = '{richTextBoxDescription.Text}', Contract = '{textBoxContract.Text}', Product_type = '{comboBoxProductType.SelectedItem}', Docu_name = '{textBoxDocName.Text}', " +
                $"Docu_header = '{textBoxDocHeader.Text}', Transfer_to = '{textBoxTransferTo.Text}', Docu_account = '{textBoxDocAccount.Text}', " +
                $"Docu_title = '{textBoxDocTitle.Text}', Docu_code = '{textBoxDocCode.Text}', Docu_date = '{dateTimePickerDocDate.Value.ToShortDateString()}', " +
                $"Docu_subject = '{richTextBoxDocSubject.Text}', Tax = '{checkBoxTax.Checked}', [Return] = '{checkBoxReturn.Checked}', Ofactured = '{checkBoxOfactured.Checked}', " +
                $"Pay_method = '{comboBoxPayMethod.SelectedItem}', KU_type = '{comboBoxKUType.SelectedItem}' WHERE KU_id = {_KU_id}", _sqlConnection);
            command.ExecuteNonQuery();

            if(addOrUpdate == true)
            {
                // Получение номера только что созданного КУ
                command = new SqlCommand($"SELECT KU_id FROM KU WHERE Vendor_id = {findVendorIdByName(comboBoxVendor.Text)} AND Date_from = " +
                    $"'{dateTimePickerDateFrom.Value.ToShortDateString()}' AND Date_to = '{dateTimePickerDateTo.Value.ToShortDateString()}'", _sqlConnection);
                _KU_id = Convert.ToInt64(command.ExecuteScalar());
            }
            else
            {
                //Удаление условий бонуса в БД для последующей перезаписи
                command = new SqlCommand($"DELETE FROM Terms WHERE KU_id = '{_KU_id}'", _sqlConnection);
                command.ExecuteNonQuery();
            }

            //Запись условий бонуса в БД
            for (int i = 0; i < dataGridViewTerms.RowCount; i++)
            {
                command = new SqlCommand(
                    $"INSERT INTO Terms (KU_id, Fixed, Criteria, [Percent/Amount], Total) VALUES ('{_KU_id}', '{dataGridViewTerms.Rows[i].Cells["FixSum"].Value}'," +
                    $" '{dataGridViewTerms.Rows[i].Cells["Criterion"].Value}', '{dataGridViewTerms.Rows[i].Cells["PercentSum"].Value}', " +
                    $"'{dataGridViewTerms.Rows[i].Cells["Total"].Value}')", _sqlConnection);
                command.ExecuteNonQuery();
            }
            // МЕТОД ДЛЯ СОХРАНЕНИЯ iN/EX
            AddInExBD();

            if (addOrUpdate == true)
            {
                comboBoxVendor.Text = "";
                comboBoxPeriod.SelectedIndex = -1;
                comboBoxKUType.SelectedIndex = -1;
                comboBoxPayMethod.SelectedIndex = -1;
                comboBoxEntity.Text = "";
                textBoxVendAccount.Text = "";
                textBoxContract.Text = "";
                comboBoxProductType.SelectedIndex = -1;
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
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        // Изменение минимальной даты окончания, в зависимости от выбранной даты начала
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePickerDateTo.MinDate = dateTimePickerDateFrom.Value.AddDays(1);
            dateTimePickerDateFrom.Format = DateTimePickerFormat.Long;
            if (_formLoadDone)
                _wasChanged = true;
        }
        // Изменение формата календаря даты окончания КУ
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dateTimePickerDateTo.Format = DateTimePickerFormat.Long;
            if (_formLoadDone)
                _wasChanged = true;
        }
        // Изменение формата календаря даты документа
        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            dateTimePickerDocDate.Format = DateTimePickerFormat.Long;
            if (_formLoadDone)
                _wasChanged = true;
        }



        //
        // Вторая вкладка
        //
        // Отображение условий ретро
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



        //
        // Таблицы вкл. и искл. товаров
        //
        // Очистка таблиц вкл и искл товаров + доб. строки по умолчанию
        private void comboBoxVendor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxVendor.SelectedIndex > -1 && _showKU == false)
            {
                dataGridViewIncluded.Rows.Clear();
                dataGridViewExcluded.Rows.Clear();

                //Добавление условия "Все" при создании КУ
                dataGridViewIncluded.Rows.Add();
                dataGridViewIncluded.Rows[0].Cells["TypeP"].Value = "Все";

                // Загрузка счета поставщика
                if(_formLoadDone)
                {
                    SqlCommand command = new SqlCommand($"SELECT Account FROM Vendors WHERE Vendor_id = {findVendorIdByName(comboBoxVendor.Text)}", _sqlConnection);
                    textBoxVendAccount.Text = command.ExecuteScalar().ToString();
                }
            }
        }

        // Загрузка производителя и марки в combobox'ы в таблицах искл и вкл товаров
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

            adapt.Fill(_BrandProd);

            combo1.DataSource = _BrandProd;
            combo1.DisplayMember = "Producer";
            combo1.ValueMember = "Producer";
            combo2.DataSource = _BrandProd;
            combo2.DisplayMember = "Brand";
            combo2.ValueMember = "Brand";
            combo3.DataSource = _BrandProd;
            combo3.DisplayMember = "Producer";
            combo3.ValueMember = "Producer";
            combo4.DataSource = _BrandProd;
            combo4.DisplayMember = "Brand";
            combo4.ValueMember = "Brand";
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
                if (idx == 0)
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
                        for (int i = 0; i < _BrandProd.Rows.Count; i++)
                        {
                            if ((Int64)reader[5] == (Int64)_BrandProd.Rows[i][0])
                            {
                                (dgv.Rows[dgv.RowCount - 1].Cells[5] as DataGridViewComboBoxCell).Value = _BrandProd.Rows[i][1].ToString();
                                (dgv.Rows[dgv.RowCount - 1].Cells[6] as DataGridViewComboBoxCell).Value = _BrandProd.Rows[i][2].ToString();
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
                        dataGridViewIncluded.Rows[dataGridViewIncluded.RowCount - 1].Cells["Attribute1P"].Value = _CategoryID[0];
                        dataGridViewIncluded.Rows[dataGridViewIncluded.RowCount - 1].Cells["Attribute2P"].Value = findCategoryNameById(_CategoryID[0]);

                    }
                    else
                    {
                        dataGridViewExcluded.Rows.Add();
                        dataGridViewExcluded.Rows[dataGridViewExcluded.RowCount - 1].Cells["TypeM"].Value = type;
                        dataGridViewExcluded.Rows[dataGridViewExcluded.RowCount - 1].Cells["Attribute1M"].Value = _CategoryID[0];
                        dataGridViewExcluded.Rows[dataGridViewExcluded.RowCount - 1].Cells["Attribute2M"].Value = findCategoryNameById(_CategoryID[0]);

                    }

                    break;
                case "Товары":
                    for (int i = 0; i < _ProdIds.Count; i++)
                    {
                        string _ProdName;
                        if (tabPageId == 0)
                        {
                            dataGridViewIncluded.Rows.Add();
                            dataGridViewIncluded.Rows[dataGridViewIncluded.RowCount - 1].Cells["TypeP"].Value = type;
                            dataGridViewIncluded.Rows[dataGridViewIncluded.RowCount - 1].Cells["Attribute1P"].Value = _ProdIds[i];
                            command = new SqlCommand($"SELECT Name FROM Products WHERE Product_id = {_ProdIds[i]}", _sqlConnection);
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
                            dataGridViewExcluded.Rows[dataGridViewExcluded.RowCount - 1].Cells["Attribute1M"].Value = _ProdIds[i];
                            command = new SqlCommand($"SELECT Name FROM Products WHERE Product_id = {_ProdIds[i]}", _sqlConnection);
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

        // Запись в бд для in/ex через создание ку
        private void AddInExBD() // was: 619-738, now: 619-693
        {
            DataGridView dgv = dataGridViewIncluded;
            string table = "Included_products", type = "TypeP", producer = "ProducerP", attr = "Attribute1P", attr2 = "Attribute2P";
            SqlCommand command;
            int counter = 0;

            while(counter < 1)
            {
                if (buttonCreate.Text.ToString() == "Изменить")
                {
                    command = new SqlCommand($"DELETE FROM {table} WHERE KU_id = '{_KU_id}'", _sqlConnection);
                    command.ExecuteNonQuery();
                }
                for (int i = 0; i < dgv.RowCount; i++)
                {
                    switch (dgv.Rows[i].Cells[type].Value.ToString())
                    {
                        case "Все":
                            command = new SqlCommand($"INSERT INTO {table} (KU_id, Type) VALUES ({_KU_id}, '{dgv.Rows[i].Cells[type].Value}')", _sqlConnection);
                            command.ExecuteNonQuery();

                            //производитель и марка
                            if (!((dgv.Rows[i].Cells[producer] as DataGridViewComboBoxCell).Value is null))
                            {
                                command = new SqlCommand($"UPDATE {table} SET BrandProdID = " +
                                    $"'{findBrandProdId(dgv.Rows[i].Cells[producer].Value.ToString(), 1)}' WHERE KU_id = '{_KU_id}' AND Type = " +
                                    $"'{dgv.Rows[i].Cells[type].Value}'", _sqlConnection);
                                command.ExecuteNonQuery();
                            }
                            break;

                        case "Категория":
                            command = new SqlCommand($"INSERT INTO {table} (KU_id, Type, Attribute_1, Attribute_2) VALUES ({_KU_id}, " +
                                $"'{dgv.Rows[i].Cells[type].Value}', '{dgv.Rows[i].Cells[attr].Value}', '{dgv.Rows[i].Cells[attr2].Value}')", _sqlConnection);
                            command.ExecuteNonQuery();

                            //производитель и марка
                            if (!((dgv.Rows[i].Cells[producer] as DataGridViewComboBoxCell).Value is null))
                            {
                                command = new SqlCommand($"UPDATE {table} SET BrandProdID = " +
                                    $"'{findBrandProdId(dgv.Rows[i].Cells[producer].Value.ToString(), 1)}' WHERE KU_id = '{_KU_id}' AND Type = " +
                                    $"'{dgv.Rows[i].Cells[type].Value}' AND Attribute_1 = '{dgv.Rows[i].Cells[attr].Value}' " +
                                    $"AND Attribute_2 = '{dgv.Rows[i].Cells[attr2].Value}'", _sqlConnection);
                                command.ExecuteNonQuery();
                            }
                            break;

                        case "Товары":
                            command = new SqlCommand($"INSERT INTO {table} (KU_id, Type, Attribute_1, Attribute_2) VALUES ({_KU_id}, " +
                                $"'{dgv.Rows[i].Cells[type].Value}', '{dgv.Rows[i].Cells[attr].Value}', '{dgv.Rows[i].Cells[attr2].Value}')", _sqlConnection);
                            command.ExecuteNonQuery();

                            //производитель и марка
                            if (!((dgv.Rows[i].Cells[producer] as DataGridViewComboBoxCell).Value is null))
                            {
                                command = new SqlCommand($"UPDATE {table} SET BrandProdID = " +
                                    $"'{findBrandProdId(dgv.Rows[i].Cells[producer].Value.ToString(), 1)}' WHERE KU_id = '{_KU_id}' AND Type = " +
                                    $"'{dgv.Rows[i].Cells[type].Value}' AND Attribute_1 = '{dgv.Rows[i].Cells[attr].Value}' " +
                                    $"AND Attribute_2 = '{dgv.Rows[i].Cells[attr2].Value}'", _sqlConnection);
                                command.ExecuteNonQuery();
                            }
                            break;
                    }
                }

                dgv = dataGridViewExcluded;
                table = "Excluded_products";
                type = "TypeM";
                producer = "ProducerM";
                attr = "Attribute1M";
                attr2 = "Attribute2M";
                counter++;
            }
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

        // Удаление данных из комбобоксов в таблицах вкл/искл товаров
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
                    if (dgv.RowCount > 0 && dgv.CurrentCell.ColumnIndex > dgv.ColumnCount - 3) // Проверка наличия строк в таблице и фокуса на целевых столбцах
                    {
                        (dgv.Rows[dgv.CurrentRow.Index].Cells[dgv.ColumnCount - 2] as DataGridViewComboBoxCell).Value = "";
                        (dgv.Rows[dgv.CurrentRow.Index].Cells[dgv.ColumnCount - 1] as DataGridViewComboBoxCell).Value = "";
                    }
                        

                }
            }
        }



        //
        // Кнопки
        //
        // Добавление или изменение данных о КУ
        private void create_button_Click(object sender, EventArgs e)
        {
            if (!nullCheck())
                return;
            _allowFormClose = true;

            // Добавление или изменение информаци о коммерческих условиях
            if (buttonCreate.Text == "Создать")
            {
                addOrUpdateKU("Создано");
            }
            else
            {
                addOrUpdateKU("Создано", false);
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
                _allowFormClose = true;

                if (buttonCreateNApprove.Text == "Создать и утвердить")
                {
                    // Создание и утверждение
                    addOrUpdateKU("Утверждено");
                }
                else
                {
                    // Изменение и утверждение
                    addOrUpdateKU("Утверждено", false);
                }
            }
        }
        // Нажатие на кнопку закрытия КУ (перевод в статус "Закрыто")
        private void close_button_Click(object sender, EventArgs e)
        {
            DialogResult result;

            result = MessageBox.Show("Вы уверены, что хотите изменить статус КУ на 'Закрыто' ?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                _allowFormClose = true;

                SqlCommand command = new SqlCommand($"UPDATE KU SET Status = 'Закрыто' WHERE KU_id = {_KU_id}", _sqlConnection);
                command.ExecuteNonQuery();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            
        }
        // Нажатие на кнопку отмены при изменении КУ
        private void cancel_button_Click(object sender, EventArgs e)
        {
            _allowFormClose = true;

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        // Кнопка сброса статуса КУ
        private void buttonUnapprove_Click(object sender, EventArgs e)
        {
            DialogResult result;
            DataTable tb = new DataTable();
            tb.Columns.Add("Graph_id", typeof(int));
            
            result = MessageBox.Show("Вы уверены, что хотите отменить утверждение КУ и перевести его в статус 'Создано' ?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                _allowFormClose = true;

                SqlCommand command = new SqlCommand($"UPDATE KU SET Status = 'Создано' WHERE KU_id = {_KU_id}", _sqlConnection);
                command.ExecuteNonQuery();
                //Удаление расчета из графика и товаров из InEx 
                SqlCommand command2 = new SqlCommand($"SELECT Graph_id FROM KU_graph WHERE KU_id = {_KU_id}", _sqlConnection);
                SqlDataAdapter adapt1 = new SqlDataAdapter(command2);
                adapt1.Fill(tb);


                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    
                    SqlCommand command3 = new SqlCommand($"DELETE FROM Included_products_list WHERE Graph_id = {tb.Rows[i]["Graph_id"]}", _sqlConnection);
                    command3.ExecuteNonQuery();
                    SqlCommand command4 = new SqlCommand($"DELETE FROM Excluded_products_list WHERE Graph_id = {tb.Rows[i]["Graph_id"]}", _sqlConnection);
                    command4.ExecuteNonQuery();
                    
                }
                
                SqlCommand command5 = new SqlCommand($"DELETE FROM KU_graph WHERE KU_id = {_KU_id}", _sqlConnection);
                command5.ExecuteNonQuery();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        // Кнопка "Добавить все" в таблицы вкл. и искл. товаров
        private void button4_Click(object sender, EventArgs e)
        {
            addLine("Все");
        }
        // Открытие формы выбора категории
        private void btnSelectCategory_Click(object sender, EventArgs e)
        {
            _CategoryID.Clear();

            Form selectCategoryForm = new SelectCategoryForm(ref _CategoryID);
            selectCategoryForm.ShowDialog();

            if (selectCategoryForm.DialogResult == DialogResult.OK)
                addLine("Категория");

        }
        // Открытие формы выбора продуктов
        private void button5_Click(object sender, EventArgs e)
        {
            // Поиск id поставщика по имени
            if (comboBoxVendor.SelectedIndex == -1)
            {
                MessageBox.Show("Не выбран поставщик!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _Vendor_id = findVendorIdByName(comboBoxVendor.Text);

            if (_Vendor_id != 0)
            {
                int selectedVendorId = Convert.ToInt32(_Vendor_id);
                _ProdIds.Clear();

                Form SelectForm = new SelectProductForm(selectedVendorId, ref _ProdIds);
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
        // Кнопка удаления строки в таблицах вкл/иск товаров
        private void button7_Click(object sender, EventArgs e) // was: 606-640, now: 606-624
        {
            DialogResult result;
            DataGridView dgv = tabControlInEx.SelectedIndex == 0 ? dataGridViewIncluded : dataGridViewExcluded;
            string type = tabControlInEx.SelectedIndex == 0 ? "TypeP" : "TypeM";


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
        //
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




        //
        // Остальные методы
        //
        // Проверка ввода обязательных данных
        private bool nullCheck()
        {
            if (comboBoxVendor.Text == "") // Поставщик
            {
                MessageBox.Show("Поставщик не выбран!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (textBoxContract.Text == "") // Контракт
            {
                MessageBox.Show("Контракт не введен!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (comboBoxProductType.SelectedIndex == -1) // Тип товаров
            {
                MessageBox.Show("Тип товаров не введен!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (comboBoxEntity.Text == "") // Юр. лицо
            {
                MessageBox.Show("Юридическое лицо не выбрано!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (textBoxDocName.Text == "") // Имя документа
            {
                MessageBox.Show("Имя документа не введено!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (textBoxDocHeader.Text == "") // Заголовок документа
            {
                MessageBox.Show("Заголовок документа не введен!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (textBoxTransferTo.Text == "") // Начислять бонусы на...
            {
                MessageBox.Show("Не введено, куда начислять бонусы!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (dateTimePickerDocDate.Format == DateTimePickerFormat.Custom) // Дата документа
            {
                MessageBox.Show("Дата документа не введена!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (textBoxDocAccount.Text == "") // Номер счета
            {
                MessageBox.Show("Номер счета не введен!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (textBoxDocTitle.Text == "") // Название документа
            {
                MessageBox.Show("Название документа не введено!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (textBoxDocCode.Text == "") // Код договора
            {
                MessageBox.Show("Код договора не введен!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (richTextBoxDocSubject.Text == "") // Предмет договора
            {
                MessageBox.Show("Предмет договора не введен!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (comboBoxPayMethod.Text == "") // Способ оплаты
            {
                MessageBox.Show("Способ оплаты не выбран!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (comboBoxKUType.Text == "") // Тип КУ
            {
                MessageBox.Show("Тип коммерческого условия не выбран!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (comboBoxPeriod.SelectedIndex == -1) // Период
            {
                MessageBox.Show("Тип периода коммерческого условия не выбран!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (dateTimePickerDateFrom.Format == DateTimePickerFormat.Custom) // Дата начала действия КУ
            {
                MessageBox.Show("Дата начала действия коммерческого условия не введена!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if(dataGridViewTerms.Rows.Count == 0) // Таблица условий бонуса
            {
                MessageBox.Show("Условия бонуса не добавлены!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                for(int i = 0; i < dataGridViewTerms.Rows.Count; i++)
                {
                    if(dataGridViewTerms.Rows[i].Cells["Criterion"].Value is null 
                        || dataGridViewTerms.Rows[i].Cells["PercentSum"].Value is null)
                    {
                        MessageBox.Show("Условия бонуса не введены!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }

            return true;

        }

        // Поиск id поставщика по имени
        private Int64 findVendorIdByName(string vendName)
        {
            for (int i = 0; i < _Vendors.Rows.Count; i++)
            {
                if (_Vendors.Rows[i]["Name"].ToString() == vendName)
                    return Convert.ToInt64(_Vendors.Rows[i]["ID"]);
            }
            return 0;
        }

        // Поиск id юр. лица по имени директора
        private Int64 findEntityIdByName(string EntityDirectorName)
        {
            for (int i = 0; i < _Entities.Rows.Count; i++)
            {
                if (_Entities.Rows[i]["Director_name"].ToString() == EntityDirectorName)
                    return Convert.ToInt64(_Entities.Rows[i]["Entity_id"]);
            }
            return 0;
        }

        // Поиск названия категории
        private string findCategoryNameById(string id)
        {
            SqlCommand command = new SqlCommand($"SELECT L1, L1_name, L2, L2_name, L3, L3_name, L4, L4_name FROM Classifier " +
                $"WHERE L1 = '{id}' OR L2 = '{id}' OR L3 = '{id}' OR L4 = '{id}'", _sqlConnection);
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

        // Поиск ID пары производитель-торговая марка
        private long findBrandProdId(string brandProdValue, int brandOrProd = 0) // brandOrProd = 0 - поиск по бренду, ...= 1 - поиск по производителю
        {
            for (int i = 0; i < _BrandProd.Rows.Count; i++)
            {
                if (brandOrProd == 0 && _BrandProd.Rows[i]["Brand"].ToString() == brandProdValue)
                    return Convert.ToInt64(_BrandProd.Rows[i]["ID"]);
                else if (brandOrProd == 1 && _BrandProd.Rows[i]["Producer"].ToString() == brandProdValue)
                    return Convert.ToInt64(_BrandProd.Rows[i]["ID"]);
            }
            return 0;
        }

        // Поиск произв. или торг. марки по паре
        private string findBrandProdByThemselfs(string brandProdValue, int brandOrProd = 0) // brandOrProd = 0 - поиск по бренду, ...= 1 - поиск по производителю
        {
            for (int i = 0; i < _BrandProd.Rows.Count; i++)
            {
                if (brandOrProd == 1 && _BrandProd.Rows[i]["Brand"].ToString() == brandProdValue)
                    return _BrandProd.Rows[i]["Producer"].ToString();
                else if (brandOrProd == 0 && _BrandProd.Rows[i]["Producer"].ToString() == brandProdValue)
                    return _BrandProd.Rows[i]["Brand"].ToString();
            }
            return "";
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

        

        //
        // Методы отслеживания изменения данных формы
        //
        // Отслеживание изм. значений в комбобоксах
        private void control_TextChanged(object sender, EventArgs e)
        {
            if(_formLoadDone)
                _wasChanged = true;
        }
        // Отслеживание изм. значений в чекбоксах
        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (_formLoadDone)
                _wasChanged = true;
        }
        // Отслеживание изм. значений ячеек и строк в гридах
        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (_formLoadDone)
                _wasChanged = true;
                
        }
        private void dataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (_formLoadDone)
                _wasChanged = true;
        }
        private void dataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (_formLoadDone)
                _wasChanged = true;
        }



        //
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

        
        
        // Закрытие формы
        private void InputKUForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!_wasChanged) // Если не было произведено изменений
                _sqlConnection.Close();
            else if(_allowFormClose) // Если производится "санкционированный" выход
                _sqlConnection.Close();
            else if (MessageBox.Show("При закрытии все несохраненные данные будут утеряны.\n\nВы уверены, что хотите закрыть окно?", 
                "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

    }
}