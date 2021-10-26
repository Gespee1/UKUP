using System;
using System.Data;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;
using System.Threading;

namespace РасчетКУ
{
    public partial class KUGraphForm : Form
    {
        private SqlConnection SqlCon;
        private DataGridViewSelectedRowCollection dgvSelectedRows;
        private bool byDate = false;
        // Дима, зачем здесь паблик?
        public string VendorName;
        public string EntitiesName;
        public string DocNum;
        public string DocDate;

        public KUGraphForm()
        {
            InitializeComponent();
        }

        // Загрузка формы
        private void Form1_Load(object sender, EventArgs e)
        {
            SqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["DB1"].ConnectionString);
            SqlCon.Open();

            
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = " ";
            dateTimePicker2.CustomFormat = " ";
           if (dateTimePicker1.Format != DateTimePickerFormat.Custom)
            {
                dateTimePicker2.MinDate = DateTime.Today.AddDays(1);
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

            dataGridView1.Rows.Clear();
            for (int i = 0; i < graphs.Rows.Count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells["Graph_Id"].Value = graphs.Rows[i][0];
                dataGridView1.Rows[i].Cells["KU_id"].Value = graphs.Rows[i][1];
                command = new SqlCommand($"SELECT Vend_account FROM KU WHERE KU_id = {graphs.Rows[i][1]}", SqlCon);
                dataGridView1.Rows[i].Cells["VendorAcc"].Value = command.ExecuteScalar();
                command = new SqlCommand($"SELECT Docu_code FROM KU WHERE KU_id = {graphs.Rows[i][1]}", SqlCon);
                dataGridView1.Rows[i].Cells["ContractCode"].Value = command.ExecuteScalar();
                dataGridView1.Rows[i].Cells["Vendor_id"].Value = graphs.Rows[i][2];
                command = new SqlCommand($"SELECT Name FROM Vendors WHERE Vendor_id = {graphs.Rows[i][2]}", SqlCon);
                dataGridView1.Rows[i].Cells["VendorNam"].Value = command.ExecuteScalar();
                dataGridView1.Rows[i].Cells["Percent"].Value = Convert.ToDouble(graphs.Rows[i][3]) / 10;
                dataGridView1.Rows[i].Cells["Period"].Value = graphs.Rows[i][4];
                dataGridView1.Rows[i].Cells["Date_from"].Value = Convert.ToDateTime(graphs.Rows[i][5]).ToShortDateString();
                dataGridView1.Rows[i].Cells["Date_to"].Value = Convert.ToDateTime(graphs.Rows[i][6]).ToShortDateString();
                dataGridView1.Rows[i].Cells["Date_calc"].Value = Convert.ToDateTime(graphs.Rows[i][7]).ToShortDateString();
                dataGridView1.Rows[i].Cells["GraphStatus"].Value = graphs.Rows[i][8];
                dataGridView1.Rows[i].Cells["GraphSumN"].Value = graphs.Rows[i][9];
                dataGridView1.Rows[i].Cells["GraphSumP"].Value = graphs.Rows[i][10];
                dataGridView1.Rows[i].Cells["GraphSumS"].Value = graphs.Rows[i][11];
            }
        }

