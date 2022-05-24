using System;
using System.Data;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;
using System.Threading;
using System.IO;
using System.Diagnostics;

namespace РасчетКУ
{
    public partial class KUGraphForm : Form
    {
        private SqlConnection SqlCon;
        private DataGridViewSelectedRowCollection dgvSelectedRows;
        private bool byDate = false, _asked = false;
        private Stopwatch _timer = new Stopwatch();

        private string VendorName;
        private string EntitiesName;
        private string DocNum;
        private string DocDate;

        string user = Environment.MachineName;
        private int GridPosition;

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

            // Фиксация позиции в гриде
        private void DataGridFixPosition()
        {

            GridPosition = dataGridViewKUGraph.FirstDisplayedScrollingRowIndex;

        }
        //Загрузка графика из БД
        private void ShowGraph()
        {
            DataTable graphs = new DataTable();
            List<int> RowIndexes = new List<int>();
            SqlCommand command = new SqlCommand("SELECT * FROM KU_graph", SqlCon);
            SqlDataAdapter adapt = new SqlDataAdapter(command);
            adapt.Fill(graphs);

            // Запись выделенных строк
            if (dataGridViewKUGraph.RowCount > 0)
                for (int i = 0; i < dataGridViewKUGraph.SelectedRows.Count; i++)
                    RowIndexes.Add(dataGridViewKUGraph.SelectedRows[i].Index);

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

            // Отображение ранее выделенных строк
            if(RowIndexes.Count > 0 && RowIndexes[0] < dataGridViewKUGraph.RowCount - 1)
            {
                dataGridViewKUGraph.CurrentCell = dataGridViewKUGraph.Rows[RowIndexes[0]].Cells[0];
                for (int i = 0; i < RowIndexes.Count; i++)
                    dataGridViewKUGraph.Rows[RowIndexes[i]].Cells[0].Selected = true;
            }

            dataGridViewKUGraph.FirstDisplayedScrollingRowIndex = GridPosition;

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

        // Кнопка Утвердить (статус)
        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewKUGraph.SelectedRows.Count; ++i)
            {
                DataGridViewRow row = dataGridViewKUGraph.SelectedRows[i];

                string strstatus = row.Cells["GraphStatus"].Value.ToString();

                if (strstatus == "Рассчитано" || strstatus == "Начислено")
                {
                    SqlCommand comm = new SqlCommand($"UPDATE KU_graph SET Status = 'Утверждено' WHERE Graph_id = {row.Cells["Graph_Id"].Value}", SqlCon);
                    comm.ExecuteNonQuery();
                }
            }
            DataGridFixPosition();
            ShowGraph();
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

        //
        //ОТЧЁТЫ И ВЕРХНЯЯ ПАНЕЛЬ
        //

        //Отчёт ворд
        private void WordToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string docname = "Docs\\АКТ-счет.docx";

            /* Actions actions = new Actions();
             WordDoc(docname, actions.getFilepath(".docx"));*/

            int i = 0;
            SqlCommand command = new SqlCommand($"SELECT Name FROM Vendors WHERE Vendor_id = " +
                $"{dataGridViewKUGraph.Rows[dataGridViewKUGraph.CurrentRow.Index].Cells["Vendor_id"].Value}", SqlCon);
            VendorName = Convert.ToString(command.ExecuteScalar());


            Global_parameters GP = new Global_parameters();
            if (GP.getPath(user) == "null")
            {
                MessageBox.Show("Для того, чтобы создать отчёт установите путь для сохранения в настройках.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                string docpath = GP.getPath(user);
                string newdocpath = docpath + "\\АКТ-счет_" + VendorName + "_" + DateTime.Now.ToString("dd_MM_yyyy") + ".docx";


                while (File.Exists(newdocpath) == true)
                {
                    i++;
                    newdocpath = docpath + "\\АКТ-счет_" + VendorName + "_" + DateTime.Now.ToString("dd_MM_yyyy") + "(" + i.ToString() + ")" + ".docx";
                }

                WordDoc(docname, newdocpath);
            }
        }

        //отчет ворд 2
        private void word2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            string docname = "Docs\\Приложение_к_договору.docx";

