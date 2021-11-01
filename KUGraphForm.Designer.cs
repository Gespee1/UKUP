﻿namespace РасчетКУ
{
    partial class KUGraphForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.KU_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vendor_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VendorAcc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VendorNam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContractCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Percent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Period = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date_from = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date_to = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date_calc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GraphStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GraphSumP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GraphSumS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GraphSumN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Graph_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокКУToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поставщикиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.экспортToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вВордToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вЭксельToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.word2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excel2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progressLabel = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KU_id,
            this.Vendor_id,
            this.VendorAcc,
            this.VendorNam,
            this.ContractCode,
            this.Percent,
            this.Period,
            this.Date_from,
            this.Date_to,
            this.Date_calc,
            this.GraphStatus,
            this.GraphSumP,
            this.GraphSumS,
            this.GraphSumN,
            this.Graph_Id});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1108, 476);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            // 
            // KU_id
            // 
            this.KU_id.HeaderText = "Номер КУ";
            this.KU_id.Name = "KU_id";
            this.KU_id.ReadOnly = true;
            // 
            // Vendor_id
            // 
            this.Vendor_id.HeaderText = "Номер поставщика";
            this.Vendor_id.Name = "Vendor_id";
            this.Vendor_id.ReadOnly = true;
            this.Vendor_id.ToolTipText = "Процент КУ";
            this.Vendor_id.Visible = false;
            // 
            // VendorAcc
            // 
            this.VendorAcc.HeaderText = "Счет поставщика";
            this.VendorAcc.Name = "VendorAcc";
            this.VendorAcc.ReadOnly = true;
            // 
            // VendorNam
            // 
            this.VendorNam.HeaderText = "Имя";
            this.VendorNam.Name = "VendorNam";
            this.VendorNam.ReadOnly = true;
            // 
            // ContractCode
            // 
            this.ContractCode.HeaderText = "Код договора";
            this.ContractCode.Name = "ContractCode";
            this.ContractCode.ReadOnly = true;
            // 
            // Percent
            // 
            this.Percent.HeaderText = "Процент";
            this.Percent.Name = "Percent";
            this.Percent.ReadOnly = true;
            // 
            // Period
            // 
            this.Period.HeaderText = "Период";
            this.Period.Name = "Period";
            this.Period.ReadOnly = true;
            // 
            // Date_from
            // 
            this.Date_from.HeaderText = "Дата С";
            this.Date_from.Name = "Date_from";
            this.Date_from.ReadOnly = true;
            // 
            // Date_to
            // 
            this.Date_to.HeaderText = "Дата По";
            this.Date_to.Name = "Date_to";
            this.Date_to.ReadOnly = true;
            // 
            // Date_calc
            // 
            this.Date_calc.HeaderText = "Дата расчета";
            this.Date_calc.Name = "Date_calc";
            this.Date_calc.ReadOnly = true;
            // 
            // GraphStatus
            // 
            this.GraphStatus.HeaderText = "Статус";
            this.GraphStatus.Name = "GraphStatus";
            this.GraphStatus.ReadOnly = true;
            this.GraphStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.GraphStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // GraphSumP
            // 
            this.GraphSumP.HeaderText = "Сумма премии";
            this.GraphSumP.Name = "GraphSumP";
            this.GraphSumP.ReadOnly = true;
            this.GraphSumP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // GraphSumS
            // 
            this.GraphSumS.HeaderText = "Фактическая сумма премии";
            this.GraphSumS.Name = "GraphSumS";
            this.GraphSumS.ReadOnly = true;
            this.GraphSumS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // GraphSumN
            // 
            this.GraphSumN.HeaderText = "Товарооборот";
            this.GraphSumN.Name = "GraphSumN";
            this.GraphSumN.ReadOnly = true;
            this.GraphSumN.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Graph_Id
            // 
            this.Graph_Id.HeaderText = "Graph_Id";
            this.Graph_Id.Name = "Graph_Id";
            this.Graph_Id.ReadOnly = true;
            this.Graph_Id.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.настройкиToolStripMenuItem,
            this.экспортToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1132, 29);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.списокКУToolStripMenuItem,
            this.поставщикиToolStripMenuItem});
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(84, 25);
            this.открытьToolStripMenuItem.Text = "Открыть";
            // 
            // списокКУToolStripMenuItem
            // 
            this.списокКУToolStripMenuItem.Name = "списокКУToolStripMenuItem";
            this.списокКУToolStripMenuItem.Size = new System.Drawing.Size(169, 26);
            this.списокКУToolStripMenuItem.Text = "Список КУ";
            this.списокКУToolStripMenuItem.Click += new System.EventHandler(this.списокКУToolStripMenuItem_Click);
            // 
            // поставщикиToolStripMenuItem
            // 
            this.поставщикиToolStripMenuItem.Name = "поставщикиToolStripMenuItem";
            this.поставщикиToolStripMenuItem.Size = new System.Drawing.Size(169, 26);
            this.поставщикиToolStripMenuItem.Text = "Поставщики";
            this.поставщикиToolStripMenuItem.Click += new System.EventHandler(this.поставщикиToolStripMenuItem_Click);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(99, 25);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            this.настройкиToolStripMenuItem.Click += new System.EventHandler(this.настройкиToolStripMenuItem_Click);
            // 
            // экспортToolStripMenuItem
            // 
            this.экспортToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.вВордToolStripMenuItem,
            this.вЭксельToolStripMenuItem,
            this.word2ToolStripMenuItem,
            this.excel2ToolStripMenuItem});
            this.экспортToolStripMenuItem.Name = "экспортToolStripMenuItem";
            this.экспортToolStripMenuItem.Size = new System.Drawing.Size(65, 25);
            this.экспортToolStripMenuItem.Text = "Отчет";
            // 
            // вВордToolStripMenuItem
            // 
            this.вВордToolStripMenuItem.Name = "вВордToolStripMenuItem";
            this.вВордToolStripMenuItem.Size = new System.Drawing.Size(131, 26);
            this.вВордToolStripMenuItem.Text = "Word";
            this.вВордToolStripMenuItem.Click += new System.EventHandler(this.WordToolStripMenuItem_Click);
            // 
            // вЭксельToolStripMenuItem
            // 
            this.вЭксельToolStripMenuItem.Name = "вЭксельToolStripMenuItem";
            this.вЭксельToolStripMenuItem.Size = new System.Drawing.Size(131, 26);
            this.вЭксельToolStripMenuItem.Text = "Excel";
            this.вЭксельToolStripMenuItem.Click += new System.EventHandler(this.ExcelToolStripMenuItem_Click);
            // 
            // word2ToolStripMenuItem
            // 
            this.word2ToolStripMenuItem.Name = "word2ToolStripMenuItem";
            this.word2ToolStripMenuItem.Size = new System.Drawing.Size(131, 26);
            this.word2ToolStripMenuItem.Text = "Word 2";
            this.word2ToolStripMenuItem.Click += new System.EventHandler(this.word2ToolStripMenuItem_Click);
            // 
            // excel2ToolStripMenuItem
            // 
            this.excel2ToolStripMenuItem.Name = "excel2ToolStripMenuItem";
            this.excel2ToolStripMenuItem.Size = new System.Drawing.Size(131, 26);
            this.excel2ToolStripMenuItem.Text = "Excel 2";
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(1001, 535);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(119, 38);
            this.button3.TabIndex = 5;
            this.button3.Text = "Согласовать";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(742, 535);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(253, 38);
            this.button1.TabIndex = 7;
            this.button1.Text = "Рассчёт ретро-бонуса";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(185, 565);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(159, 38);
            this.button2.TabIndex = 8;
            this.button2.Text = "Рассчитать все";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dateTimePicker2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePicker2.Location = new System.Drawing.Point(283, 535);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(183, 24);
            this.dateTimePicker2.TabIndex = 56;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePicker1.Location = new System.Drawing.Point(57, 535);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(183, 24);
            this.dateTimePicker1.TabIndex = 57;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(31, 535);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 20);
            this.label1.TabIndex = 58;
            this.label1.Text = "С";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(247, 535);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 20);
            this.label2.TabIndex = 59;
            this.label2.Text = "По";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 29);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(12);
            this.panel1.Size = new System.Drawing.Size(1132, 500);
            this.panel1.TabIndex = 60;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(797, 0);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(323, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 61;
            this.progressBar1.Visible = false;
            // 
            // progressLabel
            // 
            this.progressLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.progressLabel.AutoSize = true;
            this.progressLabel.BackColor = System.Drawing.Color.Gainsboro;
            this.progressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.progressLabel.Location = new System.Drawing.Point(759, 3);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(20, 16);
            this.progressLabel.TabIndex = 62;
            this.progressLabel.Text = "%";
            this.progressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.progressLabel.Visible = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // KUGraphForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(238)))), ((int)(((byte)(168)))));
            this.ClientSize = new System.Drawing.Size(1132, 612);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(884, 510);
            this.Name = "KUGraphForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "График КУ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.KUGraphForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокКУToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поставщикиToolStripMenuItem;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem экспортToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вВордToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вЭксельToolStripMenuItem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn KU_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vendor_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn VendorAcc;
        private System.Windows.Forms.DataGridViewTextBoxColumn VendorNam;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContractCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Percent;
        private System.Windows.Forms.DataGridViewTextBoxColumn Period;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date_from;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date_to;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date_calc;
        private System.Windows.Forms.DataGridViewTextBoxColumn GraphStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn GraphSumP;
        private System.Windows.Forms.DataGridViewTextBoxColumn GraphSumS;
        private System.Windows.Forms.DataGridViewTextBoxColumn GraphSumN;
        private System.Windows.Forms.DataGridViewTextBoxColumn Graph_Id;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label progressLabel;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripMenuItem word2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem excel2ToolStripMenuItem;
    }
}

