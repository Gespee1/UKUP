using System;
using System.Data;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;
using System.Threading;
using System.IO;

namespace РасчетКУ
{
    public partial class KUGraphForm : Form
    {
        private SqlConnection SqlCon;
        private DataGridViewSelectedRowCollection dgvSelectedRows;
        private bool byDate = false, _asked = false;

        private string VendorName;
        private string EntitiesName;
        private string DocNum;
        private string DocDate;

        public KUGraphForm()
        {
            InitializeComponent();
        }

        // Загрузка формы
        private void Form1_Load(object sender, EventArgs e)
        {
            SqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["DB1"].ConnectionString);
            SqlCon.Open();

            
            dateTimePickerFrom.Format = DateTimePickerFormat.Custom;
            dateTimePickerTo.Format = DateTimePickerFormat.Custom;
            dateTimePickerFrom.CustomFormat = " ";
            dateTimePickerTo.CustomFormat = " ";
           if (dateTimePickerFrom.Format != DateTimePickerFormat.Custom)
            {
                dateTimePickerTo.MinDate = DateTime.Today.AddDays(1);
            }
            ShowGraph();
            doResize();
        }

        //Загрузка графика из БД
        private void ShowGraph()
        {
            DataTable graphs = new DataTable();
            SqlCommand command = new SqlCommand("SELECT * FROM KU_graph", SqlCon);
            SqlDataAdapter adapt = new SqlDataAdapter(command);
            adapt.Fill(graphs);

            dataGridViewKUGraph.Rows.Clear();
            for (int i = 0; i < graphs.Rows.Count; i++)
            {
                dataGridViewKUGraph.Rows.Add();
                dataGridViewKUGraph.Rows[i].Cells["Graph_Id"].Value = graphs.Rows[i][0];
                dataGridViewKUGraph.Rows[i].Cells["KU_id"].Value = graphs.Rows[i][1];
                command = new SqlCommand($"SELECT Vend_account FROM KU WHERE KU_id = {graphs.Rows[i][1]}", SqlCon);
                dataGridViewKUGraph.Rows[i].Cells["VendorAcc"].Value = command.ExecuteScalar();
                command = new SqlCommand($"SELECT Docu_code FROM KU WHERE KU_id = {graphs.Rows[i][1]}", SqlCon);
                dataGridViewKUGraph.Rows[i].Cells["ContractCode"].Value = command.ExecuteScalar();
                dataGridViewKUGraph.Rows[i].Cells["Vendor_id"].Value = graphs.Rows[i][2];
                command = new SqlCommand($"SELECT Name FROM Vendors WHERE Vendor_id = {graphs.Rows[i][2]}", SqlCon);
                dataGridViewKUGraph.Rows[i].Cells["VendorNam"].Value = command.ExecuteScalar();
                dataGridViewKUGraph.Rows[i].Cells["Period"].Value = graphs.Rows[i][3];
                dataGridViewKUGraph.Rows[i].Cells["Date_from"].Value = Convert.ToDateTime(graphs.Rows[i][4]).ToShortDateString();
                dataGridViewKUGraph.Rows[i].Cells["Date_to"].Value = Convert.ToDateTime(graphs.Rows[i][5]).ToShortDateString();
                dataGridViewKUGraph.Rows[i].Cells["Date_calc"].Value = Convert.ToDateTime(graphs.Rows[i][6]).ToShortDateString();
                dataGridViewKUGraph.Rows[i].Cells["GraphStatus"].Value = graphs.Rows[i][7];
                dataGridViewKUGraph.Rows[i].Cells["GraphSumN"].Value = graphs.Rows[i][8];
                dataGridViewKUGraph.Rows[i].Cells["GraphSumP"].Value = graphs.Rows[i][9];
                if(graphs.Rows[i][10].ToString() != "")
                    dataGridViewKUGraph.Rows[i].Cells["Percent"].Value = Convert.ToDouble(graphs.Rows[i][10]) / 10;
                dataGridViewKUGraph.Rows[i].Cells["GraphSumS"].Value = graphs.Rows[i][11];
                dataGridViewKUGraph.Rows[i].Cells["Turnover"].Value = graphs.Rows[i][12];
            }
        }

