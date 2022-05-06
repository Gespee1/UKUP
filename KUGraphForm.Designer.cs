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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокКУToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поставщикиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сдвигДатыРасчётаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.buttonCancelCalc = new System.Windows.Forms.Button();
            this.dataGridViewKUGraph = new EDGV.ExtendedDataGridView();
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
            this.AsseptCancel = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKUGraph)).BeginInit();
            this.SuspendLayout();
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
            // 
            // сдвигДатыРасчётаToolStripMenuItem
            // 
            this.сдвигДатыРасчётаToolStripMenuItem.Name = "сдвигДатыРасчётаToolStripMenuItem";
            this.сдвигДатыРасчётаToolStripMenuItem.Size = new System.Drawing.Size(183, 26);
            this.сдвигДатыРасчётаToolStripMenuItem.Text = "Все настройки";
            this.сдвигДатыРасчётаToolStripMenuItem.Click += new System.EventHandler(this.сдвигДатыРасчётаToolStripMenuItem_Click);
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
            this.buttonApprove.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonApprove.Location = new System.Drawing.Point(856, 545);
            this.buttonApprove.Name = "buttonApprove";
            this.buttonApprove.Size = new System.Drawing.Size(183, 24);
            this.buttonApprove.TabIndex = 2;
            this.buttonApprove.Text = "Утвердить";
            this.buttonApprove.UseVisualStyleBackColor = true;
            this.buttonApprove.Click += new System.EventHandler(this.button3_Click);
            // 
            // buttonCalcBonus
            // 
            this.buttonCalcBonus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCalcBonus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCalcBonus.Location = new System.Drawing.Point(669, 545);
            this.buttonCalcBonus.Name = "buttonCalcBonus";
            this.buttonCalcBonus.Size = new System.Drawing.Size(162, 24);
            this.buttonCalcBonus.TabIndex = 1;
            this.buttonCalcBonus.Text = "Расчёт премии";
            this.buttonCalcBonus.UseVisualStyleBackColor = true;
            this.buttonCalcBonus.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonCalcAll
            // 
            this.buttonCalcAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCalcAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCalcAll.Location = new System.Drawing.Point(30, 545);
            this.buttonCalcAll.Name = "buttonCalcAll";
            this.buttonCalcAll.Size = new System.Drawing.Size(196, 24);
            this.buttonCalcAll.TabIndex = 6;
            this.buttonCalcAll.Text = "Рассчитать всё за период";
            this.buttonCalcAll.UseVisualStyleBackColor = true;
            this.buttonCalcAll.Click += new System.EventHandler(this.button2_Click);
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dateTimePickerTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePickerTo.Location = new System.Drawing.Point(273, 575);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(183, 24);
            this.dateTimePickerTo.TabIndex = 5;
            this.dateTimePickerTo.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dateTimePickerFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePickerFrom.Location = new System.Drawing.Point(273, 545);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(183, 24);
            this.dateTimePickerFrom.TabIndex = 4;
            this.dateTimePickerFrom.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // labelFrom
            // 
            this.labelFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelFrom.AutoSize = true;
            this.labelFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFrom.Location = new System.Drawing.Point(247, 545);
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
            this.labelTo.Location = new System.Drawing.Point(237, 575);
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
            // buttonCancelCalc
            // 
            this.buttonCancelCalc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancelCalc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCancelCalc.Location = new System.Drawing.Point(669, 575);
            this.buttonCancelCalc.Name = "buttonCancelCalc";
            this.buttonCancelCalc.Size = new System.Drawing.Size(162, 24);
            this.buttonCancelCalc.TabIndex = 3;
            this.buttonCancelCalc.Text = "Отменить расчёт";
            this.buttonCancelCalc.UseVisualStyleBackColor = true;
            this.buttonCancelCalc.Click += new System.EventHandler(this.buttonCancelCalc_Click);
            // 
            // dataGridViewKUGraph
            // 
            this.dataGridViewKUGraph.AllowUserToAddRows = false;
            this.dataGridViewKUGraph.AllowUserToDeleteRows = false;
            this.dataGridViewKUGraph.AllowUserToResizeRows = false;
            this.dataGridViewKUGraph.AutoGenerateContextFilters = true;
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
            this.dataGridViewKUGraph.DateWithTime = false;
            this.dataGridViewKUGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewKUGraph.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewKUGraph.Name = "dataGridViewKUGraph";
            this.dataGridViewKUGraph.RowHeadersVisible = false;
            dataGridViewCellStyle8.NullValue = null;
            this.dataGridViewKUGraph.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewKUGraph.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewKUGraph.Size = new System.Drawing.Size(1108, 476);
            this.dataGridViewKUGraph.TabIndex = 0;
            this.dataGridViewKUGraph.TabStop = false;
            this.dataGridViewKUGraph.TimeFilter = false;
            this.dataGridViewKUGraph.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            // 
            // KU_id
            // 
            this.KU_id.HeaderText = "Номер КУ";
            this.KU_id.MinimumWidth = 22;
            this.KU_id.Name = "KU_id";
            this.KU_id.ReadOnly = true;
            this.KU_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Vendor_id
            // 
            this.Vendor_id.HeaderText = "Номер поставщика";
            this.Vendor_id.MinimumWidth = 22;
            this.Vendor_id.Name = "Vendor_id";
            this.Vendor_id.ReadOnly = true;
            this.Vendor_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Vendor_id.ToolTipText = "Процент КУ";
            this.Vendor_id.Visible = false;
            // 
            // VendorAcc
            // 
            this.VendorAcc.HeaderText = "Счет поставщика";
            this.VendorAcc.MinimumWidth = 22;
            this.VendorAcc.Name = "VendorAcc";
            this.VendorAcc.ReadOnly = true;
            this.VendorAcc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // VendorNam
            // 
            this.VendorNam.HeaderText = "Имя";
            this.VendorNam.MinimumWidth = 22;
            this.VendorNam.Name = "VendorNam";
            this.VendorNam.ReadOnly = true;
            this.VendorNam.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // ContractCode
            // 
            this.ContractCode.HeaderText = "Код договора";
            this.ContractCode.MinimumWidth = 22;
            this.ContractCode.Name = "ContractCode";
            this.ContractCode.ReadOnly = true;
            this.ContractCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Percent
            // 
            this.Percent.HeaderText = "Процент";
            this.Percent.MinimumWidth = 22;
            this.Percent.Name = "Percent";
            this.Percent.ReadOnly = true;
            this.Percent.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Period
            // 
            this.Period.HeaderText = "Период";
            this.Period.MinimumWidth = 22;
            this.Period.Name = "Period";
            this.Period.ReadOnly = true;
            this.Period.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Date_from
            // 
            this.Date_from.HeaderText = "Дата С";
            this.Date_from.MinimumWidth = 22;
            this.Date_from.Name = "Date_from";
            this.Date_from.ReadOnly = true;
            this.Date_from.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Date_to
            // 
            this.Date_to.HeaderText = "Дата По";
            this.Date_to.MinimumWidth = 22;
            this.Date_to.Name = "Date_to";
            this.Date_to.ReadOnly = true;
            this.Date_to.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Date_calc
            // 
            this.Date_calc.HeaderText = "Дата расчета";
            this.Date_calc.MinimumWidth = 22;
            this.Date_calc.Name = "Date_calc";
            this.Date_calc.ReadOnly = true;
            this.Date_calc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // GraphStatus
            // 
            this.GraphStatus.HeaderText = "Статус";
            this.GraphStatus.MinimumWidth = 22;
            this.GraphStatus.Name = "GraphStatus";
            this.GraphStatus.ReadOnly = true;
            this.GraphStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.GraphStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // GraphSumP
            // 
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.GraphSumP.DefaultCellStyle = dataGridViewCellStyle5;
            this.GraphSumP.HeaderText = "Сумма премии";
            this.GraphSumP.MinimumWidth = 22;
            this.GraphSumP.Name = "GraphSumP";
            this.GraphSumP.ReadOnly = true;
            this.GraphSumP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // GraphSumS
            // 
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.GraphSumS.DefaultCellStyle = dataGridViewCellStyle6;
            this.GraphSumS.HeaderText = "Фактическая сумма премии";
            this.GraphSumS.MinimumWidth = 22;
            this.GraphSumS.Name = "GraphSumS";
            this.GraphSumS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // GraphSumN
            // 
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = null;
            this.GraphSumN.DefaultCellStyle = dataGridViewCellStyle7;
            this.GraphSumN.HeaderText = "Сумма по накладным";
            this.GraphSumN.MinimumWidth = 22;
            this.GraphSumN.Name = "GraphSumN";
            this.GraphSumN.ReadOnly = true;
            this.GraphSumN.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Turnover
            // 
            this.Turnover.HeaderText = "Товарооборот";
            this.Turnover.MinimumWidth = 22;
            this.Turnover.Name = "Turnover";
            this.Turnover.ReadOnly = true;
            this.Turnover.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Graph_Id
            // 
            this.Graph_Id.HeaderText = "Graph_Id";
            this.Graph_Id.MinimumWidth = 22;
            this.Graph_Id.Name = "Graph_Id";
            this.Graph_Id.ReadOnly = true;
            this.Graph_Id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // AsseptCancel
            // 
            this.AsseptCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AsseptCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AsseptCancel.Location = new System.Drawing.Point(856, 575);
            this.AsseptCancel.Name = "AsseptCancel";
            this.AsseptCancel.Size = new System.Drawing.Size(183, 24);
            this.AsseptCancel.TabIndex = 2;
            this.AsseptCancel.Text = "Отменить утверждение";
            this.AsseptCancel.UseVisualStyleBackColor = true;
            this.AsseptCancel.Click += new System.EventHandler(this.AsseptCancel_Click);
            // 
            // KUGraphForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(238)))), ((int)(((byte)(168)))));
            this.ClientSize = new System.Drawing.Size(1132, 634);
            this.Controls.Add(this.buttonCancelCalc);
            this.Controls.Add(this.labelProgress);
            this.Controls.Add(this.progressBarForAsincBonus);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelTo);
            this.Controls.Add(this.labelFrom);
            this.Controls.Add(this.dateTimePickerFrom);
            this.Controls.Add(this.dateTimePickerTo);
            this.Controls.Add(this.buttonCalcAll);
            this.Controls.Add(this.buttonCalcBonus);
            this.Controls.Add(this.AsseptCancel);
            this.Controls.Add(this.buttonApprove);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1084, 510);
            this.Name = "KUGraphForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "График КУ";
            this.Activated += new System.EventHandler(this.KUGraphForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.KUGraphForm_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKUGraph)).EndInit();
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
        private System.Windows.Forms.ProgressBar progressBarForAsincBonus;
        private System.Windows.Forms.Label labelProgress;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripMenuItem word2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem excel2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сдвигДатыРасчётаToolStripMenuItem;
        private System.Windows.Forms.Button buttonCancelCalc;
        private EDGV.ExtendedDataGridView dataGridViewKUGraph;
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
        private System.Windows.Forms.Button AsseptCancel;
    }
}