            int i = 0;
            SqlCommand command = new SqlCommand($"SELECT Name FROM Vendors WHERE Vendor_id = " +
                $"{dataGridViewKUGraph.Rows[dataGridViewKUGraph.CurrentRow.Index].Cells["Vendor_id"].Value}", SqlCon);
            VendorName = Convert.ToString(command.ExecuteScalar());
            

            Global_parameters GP = new Global_parameters();
            if (GP.getPath(user) == "null")
            {
                MessageBox.Show("Для того, чтобы создать отчёт установите путь для сохранения в настройках.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                string docpath = GP.getPath(user);
                string newdocpath = docpath + "\\Приложение к договору_" + VendorName + "_" + DateTime.Now.ToString("dd_MM_yyyy") + ".docx";

                
                    while (File.Exists(newdocpath) == true)
                    {
                        i++;
                        newdocpath = docpath + "\\Приложение к договору_" + VendorName + "_" + DateTime.Now.ToString("dd_MM_yyyy") + "(" + i.ToString() + ")" + ".docx";
                    }
               
                WordDoc(docname, newdocpath);
            }
        }

       
        //Общий метод вызова отчёта word
        private void WordDoc(string docname, string newdocpath)
        {
            this.UseWaitCursor = true;
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
            SqlCommand command2 = new SqlCommand($"SELECT Name, [INN\\KPP], Urastic_address, Account, Bank_name, Bank_bik, Corr_account  FROM Entities WHERE Foreign_id = (SELECT Entity_id FROM Vendors WHERE Vendor_id = " +
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
                {"<GraphSumS>", Convert.ToString(dataGridViewKUGraph.Rows[dataGridViewKUGraph.CurrentRow.Index].Cells["GraphSumP"].Value)},
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
            this.UseWaitCursor = false;

        }

        //общий метод вызова отчётов Excel
        private void ExcelDoc(string docname, string newdocpath, int ex_num)
        {
            _timer.Restart();
            this.UseWaitCursor = true;
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

            SqlCommand cm3 = new SqlCommand($"SELECT Name FROM Entities WHERE Foreign_id = (SELECT Entity_id FROM Vendors WHERE Vendor_id = " +
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
            
            
            DataTable tableExcel = new DataTable();
            DataTable tableExcel2 = new DataTable();

            _timer.Stop();
            Console.WriteLine($"Подготовительные запросы: {_timer.Elapsed}");

            //Если 1-й документ
            if (ex_num == 1)
            {
                SqlCommand command = new SqlCommand($"SELECT DISTINCT  L2_name, L3_name, L4_name, ipl.Product_id, Name, Producer, Sum(Qty) as Qty, Sum(Amount) as Amount " +
                    $"FROM Included_products_list ipl " +
                    $"LEFT JOIN Products p on p.Foreign_id = ipl.Product_id " +
                    $"LEFT JOIN Classifier c ON c.Foreign_id = p.Classifier_id " +
                    $"LEFT JOIN BrandProducer ON BrandProducer.ID = p.BrandProdID " +
                    $"LEFT JOIN Invoices_products ip on ip.Foreign_product_id = ipl.Product_id " +
                    $"WHERE ipl.Graph_id = {dataGridViewKUGraph.Rows[dataGridViewKUGraph.CurrentRow.Index].Cells["Graph_id"].Value} " +
                    $"and ipl.Graph_id not in (SELECT Graph_id FROM Excluded_products_list) " +
                    $"GROUP BY ipl.Product_id, L2_name, L3_name, L4_name, Name, Producer " +
                    $"ORDER BY ipl.Product_id DESC", SqlCon);
                SqlDataAdapter adapt = new SqlDataAdapter(command);
                adapt.Fill(tableExcel);

                _timer.Restart();
                helper.Process(items, tableExcel);
                _timer.Stop();
                Console.WriteLine($"Заполнение Excel файла: {_timer.Elapsed}");
            }

            //Если 2-й документ
            if (ex_num == 2)
            {
                SqlCommand command = new SqlCommand($"SELECT DISTINCT inv.Invoice_number, Date, Purch_number, Purch_date, Invoice_status, Sum(Qty) as Qty, Sum(Amount) as Amount " +
                    $"FROM Included_products_list incpl " +
                    $"LEFT JOIN Invoices_products invp on invp.Foreign_product_id = incpl.Product_id LEFT JOIN Invoices inv on inv.Invoice_id = incpl.Invoice_id " +
                    $"WHERE Graph_id = {dataGridViewKUGraph.Rows[dataGridViewKUGraph.CurrentRow.Index].Cells["Graph_id"].Value}" +
                    $" and Graph_id not in (SELECT Product_id FROM Excluded_products_list) " +
                    $"GROUP BY inv.Invoice_number, Date, Purch_number, Purch_date, Invoice_status ORDER BY inv.Invoice_number DESC", SqlCon);
                SqlDataAdapter adapt = new SqlDataAdapter(command);
                adapt.Fill(tableExcel2);

                helper.Process2(items, tableExcel2);
            }
            this.UseWaitCursor = false;
        }

        //Отчёт Excel1
        private void ExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int docnum = 1; 

            string docname = "Docs\\Отчет_сверка1.xlsx";
            /*
            Actions actions = new Actions();
            ExcelDoc(docname, actions.getFilepath(".xlsx"), docnum);*/


            int i = 0;
            SqlCommand command = new SqlCommand($"SELECT Name FROM Vendors WHERE Vendor_id = " +
                $"{dataGridViewKUGraph.Rows[dataGridViewKUGraph.CurrentRow.Index].Cells["Vendor_id"].Value}", SqlCon);
            VendorName = Convert.ToString(command.ExecuteScalar());


            Global_parameters GP = new Global_parameters();
            if (GP.getPath(user) == "null")
            {
                MessageBox.Show("Для того, чтобы создать отчёт установите путь для сохранения в настройках.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                string docpath = GP.getPath(user);
                string newdocpath = docpath + "\\Отчет_сверка1_" + VendorName + "_" + DateTime.Now.ToString("dd_MM_yyyy") + ".xlsx";


                while (File.Exists(newdocpath) == true)
                {
                    i++;
                    newdocpath = docpath + "\\Отчет_сверка1_" + VendorName + "_" + DateTime.Now.ToString("dd_MM_yyyy") + "(" + i.ToString() + ")" + ".xlsx";
                }
                ExcelDoc(docname, newdocpath, docnum); 
            }


        }

        //Отчёт Excel2
        private void excel2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int docnum = 2;

            string docname = "Docs\\Отчет_сверка2.xlsx";
            
            /*Actions actions = new Actions();
            ExcelDoc(docname, actions.getFilepath(".xlsx"), docnum);*/

            int i = 0;
            SqlCommand command = new SqlCommand($"SELECT Name FROM Vendors WHERE Vendor_id = " +
                $"{dataGridViewKUGraph.Rows[dataGridViewKUGraph.CurrentRow.Index].Cells["Vendor_id"].Value}", SqlCon);
            VendorName = Convert.ToString(command.ExecuteScalar());


            Global_parameters GP = new Global_parameters();
            if (GP.getPath(user) == "null")
            {
                MessageBox.Show("Для того, чтобы создать отчёт установите путь для сохранения в настройках.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                string docpath = GP.getPath(user);
                string newdocpath = docpath + "\\Отчет_сверка2_" + VendorName + "_" + DateTime.Now.ToString("dd_MM_yyyy") + ".xlsx";


                while (File.Exists(newdocpath) == true)
                {
                    i++;
                    newdocpath = docpath + "\\Отчет_сверка2_" + VendorName + "_" + DateTime.Now.ToString("dd_MM_yyyy") + "(" + i.ToString() + ")" + ".xlsx";
                }

                ExcelDoc(docname, newdocpath, docnum);
            }
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

        

        // Асинхронный расчет бонуса
        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            this.UseWaitCursor = true;
            if (byDate)
                bonusCalcByDates();
            else
                bonusCalc();
            this.UseWaitCursor = false;
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
                
                string strstatus = row.Cells["GraphStatus"].Value.ToString();

                if ((strstatus == "Рассчитано" || strstatus == "В расчете" || strstatus == "Утверждено" || strstatus == "Начислено") && !_asked)
                {
                    DialogResult result;
                    result = MessageBox.Show("В выбранных строках графика уже рассчитана, начислена или утверждена сумма ретро бонуса, пересчитать их?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                DataGridViewRow row = dgvSelectedRows[i];

                //Условие на расчёт бонуса не старше текущей даты 
                if (Convert.ToDateTime(row.Cells["date_Calc"].Value) < DateTime.Today)
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
            _asked = false;
        }
        // Метод расчета бонуса по датам
        private void bonusCalcByDates()
        {
            for (int i = 0; i < dataGridViewKUGraph.Rows.Count; ++i)
            {
                DataGridViewRow row = dataGridViewKUGraph.Rows[i];
                            

                //Условие на расчёт бонуса не старше текущей даты 
                if (Convert.ToDateTime(row.Cells["date_Calc"].Value) < DateTime.Today)
                {

                    
                    //проверка на соответствие временного периода
                    int result = DateTime.Compare(Convert.ToDateTime(row.Cells["Date_calc"].Value), dateTimePickerFrom.Value);
                    int result1 = DateTime.Compare(Convert.ToDateTime(row.Cells["Date_calc"].Value), dateTimePickerTo.Value);
                    if (dateTimePickerFrom.Format == DateTimePickerFormat.Custom && dateTimePickerTo.Format != DateTimePickerFormat.Custom)
                    {
                        if (result1 <= 0)
                        {
                            string strstatus = row.Cells["GraphStatus"].Value.ToString();

                            if ((strstatus == "Рассчитано" || strstatus == "Утверждено") && !_asked)
                            {
                                DialogResult res;
                                res = MessageBox.Show("В выбранных строках графика уже рассчитана или утверждена сумма ретро бонуса, пересчитать их?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (res == DialogResult.No)
                                    return;
                                else
                                    _asked = true;
                            }
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
                            string strstatus = row.Cells["GraphStatus"].Value.ToString();

                            if ((strstatus == "Рассчитано" || strstatus == "Утверждено") && !_asked)
                            {
                                DialogResult res;
                                res = MessageBox.Show("В выбранных строках графика уже рассчитана сумма ретро бонуса, пересчитать их?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (res == DialogResult.No)
                                    return;
                                else
                                    _asked = true;
                            }
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
            _asked = false;
        }

        //Отмена расчёта бонуса
        private void buttonCancelCalc_Click(object sender, EventArgs e)
        {
            this.UseWaitCursor = true;
            dgvSelectedRows = dataGridViewKUGraph.SelectedRows;
            // Проверка есть ли рассчет в выбранных строчках или нет
            for (int i = 0; i < dgvSelectedRows.Count; ++i)
            {
                DataGridViewRow row = dgvSelectedRows[i];

                string strstatus = row.Cells["GraphStatus"].Value.ToString();

                if ((strstatus == "Рассчитано" || strstatus == "В расчете" || strstatus == "Утверждено") && !_asked)
                {
                    DialogResult result;
                    result = MessageBox.Show("Вы уверены что хотите отменить расчёт?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                        return;
                    else
                        _asked = true;
                }
                else if (!_asked)
                {
                    MessageBox.Show("В выбранной строке не существует рассчитаной премии", "Внимание", MessageBoxButtons.OK);
                    ShowGraph();
                    this.UseWaitCursor = false;
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
            _asked = false;
            ShowGraph();
            this.UseWaitCursor = false;
        }


        // Открытие формы редактирования КУ по дабл-клику
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

        private void AsseptCancel_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewKUGraph.SelectedRows.Count; ++i)
            {
                DataGridViewRow row = dataGridViewKUGraph.SelectedRows[i];

                string strstatus = row.Cells["GraphStatus"].Value.ToString();

                if (strstatus == "Утверждено")
                {
                    SqlCommand comm = new SqlCommand($"UPDATE KU_graph SET Status = 'Рассчитано' WHERE Graph_id = {row.Cells["Graph_Id"].Value}", SqlCon);
                    comm.ExecuteNonQuery();
                }
            }
            DataGridFixPosition();
            ShowGraph();

        }

        // Обновление формы при переходе
        private void KUGraphForm_Activated(object sender, EventArgs e)
        {
            //ShowGraph();
        }

       
    }
}
