
namespace РасчетКУ
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxSdvig = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.labelMain = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxSdvig
            // 
            this.textBoxSdvig.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxSdvig.Location = new System.Drawing.Point(102, 79);
            this.textBoxSdvig.Name = "textBoxSdvig";
            this.textBoxSdvig.Size = new System.Drawing.Size(124, 26);
            this.textBoxSdvig.TabIndex = 1;
            this.textBoxSdvig.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // buttonSave
            // 
            this.buttonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSave.Location = new System.Drawing.Point(107, 121);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(115, 36);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelMain
            // 
            this.labelMain.AutoSize = true;
            this.labelMain.Font = new System.Drawing.Font("Book Antiqua", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMain.Location = new System.Drawing.Point(33, 12);
            this.labelMain.Name = "labelMain";
            this.labelMain.Size = new System.Drawing.Size(262, 52);
            this.labelMain.TabIndex = 3;
            this.labelMain.Text = "Введите количество дней \r\nдля сдвига даты расчета";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonSave);
            this.panel1.Controls.Add(this.labelMain);
            this.panel1.Controls.Add(this.textBoxSdvig);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(12);
            this.panel1.Size = new System.Drawing.Size(329, 186);
            this.panel1.TabIndex = 4;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(238)))), ((int)(((byte)(168)))));
            this.ClientSize = new System.Drawing.Size(329, 186);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(345, 225);
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.Resize += new System.EventHandler(this.SettingsForm_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSdvig;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label labelMain;
        private System.Windows.Forms.Panel panel1;
    }
}