        // Кнопка согласовать (статус)
        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewKUGraph.SelectedRows.Count; ++i)
            {
                SqlCommand comm = new SqlCommand($"UPDATE KU_graph SET Status = 'Согласовано' WHERE Graph_id = {dataGridViewKUGraph.SelectedRows[i].Cells["Graph_Id"].Value}", SqlCon);
                comm.ExecuteNonQuery();
            }
            ShowGraph();
        }

        // Расчет БОНУСА выделенных строк
        private void button1_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                byDate = false;
                dgvSelectedRows = dataGridViewKUGraph.SelectedRows;
                progressBarForAsincBonus.Visible = true;
                labelProgress.Visible = true;
                backgroundWorker1.RunWorkerAsync();
            }
            else
                MessageBox.Show("Расчет ретро-бонуса уже запущен, ожидайте.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        //Расчёт БОНУСА с даты по дату
        private void button2_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                byDate = true;
                progressBarForAsincBonus.Visible = true;
                labelProgress.Visible = true;
                backgroundWorker1.RunWorkerAsync();
            }
            else
                MessageBox.Show("Расчет ретро-бонуса уже запущен, ожидайте.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // Изменение минимальной даты окончания, в зависимости от выбранной даты начала
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePickerTo.MinDate = dateTimePickerFrom.Value.AddDays(1);
            dateTimePickerFrom.Format = DateTimePickerFormat.Long;
        }
        // Изменение значения 2 календаря
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dateTimePickerTo.Format = DateTimePickerFormat.Long;
        }

        
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
        // Открытие формы настроек
        private void сдвигДатыРасчётаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form settings = new SettingsForm();
            settings.ShowDialog();
        }

        //Отчёт ворд
        private void WordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string docname = "Docs\\АКТ-счет.docx";
            //string newdocpath = "C:\\Users\\Dmitriy.Skorb\\Documents\\Тест.docx";
            //WordDoc(docname, newdocpath);
            Actions actions = new Actions();
            WordDoc(docname, actions.getFilepath(".docx"));
        }

        //отчет ворд 2
        private void word2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string docname = "Docs\\Приложение_к_договору.docx";
            //string newdocpath = "C:\\Users\\Dmitriy.Skorb\\Documents\\Тест.docx";
            //WordDoc(docname, newdocpath);

            Actions actions = new Actions();
            WordDoc(docname, actions.getFilepath(".docx"));
        }

        //Общий метод вызова отчёта word
        private void WordDoc(string docname, string newdocpath)
        {
            
            SqlCommand cm1 = new SqlCommand($"SELECT Docu_code FROM KU WHERE KU_id = " +
                $"{dataGridViewKUGraph.Rows[dataGridViewKUGraph.CurrentRow.Index].Cells["KU_id"].Value}", SqlCon);
            DocNum = Convert.ToString(cm1.ExecuteScalar());

            SqlCommand cm2 = new SqlCommand($"SELECT Docu_date FROM KU WHERE KU_id = " +
                $"{dataGridViewKUGraph.Rows[dataGridViewKUGraph.CurrentRow.Index].Cells["KU_id"].Value}", SqlCon);
            DocDate = Convert.ToString(cm2.ExecuteScalar());

            DataTable tb1 = new DataTable();
            SqlCommand command1 = new SqlCommand($"SELECT Name, [INN\\KPP], Urastic_address, Account, Bank_name, Bank_bik, Corr_account FROM Vendors WHERE Vendor_id = " +
                $"{dataGridViewKUGraph.Rows[dataGridViewKUGraph.CurrentRow.Index].Cells["Vendor_id"].Value}", SqlCon);
            SqlDataAdapter adapt1 = new SqlDataAdapter(command1);
            adapt1.Fill(tb1);

            DataTable tb2 = new DataTable();
            SqlCommand command2 = new SqlCommand($"SELECT Name, [INN\\KPP], Urastic_address, Account, Bank_name, Bank_bik, Corr_account  FROM Entities WHERE Entity_id = (SELECT Entity_id FROM Vendors WHERE Vendor_id = " +
                $"{dataGridViewKUGraph.Rows[dataGridViewKUGraph.CurrentRow.Index].Cells["Vendor_id"].Value}) ", SqlCon);
            SqlDataAdapter adapt2 = new SqlDataAdapter(command2);
            adapt2.Fill(tb2);

            if (tb2.Rows.Count == 0)
            {
                MessageBox.Show("Отсутствует Юридическое лицо", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                

            File.Copy(docname, newdocpath, true);
            WordHelper helper = new WordHelper(/*Environment.CurrentDirectory + */ newdocpath);
            var items = new Dictionary<string, string>
            {
                {"<num>", Convert.ToString(dataGridViewKUGraph.Rows[dataGridViewKUGraph.CurrentRow.Index].Cells["KU_id"].Value)},
                {"<Doc.Num>", DocNum},
                {"<Doc.Date>", DocDate},
                {"<GraphSumN>", Convert.ToString(dataGridViewKUGraph.Rows[dataGridViewKUGraph.CurrentRow.Index].Cells["GraphSumN"].Value)},
                {"<Kol-vo>", Convert.ToString(dataGridViewKUGraph.Rows[dataGridViewKUGraph.CurrentRow.Index].Cells["Turnover"].Value)},
                {"<GraphSumS>", Convert.ToString(dataGridViewKUGraph.Rows[dataGridViewKUGraph.CurrentRow.Index].Cells["GraphSumS"].Value)},
                {"<Vendors.Name>", Convert.ToString(tb1.Rows[0]["Name"])},
                {"<Vendors.INN\\KPP>", Convert.ToString(tb1.Rows[0]["INN\\KPP"])},
                {"<Vendors.Urastic_address>", Convert.ToString(tb1.Rows[0]["Urastic_address"])},
                {"<Vendors.Account>", Convert.ToString(tb1.Rows[0]["Account"])},
                {"<Vendors.Bank_name>", Convert.ToString(tb1.Rows[0]["Bank_name"])},
                {"<Vendors.Bank_bik>", Convert.ToString(tb1.Rows[0]["Bank_bik"])},
                {"<Vendors.Corr_account>", Convert.ToString(tb1.Rows[0]["Corr_account"])},
                {"<Entities.Name>", Convert.ToString(tb2.Rows[0]["Name"])},
                {"<Entities.INN\\KPP>", Convert.ToString(tb2.Rows[0]["INN\\KPP"])},
                {"<Entities.Urastic_address>", Convert.ToString(tb2.Rows[0]["Urastic_address"])},
                {"<Entities.Account>", Convert.ToString(tb2.Rows[0]["Account"])},
                {"<Entities.Bank_name>", Convert.ToString(tb2.Rows[0]["Bank_name"])},
                {"<Entities.Bank_bik>", Convert.ToString(tb2.Rows[0]["Bank_bik"])},
                {"<Entities.Corr_account>", Convert.ToString(tb2.Rows[0]["Corr_account"])},
                {"<KU_graph.Percent>", Convert.ToString(dataGridViewKUGraph.Rows[dataGridViewKUGraph.CurrentRow.Index].Cells["Percent"].Value)},
                {"<KU_graph.Date_from>", Convert.ToString(dataGridViewKUGraph.Rows[dataGridViewKUGraph.CurrentRow.Index].Cells["Date_from"].Value)},
                {"<KU_graph.Date_to>", Convert.ToString(dataGridViewKUGraph.Rows[dataGridViewKUGraph.CurrentRow.Index].Cells["Date_to"].Value)},
            };

            helper.Process(items);
            // MessageBox.Show("Файл сохранен");

        }

        //общий метод вызова отчётов Excel
        private void ExcelDoc(string docname, string newdocpath, int ex_num)
        {
             File.Copy(docname, newdocpath, true);
            ExcelHelper helper = new ExcelHelper(/*Environment.CurrentDirectory + */ newdocpath);

            SqlCommand cm = new SqlCommand($"SELECT Name FROM Vendors WHERE Vendor_id = " +
                $"{dataGridViewKUGraph.Rows[dataGridViewKUGraph.CurrentRow.Index].Cells["Vendor_id"].Value}", SqlCon);
            VendorName = (string)cm.ExecuteScalar();

            SqlCommand cm1 = new SqlCommand($"SELECT Docu_code FROM KU WHERE KU_id = " +
                $"{dataGridViewKUGraph.Rows[dataGridViewKUGraph.CurrentRow.Index].Cells["KU_id"].Value}", SqlCon);
            DocNum = Convert.ToString(cm1.ExecuteScalar());

            SqlCommand cm2 = new SqlCommand($"SELECT Docu_date FROM KU WHERE KU_id = " +
                $"{dataGridViewKUGraph.Rows[dataGridViewKUGraph.CurrentRow.Index].Cells["KU_id"].Value}", SqlCon);
            DocDate = Convert.ToString(cm2.ExecuteScalar());

            SqlCommand cm3 = new SqlCommand($"SELECT Name FROM Entities WHERE Entity_id = (SELECT Entity_id FROM Vendors WHERE Vendor_id = " +
                $"{dataGridViewKUGraph.Rows[dataGridViewKUGraph.CurrentRow.Index].Cells["Vendor_id"].Value}) ", SqlCon);
            EntitiesName = (string)cm3.ExecuteScalar();

            

            var items = new Dictionary<string, string>
            {
                {"<num>", Convert.ToString(dataGridViewKUGraph.Rows[dataGridViewKUGraph.CurrentRow.Index].Cells["KU_id"].Value)},
                //{"<Doc.Num>", DocNum},
                {"<Doc.Date.Now>", Convert.ToString(DateTime.Now)},
                {"<Sum>", Convert.ToString(dataGridViewKUGraph.Rows[dataGridViewKUGraph.CurrentRow.Index].Cells["GraphSumN"].Value)},
                {"<Kol-vo>", Convert.ToString(dataGridViewKUGraph.Rows[dataGridViewKUGraph.CurrentRow.Index].Cells["Turnover"].Value)},
                //{"<GraphSumS>", Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["GraphSumS"].Value)},
                {"<Entities.Name>", EntitiesName},
                {"<Vendors.Name>", VendorName},
                //{"<KU_graph.Percent>", Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Percent"].Value)},
                {"<KU_graph.Date_from>", Convert.ToString(dataGridViewKUGraph.Rows[dataGridViewKUGraph.CurrentRow.Index].Cells["Date_from"].Value)},
                {"<KU_graph.Date_to>", Convert.ToString(dataGridViewKUGraph.Rows[dataGridViewKUGraph.CurrentRow.Index].Cells["Date_to"].Value)},
            };


            //заполнение табличной части
            
            DataTable tb = new DataTable();
            SqlCommand command1 = new SqlCommand($"SELECT Product_id FROM Included_products_list WHERE Graph_id = {dataGridViewKUGraph.Rows[dataGridViewKUGraph.CurrentRow.Index].Cells["Graph_id"].Value} " +
                $"ORDER BY Product_id DESC", SqlCon);
            SqlDataAdapter adapt1 = new SqlDataAdapter(command1);
            adapt1.Fill(tb);
            DataTable tableExcel = new DataTable();
            tableExcel.Columns.Add("L2_name", typeof(string));
            tableExcel.Columns.Add("L3_name", typeof(string));
            tableExcel.Columns.Add("L4_name", typeof(string));
            tableExcel.Columns.Add("Included_products_list.Product_id", typeof(int));
            tableExcel.Columns.Add("Name", typeof(string));
            tableExcel.Columns.Add("Producer", typeof(string));
            tableExcel.Columns.Add("Quantity", typeof(int));
            tableExcel.Columns.Add("Summ", typeof(int));

            DataTable tableExcel2 = new DataTable();
            tableExcel2.Columns.Add("Invoice_id", typeof(string));
            tableExcel2.Columns.Add("Invoice_Date", typeof(string));
            tableExcel2.Columns.Add("Num_Buy", typeof(string));
            tableExcel2.Columns.Add("Buy_Date", typeof(int));
            tableExcel2.Columns.Add("Status", typeof(string));
            tableExcel2.Columns.Add("Quantity", typeof(int));
            tableExcel2.Columns.Add("Summ", typeof(int));
       
            //Если 1-й документ
            if (ex_num == 1)
            {
                for (int i = 0; i < tb.Rows.Count; i++)
                {

                    SqlCommand command = new SqlCommand($"SELECT L2_name, L3_name, L4_name, Included_products_list.Product_id, Name, Producer, Quantity, Summ " +
                        $"FROM Included_products_list, Products, Invoices_products LEFT JOIN Classifier ON Foreign_id = (Select Classifier_id FROM Products WHERE Product_id = {tb.Rows[i]["Product_id"]})" +
                        $" LEFT JOIN BrandProducer ON BrandProducer.ID = (SELECT BrandProdID FROM Products WHERE Product_id = " +
                        $"{tb.Rows[i]["Product_id"]} )" +
                        $" WHERE Included_products_list.Product_id = {tb.Rows[i]["Product_id"]} AND Included_products_list.Product_id = Products.Product_id AND Included_products_list.Product_id = Invoices_products.Product_id " +
                        $"AND Included_products_list.Invoice_id = Invoices_products.Invoice_id AND Graph_id = {dataGridViewKUGraph.Rows[dataGridViewKUGraph.CurrentRow.Index].Cells["Graph_id"].Value} ", SqlCon);
                    SqlDataReader reader = command.ExecuteReader();

                    reader.Read();
                    tableExcel.Rows.Add();
                    tableExcel.Rows[i]["L2_Name"] = reader[0];
                    tableExcel.Rows[i]["L3_Name"] = reader[1];
                    tableExcel.Rows[i]["L4_Name"] = reader[2];
                    tableExcel.Rows[i]["Included_products_list.Product_id"] = reader[3];
                    tableExcel.Rows[i]["Name"] = reader[4];
                    tableExcel.Rows[i]["Producer"] = reader[5];
                    tableExcel.Rows[i]["Quantity"] = reader[6];
                    tableExcel.Rows[i]["Summ"] = reader[7];
                    reader.Close();

                }
                helper.Process(items, tableExcel);
            }

            //Если 2-й документ
            if (ex_num == 2)
            {
                for (int i = 0; i < tb.Rows.Count; i++)
                {

                    SqlCommand command = new SqlCommand($"SELECT Included_products_list.Invoice_id, Date, Quantity, Summ " +
                        $"FROM Included_products_list, Invoices, Invoices_products  WHERE Included_products_list.Product_id = {tb.Rows[i]["Product_id"]} AND Graph_id = {dataGridViewKUGraph.Rows[dataGridViewKUGraph.CurrentRow.Index].Cells["Graph_id"].Value}" +
                        $" AND Included_products_list.Invoice_id = Invoices_products.Invoice_id AND Invoices.Invoice_id = Included_products_list.Invoice_id AND Included_products_list.Product_id = Invoices_products.Product_id ", SqlCon);
                    SqlDataReader reader = command.ExecuteReader();

                    reader.Read();
                    tableExcel2.Rows.Add();
                    tableExcel2.Rows[i]["Invoice_id"] = reader[0];
                    tableExcel2.Rows[i]["Invoice_Date"] = reader[1];
                    tableExcel2.Rows[i]["Quantity"] = reader[2];
                    tableExcel2.Rows[i]["Summ"] = reader[3];
                    reader.Close();

                }
                helper.Process2(items, tableExcel2);
            }

          //  helper.Dispose();
        }

        //Отчёт Excel1
        private void ExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int docnum = 1; 

            string docname = "Docs\\Отчет_сверка1.xlsx";
            /* string newdocpath = "C:\\Users\\Dmitriy.Skorb\\Documents\\Тест.docx";
             ExcelDoc(docname, newdocpath);*/
            Actions actions = new Actions();
            ExcelDoc(docname, actions.getFilepath(".xlsx"), docnum);
            
         
        }

        //Отчёт Excel2
        private void excel2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int docnum = 2;

            string docname = "Docs\\Отчет_сверка2.xlsx";
            /* string newdocpath = "C:\\Users\\Dmitriy.Skorb\\Documents\\Тест.docx";
             ExcelDoc(docname, newdocpath);*/
            Actions actions = new Actions();
            ExcelDoc(docname, actions.getFilepath(".xlsx"), docnum);
        }


        // Асинхронный расчет бонуса
        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (byDate)
                bonusCalcByDates();
            else
                bonusCalc();

        }
        // Изменение прогресса асинхронного расчета бонуса
        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBarForAsincBonus.Value = e.ProgressPercentage;
            labelProgress.Text = e.ProgressPercentage + "%";
        }
        // Завершение асинхронного расчета
        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            progressBarForAsincBonus.Value = 0;
            labelProgress.Text = "0%";
            progressBarForAsincBonus.Visible = false;
            labelProgress.Visible = false;
            dgvSelectedRows = null;
            ShowGraph();
        }
        // Метод расчета бонуса выделенных строк
        private void bonusCalc()
        {
            // Проверка есть ли рассчет в выбранных строчках или нет
            for (int i = 0; i < dgvSelectedRows.Count; ++i)
            {
                DataGridViewRow row = dgvSelectedRows[i];
                if (row.Cells["GraphStatus"].Value.ToString() == "Рассчитано" && !_asked)
                {
                    DialogResult result;
                    result = MessageBox.Show("В выбранных строках графика уже рассчитана сумма ретро бонуса, пересчитать их?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                        return;
                    else
                        _asked = true;
                }
                // Очистка значений ретро в графике
                SqlCommand command = new SqlCommand($"UPDATE KU_graph SET Sum_calc = NULL, Sum_bonus = NULL, Sum_accept = NULL, Turnover = NULL, [Percent] = NULL WHERE Graph_id = {row.Cells["Graph_Id"].Value}", SqlCon);
                command.ExecuteNonQuery();
                command = new SqlCommand($"DELETE FROM Included_products_list WHERE Graph_id = {row.Cells["Graph_Id"].Value}", SqlCon);
                command.ExecuteNonQuery();
                command = new SqlCommand($"DELETE FROM Excluded_products_list WHERE Graph_id = {row.Cells["Graph_Id"].Value}", SqlCon);
                command.ExecuteNonQuery();
            }

            // Расчет бонуса для каждой выделенной строки
            for (int i = 0; i < dgvSelectedRows.Count; ++i)
            {
                //Thread.Sleep(500);
                DataGridViewRow row = dgvSelectedRows[i];

                //Условие на расчёт бонуса не старше текущей даты 
                if (Convert.ToDateTime(row.Cells["date_To"].Value) < DateTime.Today)
                {
                    // Изменение статуса на "В расчете"
                    SqlCommand command = new SqlCommand($"UPDATE KU_graph SET Status = 'В расчете' WHERE Graph_id = {row.Cells["Graph_Id"].Value}", SqlCon);
                    command.ExecuteNonQuery();

                    Actions actions = new Actions();
                    if (actions.currentRetroCalc(this, row.Index))
                    {
                        // Изменение статуса на "Рассчитано" 
                        command = new SqlCommand($"UPDATE KU_graph SET Status = 'Рассчитано' WHERE Graph_id = {row.Cells["Graph_Id"].Value}", SqlCon);
                    }
                    else
                    {
                        // Изменение статуса на "Создан" 
                        command = new SqlCommand($"UPDATE KU_graph SET Status = 'Создан' WHERE Graph_id = {row.Cells["Graph_Id"].Value}", SqlCon);
                    }
                    command.ExecuteNonQuery();

                    backgroundWorker1.ReportProgress(Convert.ToInt32((i + 1) * 100 / dgvSelectedRows.Count));
                }
            }
        }
        // Метод расчета бонуса по датам
        private void bonusCalcByDates()
        {
            for (int i = 0; i < dataGridViewKUGraph.Rows.Count; ++i)
            {
                DataGridViewRow row = dataGridViewKUGraph.Rows[i];

                //Условие на расчёт бонуса не старше текущей даты 
                if (Convert.ToDateTime(row.Cells["date_To"].Value) < DateTime.Today)
                {
                    //проверка на соответствие временного периода
                    int result = DateTime.Compare(Convert.ToDateTime(row.Cells["Date_calc"].Value), dateTimePickerFrom.Value);
                    int result1 = DateTime.Compare(Convert.ToDateTime(row.Cells["Date_calc"].Value), dateTimePickerTo.Value);
                    if (dateTimePickerFrom.Format == DateTimePickerFormat.Custom && dateTimePickerTo.Format != DateTimePickerFormat.Custom)
                    {
                        if (result1 <= 0)
                        {
                            //Thread.Sleep(1000);
                            // Изменение статуса на "В расчете"
                            SqlCommand command = new SqlCommand($"UPDATE KU_graph SET Status = 'В расчете' WHERE Graph_id = {row.Cells["Graph_Id"].Value}", SqlCon);
                            command.ExecuteNonQuery();

                            Actions actions = new Actions();
                            if (actions.currentRetroCalc(this, row.Index))
                            {
                                // Изменение статуса на "Рассчитано" 
                                command = new SqlCommand($"UPDATE KU_graph SET Status = 'Рассчитано' WHERE Graph_id = {row.Cells["Graph_Id"].Value}", SqlCon);
                            }
                            else
                            {
                                // Изменение статуса на "Создан" 
                                command = new SqlCommand($"UPDATE KU_graph SET Status = 'Создан' WHERE Graph_id = {row.Cells["Graph_Id"].Value}", SqlCon);
                            }
                            command.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        if (result >= 0 && result1 <= 0)
                        {
                            //Thread.Sleep(1000);
                            // Изменение статуса на "В расчете"
                            SqlCommand command = new SqlCommand($"UPDATE KU_graph SET Status = 'В расчете' WHERE Graph_id = {row.Cells["Graph_Id"].Value}", SqlCon);
                            command.ExecuteNonQuery();

                            Actions actions = new Actions();
                            if (actions.currentRetroCalc(this, row.Index))
                            {
                                // Изменение статуса на "Рассчитано" 
                                command = new SqlCommand($"UPDATE KU_graph SET Status = 'Рассчитано' WHERE Graph_id = {row.Cells["Graph_Id"].Value}", SqlCon);
                            }
                            else
                            {
                                // Изменение статуса на "Создан" 
                                command = new SqlCommand($"UPDATE KU_graph SET Status = 'Создан' WHERE Graph_id = {row.Cells["Graph_Id"].Value}", SqlCon);
                            }
                            command.ExecuteNonQuery();
                        }
                    }
                }
                backgroundWorker1.ReportProgress(Convert.ToInt32((i + 1) * 100 / dataGridViewKUGraph.Rows.Count));
            }
        }

        //Отмена расчёта бонуса
        private void buttonCancelCalc_Click(object sender, EventArgs e)
        {
            dgvSelectedRows = dataGridViewKUGraph.SelectedRows;
            // Проверка есть ли рассчет в выбранных строчках или нет
            for (int i = 0; i < dgvSelectedRows.Count; ++i)
            {
                DataGridViewRow row = dgvSelectedRows[i];

                if ((row.Cells["GraphStatus"].Value.ToString() == "Рассчитано") || (row.Cells["GraphStatus"].Value.ToString() == "В расчете"))
                {
                    DialogResult result;
                    result = MessageBox.Show("Вы уверены что хотите отменить расчёт?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                        return;
                }
                else
                {
                    MessageBox.Show("В выбранной строке не существует рассчитаной премии", "Внимание", MessageBoxButtons.OK);
                    return;
                }
                // Очистка значений ретро в графике
                SqlCommand command = new SqlCommand($"UPDATE KU_graph SET Sum_calc = NULL, Sum_bonus = NULL, Sum_accept = NULL,  Turnover = NULL, Status = 'Создан', [Percent] = NULL  WHERE Graph_id = {row.Cells["Graph_Id"].Value}", SqlCon);
                command.ExecuteNonQuery();
                command = new SqlCommand($"DELETE FROM Included_products_list WHERE Graph_id = {row.Cells["Graph_Id"].Value}", SqlCon);
                command.ExecuteNonQuery();
                command = new SqlCommand($"DELETE FROM Excluded_products_list WHERE Graph_id = {row.Cells["Graph_Id"].Value}", SqlCon);
                command.ExecuteNonQuery();
                
            }
            ShowGraph();
        }


        // Открытие формы редактирования КУ
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) // DoubleClick по заголовку
                return;

            Int64 VendorId, KU_id = Convert.ToInt64(dataGridViewKUGraph.Rows[dataGridViewKUGraph.CurrentRow.Index].Cells["KU_id"].Value);
            SqlCommand command = new SqlCommand($"SELECT Vendor_id FROM KU WHERE KU_id = {KU_id}", SqlCon);
            VendorId = Convert.ToInt64(command.ExecuteScalar());

            Form FormInputKu = new InputKUForm(KU_id, VendorId);
            FormInputKu.ShowDialog();
            if (FormInputKu.DialogResult == DialogResult.OK)
                ShowGraph();
        }

        // Изменение размеров формы
        private void KUGraphForm_Resize(object sender, EventArgs e)
        {
            doResize();
        }

        // Изменение размеров панели с гридой
        private void doResize()
        {
            panel1.Height = buttonCalcBonus.Location.Y - menuStrip1.Height;
        }

        // Закрытие соединения с БД
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SqlCon.Close();
        }


        private void KUGraphForm_Activated(object sender, EventArgs e)
        {
            //MessageBox.Show("sfawfawfawf");
        }

       
    }
}
