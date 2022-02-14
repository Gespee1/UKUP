using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;


namespace РасчетКУ
{
    public partial class InvoiceProducts : Form
    {
        private SqlConnection _sqlConnection;
        private string InvoiceId;

        public InvoiceProducts(string Invoice_id)
        {
            
            InitializeComponent();
            InvoiceId = Invoice_id;
        }

        private void InvoiceProducts_Load(object sender, EventArgs e)
        {
            _sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB1"].ConnectionString);
            _sqlConnection.Open();
            //Size = MinimumSize;
            //panel2.Visible = false;
            //doResize();

            SqlCommand command = new SqlCommand($" SELECT Inv_prod_id As 'Код товара в накладной', Qty As 'Количество товара', Amount As 'Сумма', AmountVAT As 'Сумма НДС', VAT As 'НДС, %'" +
                $" FROM Invoices_products WHERE Invoice_number = '{InvoiceId}'", _sqlConnection);
            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = command;
            adapt.Fill(dt);
            advancedDataGridView.DataSource = dt;

        }


        // Изменение размера формы
        private void doResize()
        {
            panel2.Height = ClientSize.Height;
            panel2.Width = ClientSize.Width;
        }
    }
}
