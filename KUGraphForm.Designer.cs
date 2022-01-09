namespace РасчетКУ
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
            this.dataGridViewKUGraph = new System.Windows.Forms.DataGridView();
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
            this.Turnover = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.buttonApprove = new System.Windows.Forms.Button();
            this.buttonCalcBonus = new System.Windows.Forms.Button();
            this.buttonCalcAll = new System.Windows.Forms.Button();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.labelFrom = new System.Windows.Forms.Label();
            this.labelTo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.progressBarForAsincBonus = new System.Windows.Forms.ProgressBar();
            this.labelProgress = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.сдвигДатыРасчётаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKUGraph)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewKUGraph
            // 
            this.dataGridViewKUGraph.AllowUserToAddRows = false;
            this.dataGridViewKUGraph.AllowUserToDeleteRows = false;
            this.dataGridViewKUGraph.AllowUserToResizeRows = false;
            this.dataGridViewKUGraph.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewKUGraph.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewKUGraph.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.Turnover,
            this.Graph_Id});
            this.dataGridViewKUGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewKUGraph.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewKUGraph.Name = "dataGridViewKUGraph";
            this.dataGridViewKUGraph.ReadOnly = true;
            this.dataGridViewKUGraph.RowHeadersVisible = false;
            this.dataGridViewKUGraph.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewKUGraph.Size = new System.Drawing.Size(1108, 476);
            this.dataGridViewKUGraph.TabIndex = 0;
            this.dataGridViewKUGraph.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
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
            this.GraphSumN.HeaderText = "Сумма по накладным";
            this.GraphSumN.Name = "GraphSumN";
            this.GraphSumN.ReadOnly = true;
            this.GraphSumN.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Turnover
            // 
            this.Turnover.HeaderText = "Товарооборот";
            this.Turnover.Name = "Turnover";
            this.Turnover.ReadOnly = true;
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
            this.настройкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сдвигДатыРасчётаToolStripMenuItem});
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(99, 25);
            this.настройкиToolStripMenuItem.Text = "Настройки";