        // Кнопка согласовать (статус)
        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.SelectedRows.Count; ++i)
            {
                SqlCommand comm = new SqlCommand($"UPDATE KU_graph SET Status = 'Согласовано' WHERE Graph_id = {dataGridView1.SelectedRows[i].Cells["Graph_Id"].Value}", SqlCon);
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
                dgvSelectedRows = dataGridView1.SelectedRows;
                progressBar1.Visible = true;
                progressLabel.Visible = true;
                backgroundWorker1.RunWorkerAsync();
            }
        }

        //Расчёт БОНУСА с даты по дату
        private void button2_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                byDate = true;
                progressBar1.Visible = true;
                progressLabel.Visible = true;
                backgroundWorker1.RunWorkerAsync();
            }
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
        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form settings = new SettingsForm();
            settings.ShowDialog();
        }


        //Отчёт ворд
        private void WordToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            SqlCommand cm = new SqlCommand($"SELECT Name FROM Vendors WHERE Vendor_id = " +
                $"{dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Vendor_id"].Value}", SqlCon);
            VendorName = (string)cm.ExecuteScalar();

            SqlCommand cm1 = new SqlCommand($"SELECT Docu_code FROM KU WHERE KU_id = " +
                $"{dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["KU_id"].Value}", SqlCon);
            DocNum = Convert.ToString(cm1.ExecuteScalar());

            SqlCommand cm2 = new SqlCommand($"SELECT Docu_date FROM KU WHERE KU_id = " +
                $"{dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["KU_id"].Value}", SqlCon);
            DocDate = Convert.ToString(cm1.ExecuteScalar());

            SqlCommand cm3 = new SqlCommand($"SELECT Name FROM Entities WHERE Entity_id = (SELECT Entity_id FROM Vendors WHERE Vendor_id = " +
                $"{dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Vendor_id"].Value}) ", SqlCon);
            EntitiesName = (string)cm3.ExecuteScalar();

            
            WordHelper helper = new WordHelper(Environment.CurrentDirectory + "\\Docs\\АКТ-счет.docx");
            var items = new Dictionary<string, string>
            {
                {"<num>", Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["KU_id"].Value)},
                {"<Doc.Num>", DocNum},
                {"<Doc.Date>", DocDate},
                {"<GraphSumN>", Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["GraphSumN"].Value)},
                {"<GraphSumS>", Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["GraphSumS"].Value)},
                {"<Entities.Name>",EntitiesName},
                {"<Vendors.Name>", VendorName},
                {"<KU_graph.Percent>", Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Percent"].Value)},
                {"<KU_graph.Date_from>", Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Date_from"].Value)},
                {"<KU_graph.Date_to>", Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Date_to"].Value)},
            };
            
            helper.Process(items);
           // MessageBox.Show("Файл сохранен");

        }

        //Отчёт эксель
        private void ExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Excel.Application ObjExcel = new Excel.Application();
            SqlCommand commanda = new SqlCommand($"SELECT Name FROM Vendors WHERE Vendor_id = " +
                 $"{dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Vendor_id"].Value}", SqlCon);
            string VendorName1 = (string)commanda.ExecuteScalar();


            Excel.Workbook ObjWorkBook;
             Excel.Worksheet ObjWorkSheet;
            //Книга.
             ObjWorkBook = ObjExcel.Workbooks.Add(System.Reflection.Missing.Value);
            //Таблица.
            ObjWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ObjWorkBook.Sheets[1];
            
            //Значения y - строка,x - столбец
            ObjWorkSheet.Range[ObjWorkSheet.Cells[1, 1], ObjWorkSheet.Cells[1, 6]].Merge(Type.Missing);
            ObjWorkSheet.Range[ObjWorkSheet.Cells[1, 1], ObjWorkSheet.Cells[1, 6]] = "Отчёт по расчёту размера Ретро-Бонуса для поставщика:";
            ObjWorkSheet.Range[ObjWorkSheet.Cells[1, 7], ObjWorkSheet.Cells[1, 8]].Merge(Type.Missing);
            ObjWorkSheet.Range[ObjWorkSheet.Cells[1, 7], ObjWorkSheet.Cells[1, 8]] = VendorName1;
            ObjWorkSheet.Range[ObjWorkSheet.Cells[1, 1], ObjWorkSheet.Cells[1, 9]].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            ObjWorkSheet.Range[ObjWorkSheet.Cells[1, 1], ObjWorkSheet.Cells[1, 9]].Font.Bold = true;

            ObjWorkSheet.Range[ObjWorkSheet.Cells[4, 1], ObjWorkSheet.Cells[4, 4]].Merge(Type.Missing);
            ObjWorkSheet.Range[ObjWorkSheet.Cells[4, 1], ObjWorkSheet.Cells[4, 4]] = "Размер премии составил: ";
            ObjWorkSheet.Cells[4, 5] = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[9].Value);
            ObjWorkSheet.Range[ObjWorkSheet.Cells[4, 1], ObjWorkSheet.Cells[4, 4]].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            ObjWorkSheet.Range[ObjWorkSheet.Cells[3, 1], ObjWorkSheet.Cells[3, 8]].Merge(Type.Missing);
            ObjWorkSheet.Range[ObjWorkSheet.Cells[3, 1], ObjWorkSheet.Cells[3, 8]] = "Расчет премии был произведен на основании суммы по накладным в размере: ";
            ObjWorkSheet.Range[ObjWorkSheet.Cells[3, 1], ObjWorkSheet.Cells[3, 8]].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            ObjWorkSheet.Cells[3, 9] = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[8].Value);
            ObjWorkSheet.Range[ObjWorkSheet.Cells[3, 1], ObjWorkSheet.Cells[3, 9]].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            ObjWorkSheet.Range[ObjWorkSheet.Cells[3, 10], ObjWorkSheet.Cells[3, 11]].Merge(Type.Missing);
            ObjWorkSheet.Range[ObjWorkSheet.Cells[3, 10], ObjWorkSheet.Cells[3, 11]] = "и процента КУ: ";
            ObjWorkSheet.Range[ObjWorkSheet.Cells[3, 10], ObjWorkSheet.Cells[3, 11]].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            ObjWorkSheet.Cells[3, 12] = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value);

            ObjWorkSheet.Range[ObjWorkSheet.Cells[5, 1], ObjWorkSheet.Cells[5, 4]].Merge(Type.Missing);
            ObjWorkSheet.Range[ObjWorkSheet.Cells[5, 1], ObjWorkSheet.Cells[5, 4]] = "Согласованный размер премии равен: ";
            ObjWorkSheet.Range[ObjWorkSheet.Cells[5, 1], ObjWorkSheet.Cells[5, 4]].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            ObjWorkSheet.Cells[5, 5] = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[10].Value);

            ObjWorkSheet.Range[ObjWorkSheet.Cells[7, 1], ObjWorkSheet.Cells[8, 3]].Merge(Type.Missing);
            ObjWorkSheet.Range[ObjWorkSheet.Cells[7, 1], ObjWorkSheet.Cells[8, 3]].WrapText = true;
            ObjWorkSheet.Range[ObjWorkSheet.Cells[7, 1], ObjWorkSheet.Cells[8, 3]] = "Накладные, использованные для расчета:";
            ObjWorkSheet.Range[ObjWorkSheet.Cells[7, 1], ObjWorkSheet.Cells[8, 3]].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            ObjWorkSheet.Range[ObjWorkSheet.Cells[7, 1], ObjWorkSheet.Cells[8, 3]].Font.Bold = true;

            ObjWorkSheet.Cells[9, 1] = "Код накладной";
            ObjWorkSheet.Cells[9, 1].WrapText = true;
            ObjWorkSheet.Cells[9, 1].ColumnWidth = 10.15;
            ObjWorkSheet.Cells[9, 2] = "Сумма по накладной";
            ObjWorkSheet.Cells[9, 2].WrapText = true;
            ObjWorkSheet.Cells[9, 2].ColumnWidth = 10.15;


            DataTable invoice1 = new DataTable();
            SqlCommand command = new SqlCommand($"SELECT Invoice_id FROM Invoices WHERE Vendor_id = " + $" {dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Vendor_id"].Value} ", SqlCon);
            SqlDataAdapter adt2 = new SqlDataAdapter();
            adt2.SelectCommand = command;
            adt2.Fill(invoice1);

            for (int i = 0; i < invoice1.Rows.Count; i++)
            {
                ObjWorkSheet.Cells[i + 10, 1] = invoice1.Rows[i][0];
            }

            DataTable sum_inv = new DataTable();
            SqlCommand comm = new SqlCommand($"SELECT SUM(Summ) FROM Invoices_products, Invoices WHERE Invoices.Invoice_id = Invoices_products.Invoice_id AND" +
                                $" Invoices.Vendor_id =  {dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Vendor_id"].Value}", SqlCon);
            SqlDataAdapter adt3 = new SqlDataAdapter();
            adt3.SelectCommand = comm;
            adt3.Fill(sum_inv);

            for (int j = 0; j < sum_inv.Rows.Count; j++)
            {
                ObjWorkSheet.Cells[j + 10, 2] = sum_inv.Rows[j][0];
            }


            //  ObjWorkSheet.Rows.AutoFit();
            ObjExcel.Visible = true;
            ObjExcel.UserControl = true;
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
            progressBar1.Value = e.ProgressPercentage;
            progressLabel.Text = e.ProgressPercentage + "%";
        }
        // Завершение асинхронного расчета
        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            progressBar1.Value = 0;
            progressLabel.Text = "0%";
            progressBar1.Visible = false;
            progressLabel.Visible = false;
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
                if (row.Cells["GraphStatus"].Value.ToString() == "Рассчитано")
                {
                    DialogResult result;
                    result = MessageBox.Show("В выбранных строках графика уже рассчитана сумма ретро бонуса, пересчитать их?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                        return;
                }
                // Очистка значений ретро в графике
                SqlCommand command = new SqlCommand($"UPDATE KU_graph SET Sum_calc = NULL, Sum_bonus = NULL, Sum_accept = NULL WHERE Graph_id = {row.Cells["Graph_Id"].Value}", SqlCon);
                command.ExecuteNonQuery();
                command = new SqlCommand($"DELETE FROM Included_products_list WHERE Graph_id = {row.Cells["Graph_Id"].Value}", SqlCon);
                command.ExecuteNonQuery();
                command = new SqlCommand($"DELETE FROM Excluded_products_list WHERE Graph_id = {row.Cells["Graph_Id"].Value}", SqlCon);
                command.ExecuteNonQuery();
            }

            // Расчет бонуса для каждой выделенной строки
            for (int i = 0; i < dgvSelectedRows.Count; ++i)
            {
                Thread.Sleep(500);
                DataGridViewRow row = dgvSelectedRows[i];

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
        // Метод расчета бонуса по датам
        private void bonusCalcByDates()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                DataGridViewRow row = dataGridView1.Rows[i];
                //проверка на соответствие временного периода
                int result = DateTime.Compare(Convert.ToDateTime(row.Cells["Date_calc"].Value), dateTimePicker1.Value);
                int result1 = DateTime.Compare(Convert.ToDateTime(row.Cells["Date_calc"].Value), dateTimePicker2.Value);
                if (dateTimePicker1.Format == DateTimePickerFormat.Custom && dateTimePicker2.Format != DateTimePickerFormat.Custom)
                {
                    if (result1 <= 0)
                    {
                        Thread.Sleep(1000);
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
                        Thread.Sleep(1000);
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
                backgroundWorker1.ReportProgress(Convert.ToInt32((i + 1) * 100 / dataGridView1.Rows.Count));
            }
        }

        // Открытие формы редактирования КУ
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Int64 VendorId, KU_id = Convert.ToInt64(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["KU_id"].Value);
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
            panel1.Height = button1.Location.Y - menuStrip1.Height;
        }

        // Закрытие соединения с БД
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SqlCon.Close();
        }

    }
}
