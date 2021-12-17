using System;
using System.Data;
using System.Windows.Forms;

namespace РасчетКУ
{
    public partial class SettingsForm : Form
    {
        string name1 = "delta";
        public SettingsForm()
        {
            InitializeComponent();
        }

        // Загрузка формы
        private void SettingsForm_Load(object sender, EventArgs e)
        {
            Global_parameters GP = new Global_parameters();
            textBoxSdvig.Text = GP.getParameter(name1);
            if (textBoxSdvig.Text == "null")
                textBoxSdvig.Text = "";
            doResize();
        }

        // Фильтр вводимых данных
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (e.KeyChar != 8 && (e.KeyChar <= 47 || e.KeyChar >= 58))
            {
                e.Handled = true;
            }
        }

        // Кнопка сохранения настроек
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxSdvig.Text.Equals(""))
            {
                MessageBox.Show("Количество дней для сдвига даты расчёта не введено! Попробуйте снова");
            }
            else
            {
               string text = textBoxSdvig.Text;
               Global_parameters GP1 = new Global_parameters();
               GP1.setParameter(name1, text);
               MessageBox.Show("Сохранено!");
              
            }
        }

        // Изменение размера формы
        private void SettingsForm_Resize(object sender, EventArgs e)
        {
            doResize();
        }

        // Подгонка размеров под форму
        private void doResize()
        {
            panel1.Location = new System.Drawing.Point(Convert.ToInt32((ClientSize.Width - panel1.Width) / 2), Convert.ToInt32((ClientSize.Height - panel1.Height) / 2));
        }
    }
}