//            this.настройкиToolStripMenuItem.Click += new System.EventHandler(this.настройкиToolStripMenuItem_Click);
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
            this.вВордToolStripMenuItem.Size = new System.Drawing.Size(255, 26);
            this.вВордToolStripMenuItem.Text = "АКТ-счет";
            this.вВордToolStripMenuItem.Click += new System.EventHandler(this.WordToolStripMenuItem_Click);
            // 
            // вЭксельToolStripMenuItem
            // 
            this.вЭксельToolStripMenuItem.Name = "вЭксельToolStripMenuItem";
            this.вЭксельToolStripMenuItem.Size = new System.Drawing.Size(255, 26);
            this.вЭксельToolStripMenuItem.Text = "Отчет-сверка 1";
            this.вЭксельToolStripMenuItem.Click += new System.EventHandler(this.ExcelToolStripMenuItem_Click);
            // 
            // word2ToolStripMenuItem
            // 
            this.word2ToolStripMenuItem.Name = "word2ToolStripMenuItem";
            this.word2ToolStripMenuItem.Size = new System.Drawing.Size(255, 26);
            this.word2ToolStripMenuItem.Text = "Приложение к договору";
            this.word2ToolStripMenuItem.Click += new System.EventHandler(this.word2ToolStripMenuItem_Click);
            // 
            // excel2ToolStripMenuItem
            // 
            this.excel2ToolStripMenuItem.Name = "excel2ToolStripMenuItem";
            this.excel2ToolStripMenuItem.Size = new System.Drawing.Size(255, 26);
            this.excel2ToolStripMenuItem.Text = "Отчет-сверка 2";
            this.excel2ToolStripMenuItem.Click += new System.EventHandler(this.excel2ToolStripMenuItem_Click);
            // 
            // buttonApprove
            // 
            this.buttonApprove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonApprove.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonApprove.Location = new System.Drawing.Point(1001, 535);
            this.buttonApprove.Name = "buttonApprove";
            this.buttonApprove.Size = new System.Drawing.Size(119, 38);
            this.buttonApprove.TabIndex = 5;
            this.buttonApprove.Text = "Согласовать";
            this.buttonApprove.UseVisualStyleBackColor = true;
            this.buttonApprove.Click += new System.EventHandler(this.button3_Click);
            // 
            // buttonCalcBonus
            // 
            this.buttonCalcBonus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCalcBonus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCalcBonus.Location = new System.Drawing.Point(742, 535);
            this.buttonCalcBonus.Name = "buttonCalcBonus";
            this.buttonCalcBonus.Size = new System.Drawing.Size(253, 38);
            this.buttonCalcBonus.TabIndex = 7;
            this.buttonCalcBonus.Text = "Рассчёт ретро-бонуса";
            this.buttonCalcBonus.UseVisualStyleBackColor = true;
            this.buttonCalcBonus.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonCalcAll
            // 
            this.buttonCalcAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCalcAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCalcAll.Location = new System.Drawing.Point(185, 565);
            this.buttonCalcAll.Name = "buttonCalcAll";
            this.buttonCalcAll.Size = new System.Drawing.Size(159, 38);
            this.buttonCalcAll.TabIndex = 8;
            this.buttonCalcAll.Text = "Рассчитать все";
            this.buttonCalcAll.UseVisualStyleBackColor = true;
            this.buttonCalcAll.Click += new System.EventHandler(this.button2_Click);
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dateTimePickerTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePickerTo.Location = new System.Drawing.Point(283, 535);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(183, 24);
            this.dateTimePickerTo.TabIndex = 56;
            this.dateTimePickerTo.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dateTimePickerFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePickerFrom.Location = new System.Drawing.Point(57, 535);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(183, 24);
            this.dateTimePickerFrom.TabIndex = 57;
            this.dateTimePickerFrom.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // labelFrom
            // 
            this.labelFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelFrom.AutoSize = true;
            this.labelFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFrom.Location = new System.Drawing.Point(31, 535);
            this.labelFrom.Name = "labelFrom";
            this.labelFrom.Size = new System.Drawing.Size(20, 20);
            this.labelFrom.TabIndex = 58;
            this.labelFrom.Text = "С";
            // 
            // labelTo
            // 
            this.labelTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelTo.AutoSize = true;
            this.labelTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTo.Location = new System.Drawing.Point(247, 535);
            this.labelTo.Name = "labelTo";
            this.labelTo.Size = new System.Drawing.Size(30, 20);
            this.labelTo.TabIndex = 59;
            this.labelTo.Text = "По";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridViewKUGraph);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 29);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(12);
            this.panel1.Size = new System.Drawing.Size(1132, 500);
            this.panel1.TabIndex = 60;
            // 
            // progressBarForAsincBonus
            // 
            this.progressBarForAsincBonus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarForAsincBonus.Location = new System.Drawing.Point(797, 0);
            this.progressBarForAsincBonus.Name = "progressBarForAsincBonus";
            this.progressBarForAsincBonus.Size = new System.Drawing.Size(323, 23);
            this.progressBarForAsincBonus.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarForAsincBonus.TabIndex = 61;
            this.progressBarForAsincBonus.Visible = false;
            // 
            // labelProgress
            // 
            this.labelProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelProgress.AutoSize = true;
            this.labelProgress.BackColor = System.Drawing.Color.Gainsboro;
            this.labelProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelProgress.Location = new System.Drawing.Point(759, 3);
            this.labelProgress.Name = "labelProgress";
            this.labelProgress.Size = new System.Drawing.Size(20, 16);
            this.labelProgress.TabIndex = 62;
            this.labelProgress.Text = "%";
            this.labelProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelProgress.Visible = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // сдвигДатыРасчётаToolStripMenuItem
            // 
            this.сдвигДатыРасчётаToolStripMenuItem.Name = "сдвигДатыРасчётаToolStripMenuItem";
            this.сдвигДатыРасчётаToolStripMenuItem.Size = new System.Drawing.Size(221, 26);
            this.сдвигДатыРасчётаToolStripMenuItem.Text = "Сдвиг даты расчёта";
            this.сдвигДатыРасчётаToolStripMenuItem.Click += new System.EventHandler(this.сдвигДатыРасчётаToolStripMenuItem_Click);
            // 
            // KUGraphForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(238)))), ((int)(((byte)(168)))));
            this.ClientSize = new System.Drawing.Size(1132, 612);
            this.Controls.Add(this.labelProgress);
            this.Controls.Add(this.progressBarForAsincBonus);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelTo);
            this.Controls.Add(this.labelFrom);
            this.Controls.Add(this.dateTimePickerFrom);
            this.Controls.Add(this.dateTimePickerTo);
            this.Controls.Add(this.buttonCalcAll);
            this.Controls.Add(this.buttonCalcBonus);
            this.Controls.Add(this.buttonApprove);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(884, 510);
            this.Name = "KUGraphForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "График КУ";
            this.Activated += new System.EventHandler(this.KUGraphForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.KUGraphForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKUGraph)).EndInit();
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
        private System.Windows.Forms.Button buttonApprove;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.Button buttonCalcBonus;
        private System.Windows.Forms.ToolStripMenuItem экспортToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вВордToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вЭксельToolStripMenuItem;
        private System.Windows.Forms.Button buttonCalcAll;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.Label labelFrom;
        private System.Windows.Forms.Label labelTo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridViewKUGraph;
        private System.Windows.Forms.ProgressBar progressBarForAsincBonus;
        private System.Windows.Forms.Label labelProgress;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripMenuItem word2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem excel2ToolStripMenuItem;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn Turnover;
        private System.Windows.Forms.DataGridViewTextBoxColumn Graph_Id;
        private System.Windows.Forms.ToolStripMenuItem сдвигДатыРасчётаToolStripMenuItem;
    }
}

