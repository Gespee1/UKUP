using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace РасчетКУ
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
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
        // Обновление данных в БД из ПБД
        private void RefreshButton_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["DB1"].ConnectionString);
            sqlcon.Open();
            SqlCommand command = new SqlCommand("EXEC MergeDataBases;", sqlcon);
            
            try
            {
                if (command.ExecuteNonQuery() > 0)
                    MessageBox.Show("Данные в базе успешно обновлены!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            sqlcon.Close();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            panel1.Location = new System.Drawing.Point(Convert.ToInt32((ClientSize.Width - panel1.Width) / 2), Convert.ToInt32((ClientSize.Height - panel1.Height) / 2));
        }
    }
}
