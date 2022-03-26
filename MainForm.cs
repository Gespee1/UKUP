using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading;

namespace РасчетКУ
{
    public partial class MainForm : Form
    {
        private string message;

        public MainForm()
        {
            InitializeComponent();
        }

        // Загрузка формы
        private void MainForm_Load(object sender, EventArgs e)
        {
            /*SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB1"].ConnectionString);
            try
            {
                connection.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Приложение не смогло подключиться к базе данных!\nПроверьте строку подключения или файл базы данных и попробуйте снова.\n" +
                    $"Вызвана следующая ошибка: {ex.Message}", "Внимание!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit();
            }
            
            *//*if(connection.State != ConnectionState.Open)
            {
                
            }*//*
            connection.Close();*/
        }

        // Открытие формы со списком коммерческих условий
        private void KUListButton_Click(object sender, EventArgs e)
        {
            Form FormKUList = new KUListForm();

            FormKUList.Show();
            
        }
        // Открытие формы со списком поставщиков
        private void VendorsListButton_Click(object sender, EventArgs e)
        {
            Form FormVendorsList = new ListForm();

            FormVendorsList.Show();
            
        }
        // Открытие формы с графиком КУ
        private void KUGraphButton_Click(object sender, EventArgs e)
        {
            Form FormKUGraph = new KUGraphForm();
            
            FormKUGraph.Show();
            
        }

        // Асинхронный мёрж базы
        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB1"].ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand("USE DataBaseKU EXEC MergeProcedure @RowCount OUTPUT", connection);
            SqlParameter RowCount = new SqlParameter
            {
                ParameterName = "@RowCount",
                SqlDbType = SqlDbType.BigInt,
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(RowCount);
            command.ExecuteNonQuery();
            
            message = $"Кол-во задействованных в слиянии строк: {RowCount.Value}";
            
            connection.Close();
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            notifyLabel.Text = message;
            notifyLabel.Visible = true;
            waitTimer.Interval = 7000;
            waitTimer.Start();
        }
        // Тик таймера
        private void waitTimer_Tick(object sender, EventArgs e)
        {
            notifyLabel.Visible = false;
            waitTimer.Stop();
        }

        // Изменения размера формы
        private void MainForm_Resize(object sender, EventArgs e)
        {
            panel1.Location = new System.Drawing.Point(Convert.ToInt32((ClientSize.Width - panel1.Width) / 2), Convert.ToInt32((ClientSize.Height - panel1.Height) / 2));
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            Form settings = new SettingsForm();
            settings.ShowDialog();
        }

        private void buttonMerge_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
                backgroundWorker1.RunWorkerAsync();
        }
    }
}
