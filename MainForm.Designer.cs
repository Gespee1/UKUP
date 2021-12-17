﻿namespace РасчетКУ
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelMain = new System.Windows.Forms.Label();
            this.KUListButton = new System.Windows.Forms.Button();
            this.VendorsListButton = new System.Windows.Forms.Button();
            this.KUGraphButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.notifyLabel = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.waitTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelMain
            // 
            this.labelMain.AutoSize = true;
            this.labelMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMain.Location = new System.Drawing.Point(137, 30);
            this.labelMain.Name = "labelMain";
            this.labelMain.Size = new System.Drawing.Size(151, 24);
            this.labelMain.TabIndex = 2;
            this.labelMain.Text = "Главное меню";
            // 
            // KUListButton
            // 
            this.KUListButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.KUListButton.Location = new System.Drawing.Point(84, 85);
            this.KUListButton.Name = "KUListButton";
            this.KUListButton.Size = new System.Drawing.Size(257, 39);
            this.KUListButton.TabIndex = 3;
            this.KUListButton.Text = "Список коммерческих условий";
            this.KUListButton.UseVisualStyleBackColor = true;
            this.KUListButton.Click += new System.EventHandler(this.KUListButton_Click);
            // 
            // VendorsListButton
            // 
            this.VendorsListButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.VendorsListButton.Location = new System.Drawing.Point(84, 130);
            this.VendorsListButton.Name = "VendorsListButton";
            this.VendorsListButton.Size = new System.Drawing.Size(257, 39);
            this.VendorsListButton.TabIndex = 4;
            this.VendorsListButton.Text = "Справочники";
            this.VendorsListButton.UseVisualStyleBackColor = true;
            this.VendorsListButton.Click += new System.EventHandler(this.VendorsListButton_Click);
            // 
            // KUGraphButton
            // 
            this.KUGraphButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.KUGraphButton.Location = new System.Drawing.Point(84, 175);
            this.KUGraphButton.Name = "KUGraphButton";
            this.KUGraphButton.Size = new System.Drawing.Size(257, 39);
            this.KUGraphButton.TabIndex = 5;
            this.KUGraphButton.Text = "График КУ";
            this.KUGraphButton.UseVisualStyleBackColor = true;
            this.KUGraphButton.Click += new System.EventHandler(this.KUGraphButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.notifyLabel);
            this.panel1.Controls.Add(this.labelMain);
            this.panel1.Controls.Add(this.KUListButton);
            this.panel1.Controls.Add(this.KUGraphButton);
            this.panel1.Controls.Add(this.VendorsListButton);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(426, 267);
            this.panel1.TabIndex = 7;
            // 
            // notifyLabel
            // 
            this.notifyLabel.AutoSize = true;
            this.notifyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.notifyLabel.Location = new System.Drawing.Point(81, 244);
            this.notifyLabel.Name = "notifyLabel";
            this.notifyLabel.Size = new System.Drawing.Size(66, 15);
            this.notifyLabel.TabIndex = 6;
            this.notifyLabel.Text = "notifyLabel";
            this.notifyLabel.Visible = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // waitTimer
            // 
            this.waitTimer.Tick += new System.EventHandler(this.waitTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(238)))), ((int)(((byte)(168)))));
            this.ClientSize = new System.Drawing.Size(426, 268);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(317, 284);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Расчет ретро бонуса";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label labelMain;
        private System.Windows.Forms.Button KUListButton;
        private System.Windows.Forms.Button VendorsListButton;
        private System.Windows.Forms.Button KUGraphButton;
        private System.Windows.Forms.Panel panel1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Timer waitTimer;
        private System.Windows.Forms.Label notifyLabel;
    }
}

