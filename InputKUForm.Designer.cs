﻿
namespace РасчетКУ
{
    partial class InputKUForm
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
            this.labelMain = new System.Windows.Forms.Label();
            this.labelVendor = new System.Windows.Forms.Label();
            this.comboBoxVendor = new System.Windows.Forms.ComboBox();
            this.labelPeriod = new System.Windows.Forms.Label();
            this.comboBoxPeriod = new System.Windows.Forms.ComboBox();
            this.labelDateFrom = new System.Windows.Forms.Label();
            this.labelDateTo = new System.Windows.Forms.Label();
            this.dateTimePickerDateFrom = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerDateTo = new System.Windows.Forms.DateTimePicker();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокКУToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поставщикиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.графикКУToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelStatus = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonCreateNApprove = new System.Windows.Forms.Button();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.tabControlInEx = new System.Windows.Forms.TabControl();
            this.tabPageToInclude = new System.Windows.Forms.TabPage();
            this.dataGridViewIncluded = new System.Windows.Forms.DataGridView();
            this.In_prod_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KU_idP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Attribute1P = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Attribute2P = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProducerP = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.BrandP = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tabPageToExclude = new System.Windows.Forms.TabPage();
            this.dataGridViewExcluded = new System.Windows.Forms.DataGridView();
            this.Ex_prod_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KU_idM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Attribute1M = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Attribute2M = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProducerM = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.BrandM = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonAddCategory = new System.Windows.Forms.Button();
            this.buttonAddProduct = new System.Windows.Forms.Button();
            this.buttonAddAll = new System.Windows.Forms.Button();
            this.labelEntity = new System.Windows.Forms.Label();
            this.labelVendAccount = new System.Windows.Forms.Label();
            this.checkBoxReturn = new System.Windows.Forms.CheckBox();
            this.checkBoxTax = new System.Windows.Forms.CheckBox();
            this.checkBoxOfactured = new System.Windows.Forms.CheckBox();
            this.comboBoxKUType = new System.Windows.Forms.ComboBox();
            this.labelKUType = new System.Windows.Forms.Label();
            this.labelPayMethod = new System.Windows.Forms.Label();
            this.comboBoxPayMethod = new System.Windows.Forms.ComboBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.textBoxVendAccount = new System.Windows.Forms.TextBox();
            this.labelContract = new System.Windows.Forms.Label();
            this.textBoxContract = new System.Windows.Forms.TextBox();
            this.groupBoxDescription = new System.Windows.Forms.GroupBox();
            this.comboBoxProductType = new System.Windows.Forms.ComboBox();
            this.comboBoxEntity = new System.Windows.Forms.ComboBox();
            this.labelKUCode = new System.Windows.Forms.Label();
            this.textBoxKUCode = new System.Windows.Forms.TextBox();
            this.richTextBoxDescription = new System.Windows.Forms.RichTextBox();
            this.labelProductType = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBoxPeriod = new System.Windows.Forms.GroupBox();
            this.groupBoxSettings = new System.Windows.Forms.GroupBox();
            this.groupBoxDocument = new System.Windows.Forms.GroupBox();
            this.richTextBoxDocSubject = new System.Windows.Forms.RichTextBox();
            this.labelDocSubject = new System.Windows.Forms.Label();
            this.dateTimePickerDocDate = new System.Windows.Forms.DateTimePicker();
            this.labelDocDate = new System.Windows.Forms.Label();
            this.textBoxDocHeader = new System.Windows.Forms.TextBox();
            this.labelDocHeader = new System.Windows.Forms.Label();
            this.textBoxDocCode = new System.Windows.Forms.TextBox();
            this.labelDocCode = new System.Windows.Forms.Label();
            this.textBoxDocTitle = new System.Windows.Forms.TextBox();
            this.labelDocTitle = new System.Windows.Forms.Label();
            this.textBoxDocAccount = new System.Windows.Forms.TextBox();
            this.labelDocAccount = new System.Windows.Forms.Label();
            this.textBoxTransferTo = new System.Windows.Forms.TextBox();
            this.labelTransferTo = new System.Windows.Forms.Label();
            this.textBoxDocName = new System.Windows.Forms.TextBox();
            this.labelDocName = new System.Windows.Forms.Label();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageMain = new System.Windows.Forms.TabPage();
            this.tabPageBonus = new System.Windows.Forms.TabPage();
            this.menuStripTerms = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemAddTerm = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDelTerm = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewTerms = new System.Windows.Forms.DataGridView();
            this.FixSum = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Criterion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PercentSum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageServices = new System.Windows.Forms.TabPage();
            this.dataGridViewServices = new System.Windows.Forms.DataGridView();
            this.ServiceId = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.NameService = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Article = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.NameService2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Coeff = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStripServices = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItemAddService = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemDelService = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.buttonUnapprove = new System.Windows.Forms.Button();
            this.menuStripMain.SuspendLayout();
            this.tabControlInEx.SuspendLayout();
            this.tabPageToInclude.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIncluded)).BeginInit();
            this.tabPageToExclude.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExcluded)).BeginInit();
            this.groupBoxDescription.SuspendLayout();
            this.groupBoxPeriod.SuspendLayout();
            this.groupBoxSettings.SuspendLayout();
            this.groupBoxDocument.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabPageMain.SuspendLayout();
            this.tabPageBonus.SuspendLayout();
            this.menuStripTerms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTerms)).BeginInit();
            this.tabPageServices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewServices)).BeginInit();
            this.menuStripServices.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelMain
            // 
            this.labelMain.AutoSize = true;
            this.labelMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMain.Location = new System.Drawing.Point(497, 12);
            this.labelMain.Name = "labelMain";
            this.labelMain.Size = new System.Drawing.Size(324, 25);
            this.labelMain.TabIndex = 0;
            this.labelMain.Text = "Ввод коммерческих условий";
            // 
            // labelVendor
            // 
            this.labelVendor.AutoSize = true;
            this.labelVendor.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelVendor.Location = new System.Drawing.Point(6, 153);
            this.labelVendor.Name = "labelVendor";
            this.labelVendor.Size = new System.Drawing.Size(90, 18);
            this.labelVendor.TabIndex = 1;
            this.labelVendor.Text = "Поставщик:";
            // 
            // comboBoxVendor
            // 
            this.comboBoxVendor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxVendor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxVendor.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxVendor.FormattingEnabled = true;
            this.comboBoxVendor.Location = new System.Drawing.Point(6, 174);
            this.comboBoxVendor.Name = "comboBoxVendor";
            this.comboBoxVendor.Size = new System.Drawing.Size(180, 26);
            this.comboBoxVendor.TabIndex = 4;
            this.comboBoxVendor.SelectedIndexChanged += new System.EventHandler(this.comboBoxVendor_SelectedIndexChanged);
            this.comboBoxVendor.TextChanged += new System.EventHandler(this.control_TextChanged);
            // 
            // labelPeriod
            // 
            this.labelPeriod.AutoSize = true;
            this.labelPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPeriod.Location = new System.Drawing.Point(10, 28);
            this.labelPeriod.Name = "labelPeriod";
            this.labelPeriod.Size = new System.Drawing.Size(99, 18);
            this.labelPeriod.TabIndex = 5;
            this.labelPeriod.Text = "Тип периода:";
            // 
            // comboBoxPeriod
            // 
            this.comboBoxPeriod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxPeriod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxPeriod.FormattingEnabled = true;
            this.comboBoxPeriod.Items.AddRange(new object[] {
            "Неделя",
            "Месяц",
            "Квартал",
            "Год"});
            this.comboBoxPeriod.Location = new System.Drawing.Point(13, 49);
            this.comboBoxPeriod.Name = "comboBoxPeriod";
            this.comboBoxPeriod.Size = new System.Drawing.Size(180, 26);
            this.comboBoxPeriod.TabIndex = 22;
            this.comboBoxPeriod.TextChanged += new System.EventHandler(this.control_TextChanged);
            // 
            // labelDateFrom
            // 
            this.labelDateFrom.AutoSize = true;
            this.labelDateFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDateFrom.Location = new System.Drawing.Point(10, 89);
            this.labelDateFrom.Name = "labelDateFrom";
            this.labelDateFrom.Size = new System.Drawing.Size(100, 18);
            this.labelDateFrom.TabIndex = 8;
            this.labelDateFrom.Text = "Дата начала:";
            // 
            // labelDateTo
            // 
            this.labelDateTo.AutoSize = true;
            this.labelDateTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDateTo.Location = new System.Drawing.Point(10, 149);
            this.labelDateTo.Name = "labelDateTo";
            this.labelDateTo.Size = new System.Drawing.Size(125, 18);
            this.labelDateTo.TabIndex = 9;
            this.labelDateTo.Text = "Дата окончания:";
            // 
            // dateTimePickerDateFrom
            // 
            this.dateTimePickerDateFrom.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePickerDateFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePickerDateFrom.Location = new System.Drawing.Point(13, 110);
            this.dateTimePickerDateFrom.Name = "dateTimePickerDateFrom";
            this.dateTimePickerDateFrom.Size = new System.Drawing.Size(180, 24);
            this.dateTimePickerDateFrom.TabIndex = 23;
            this.dateTimePickerDateFrom.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dateTimePickerDateTo
            // 
            this.dateTimePickerDateTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePickerDateTo.Location = new System.Drawing.Point(13, 170);
            this.dateTimePickerDateTo.Name = "dateTimePickerDateTo";
            this.dateTimePickerDateTo.Size = new System.Drawing.Size(180, 24);
            this.dateTimePickerDateTo.TabIndex = 24;
            this.dateTimePickerDateTo.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // buttonCreate
            // 
            this.buttonCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCreate.Location = new System.Drawing.Point(1013, 12);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(87, 27);
            this.buttonCreate.TabIndex = 32;
            this.buttonCreate.Text = "Создать";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.create_button_Click);
            // 
            // menuStripMain
            // 
            this.menuStripMain.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(1294, 29);
            this.menuStripMain.TabIndex = 14;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.списокКУToolStripMenuItem,
            this.поставщикиToolStripMenuItem,
            this.графикКУToolStripMenuItem});
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(84, 25);
            this.открытьToolStripMenuItem.Text = "Открыть";
            // 
            // списокКУToolStripMenuItem
            // 
            this.списокКУToolStripMenuItem.Name = "списокКУToolStripMenuItem";
            this.списокКУToolStripMenuItem.Size = new System.Drawing.Size(177, 26);
            this.списокКУToolStripMenuItem.Text = "Список КУ";
            this.списокКУToolStripMenuItem.Click += new System.EventHandler(this.списокКУToolStripMenuItem_Click);
            // 
            // поставщикиToolStripMenuItem
            // 
            this.поставщикиToolStripMenuItem.Name = "поставщикиToolStripMenuItem";
            this.поставщикиToolStripMenuItem.Size = new System.Drawing.Size(177, 26);
            this.поставщикиToolStripMenuItem.Text = "Справочники";
            this.поставщикиToolStripMenuItem.Click += new System.EventHandler(this.поставщикиToolStripMenuItem_Click);
            // 
            // графикКУToolStripMenuItem
            // 
            this.графикКУToolStripMenuItem.Name = "графикКУToolStripMenuItem";
            this.графикКУToolStripMenuItem.Size = new System.Drawing.Size(177, 26);
            this.графикКУToolStripMenuItem.Text = "График КУ";
            this.графикКУToolStripMenuItem.Click += new System.EventHandler(this.графикКУToolStripMenuItem_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelStatus.Location = new System.Drawing.Point(203, 28);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(60, 18);
            this.labelStatus.TabIndex = 16;
            this.labelStatus.Text = "Статус:";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCancel.Location = new System.Drawing.Point(12, 12);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(87, 27);
            this.buttonCancel.TabIndex = 29;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Visible = false;
            this.buttonCancel.Click += new System.EventHandler(this.cancel_button_Click);
            // 
            // buttonCreateNApprove
            // 
            this.buttonCreateNApprove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCreateNApprove.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCreateNApprove.Location = new System.Drawing.Point(1108, 12);
            this.buttonCreateNApprove.Name = "buttonCreateNApprove";
            this.buttonCreateNApprove.Size = new System.Drawing.Size(174, 27);
            this.buttonCreateNApprove.TabIndex = 33;
            this.buttonCreateNApprove.Text = "Создать и утвердить";
            this.buttonCreateNApprove.UseVisualStyleBackColor = true;
            this.buttonCreateNApprove.Click += new System.EventHandler(this.createNapprove_button_Click);
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.Enabled = false;
            this.textBoxStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxStatus.Location = new System.Drawing.Point(203, 49);
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.Size = new System.Drawing.Size(180, 24);
            this.textBoxStatus.TabIndex = 2;
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonClose.Location = new System.Drawing.Point(920, 12);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(87, 27);
            this.buttonClose.TabIndex = 31;
            this.buttonClose.Text = "Закрыть";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Visible = false;
            this.buttonClose.Click += new System.EventHandler(this.close_button_Click);
            // 
            // tabControlInEx
            // 
            this.tabControlInEx.Controls.Add(this.tabPageToInclude);
            this.tabControlInEx.Controls.Add(this.tabPageToExclude);
            this.tabControlInEx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControlInEx.Location = new System.Drawing.Point(12, 3);
            this.tabControlInEx.Name = "tabControlInEx";
            this.tabControlInEx.SelectedIndex = 0;
            this.tabControlInEx.Size = new System.Drawing.Size(978, 218);
            this.tabControlInEx.TabIndex = 21;
            // 
            // tabPageToInclude
            // 
            this.tabPageToInclude.Controls.Add(this.dataGridViewIncluded);
            this.tabPageToInclude.Location = new System.Drawing.Point(4, 25);
            this.tabPageToInclude.Name = "tabPageToInclude";
            this.tabPageToInclude.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageToInclude.Size = new System.Drawing.Size(970, 189);
            this.tabPageToInclude.TabIndex = 0;
            this.tabPageToInclude.Text = "Добавить в расчёт";
            this.tabPageToInclude.UseVisualStyleBackColor = true;
            // 
            // dataGridViewIncluded
            // 
            this.dataGridViewIncluded.AllowUserToAddRows = false;
            this.dataGridViewIncluded.AllowUserToDeleteRows = false;
            this.dataGridViewIncluded.AllowUserToResizeRows = false;
            this.dataGridViewIncluded.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewIncluded.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewIncluded.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.In_prod_id,
            this.KU_idP,
            this.TypeP,
            this.Attribute1P,
            this.Attribute2P,
            this.ProducerP,
            this.BrandP});
            this.dataGridViewIncluded.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewIncluded.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewIncluded.MultiSelect = false;
            this.dataGridViewIncluded.Name = "dataGridViewIncluded";
            this.dataGridViewIncluded.RowHeadersVisible = false;
            this.dataGridViewIncluded.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewIncluded.Size = new System.Drawing.Size(964, 183);
            this.dataGridViewIncluded.TabIndex = 0;
            this.dataGridViewIncluded.TabStop = false;
            this.dataGridViewIncluded.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewInEx_CellEndEdit);
            this.dataGridViewIncluded.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellValueChanged);
            this.dataGridViewIncluded.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView_RowsAdded);
            this.dataGridViewIncluded.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGridView_RowsRemoved);
            // 
            // In_prod_id
            // 
            this.In_prod_id.HeaderText = "In_prod_id";
            this.In_prod_id.Name = "In_prod_id";
            this.In_prod_id.ReadOnly = true;
            this.In_prod_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.In_prod_id.Visible = false;
            // 
            // KU_idP
            // 
            this.KU_idP.HeaderText = "KU_id";
            this.KU_idP.Name = "KU_idP";
            this.KU_idP.ReadOnly = true;
            this.KU_idP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.KU_idP.Visible = false;
            // 
            // TypeP
            // 
            this.TypeP.HeaderText = "Тип";
            this.TypeP.Name = "TypeP";
            this.TypeP.ReadOnly = true;
            this.TypeP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Attribute1P
            // 
            this.Attribute1P.HeaderText = "Атрибут 1";
            this.Attribute1P.Name = "Attribute1P";
            this.Attribute1P.ReadOnly = true;
            this.Attribute1P.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Attribute2P
            // 
            this.Attribute2P.HeaderText = "Атрибут 2";
            this.Attribute2P.Name = "Attribute2P";
            this.Attribute2P.ReadOnly = true;
            this.Attribute2P.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ProducerP
            // 
            this.ProducerP.HeaderText = "Производитель";
            this.ProducerP.Name = "ProducerP";
            this.ProducerP.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // BrandP
            // 
            this.BrandP.HeaderText = "Торговая марка";
            this.BrandP.Name = "BrandP";
            this.BrandP.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // tabPageToExclude
            // 
            this.tabPageToExclude.Controls.Add(this.dataGridViewExcluded);
            this.tabPageToExclude.Location = new System.Drawing.Point(4, 25);
            this.tabPageToExclude.Name = "tabPageToExclude";
            this.tabPageToExclude.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageToExclude.Size = new System.Drawing.Size(970, 189);
            this.tabPageToExclude.TabIndex = 1;
            this.tabPageToExclude.Text = "Исключить из расчёта";
            this.tabPageToExclude.UseVisualStyleBackColor = true;
            // 
            // dataGridViewExcluded
            // 
            this.dataGridViewExcluded.AllowUserToAddRows = false;
            this.dataGridViewExcluded.AllowUserToDeleteRows = false;
            this.dataGridViewExcluded.AllowUserToResizeRows = false;
            this.dataGridViewExcluded.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewExcluded.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewExcluded.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ex_prod_id,
            this.KU_idM,
            this.TypeM,
            this.Attribute1M,
            this.Attribute2M,
            this.ProducerM,
            this.BrandM});
            this.dataGridViewExcluded.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewExcluded.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewExcluded.MultiSelect = false;
            this.dataGridViewExcluded.Name = "dataGridViewExcluded";
            this.dataGridViewExcluded.RowHeadersVisible = false;
            this.dataGridViewExcluded.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewExcluded.Size = new System.Drawing.Size(964, 183);
            this.dataGridViewExcluded.TabIndex = 0;
            this.dataGridViewExcluded.TabStop = false;
            this.dataGridViewExcluded.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewInEx_CellEndEdit);
            this.dataGridViewExcluded.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellValueChanged);
            this.dataGridViewExcluded.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView_RowsAdded);
            this.dataGridViewExcluded.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGridView_RowsRemoved);
            // 
            // Ex_prod_id
            // 
            this.Ex_prod_id.HeaderText = "Ex_prod_id";
            this.Ex_prod_id.Name = "Ex_prod_id";
            this.Ex_prod_id.ReadOnly = true;
            this.Ex_prod_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Ex_prod_id.Visible = false;
            // 
            // KU_idM
            // 
            this.KU_idM.HeaderText = "KU_idM";
            this.KU_idM.Name = "KU_idM";
            this.KU_idM.ReadOnly = true;
            this.KU_idM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.KU_idM.Visible = false;
            // 
            // TypeM
            // 
            this.TypeM.HeaderText = "Тип";
            this.TypeM.Name = "TypeM";
            this.TypeM.ReadOnly = true;
            this.TypeM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Attribute1M
            // 
            this.Attribute1M.HeaderText = "Атрибут 1";
            this.Attribute1M.Name = "Attribute1M";
            this.Attribute1M.ReadOnly = true;
            this.Attribute1M.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Attribute2M
            // 
            this.Attribute2M.HeaderText = "Атрибут 2";
            this.Attribute2M.Name = "Attribute2M";
            this.Attribute2M.ReadOnly = true;
            this.Attribute2M.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ProducerM
            // 
            this.ProducerM.HeaderText = "Производитель";
            this.ProducerM.Name = "ProducerM";
            this.ProducerM.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // BrandM
            // 
            this.BrandM.HeaderText = "Торговая марка";
            this.BrandM.Name = "BrandM";
            this.BrandM.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDelete.Location = new System.Drawing.Point(996, 127);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(178, 27);
            this.buttonDelete.TabIndex = 28;
            this.buttonDelete.Text = "Удалить";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.button7_Click);
            // 
            // buttonAddCategory
            // 
            this.buttonAddCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddCategory.Location = new System.Drawing.Point(996, 61);
            this.buttonAddCategory.Name = "buttonAddCategory";
            this.buttonAddCategory.Size = new System.Drawing.Size(178, 27);
            this.buttonAddCategory.TabIndex = 26;
            this.buttonAddCategory.Text = "Добавить категорию";
            this.buttonAddCategory.UseVisualStyleBackColor = true;
            this.buttonAddCategory.Click += new System.EventHandler(this.btnSelectCategory_Click);
            // 
            // buttonAddProduct
            // 
            this.buttonAddProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddProduct.Location = new System.Drawing.Point(996, 94);
            this.buttonAddProduct.Name = "buttonAddProduct";
            this.buttonAddProduct.Size = new System.Drawing.Size(178, 27);
            this.buttonAddProduct.TabIndex = 27;
            this.buttonAddProduct.Text = "Добавить товар";
            this.buttonAddProduct.UseVisualStyleBackColor = true;
            this.buttonAddProduct.Click += new System.EventHandler(this.button5_Click);
            // 
            // buttonAddAll
            // 
            this.buttonAddAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddAll.Location = new System.Drawing.Point(996, 28);
            this.buttonAddAll.Name = "buttonAddAll";
            this.buttonAddAll.Size = new System.Drawing.Size(178, 27);
            this.buttonAddAll.TabIndex = 25;
            this.buttonAddAll.Text = "Добавить все";
            this.buttonAddAll.UseVisualStyleBackColor = true;
            this.buttonAddAll.Click += new System.EventHandler(this.button4_Click);
            // 
            // labelEntity
            // 
            this.labelEntity.AutoSize = true;
            this.labelEntity.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelEntity.Location = new System.Drawing.Point(6, 258);
            this.labelEntity.Name = "labelEntity";
            this.labelEntity.Size = new System.Drawing.Size(77, 18);
            this.labelEntity.TabIndex = 27;
            this.labelEntity.Text = "Юр. лицо:";
            // 
            // labelVendAccount
            // 
            this.labelVendAccount.AutoSize = true;
            this.labelVendAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelVendAccount.Location = new System.Drawing.Point(6, 202);
            this.labelVendAccount.Name = "labelVendAccount";
            this.labelVendAccount.Size = new System.Drawing.Size(133, 18);
            this.labelVendAccount.TabIndex = 28;
            this.labelVendAccount.Text = "Счет поставщика:";
            // 
            // checkBoxReturn
            // 
            this.checkBoxReturn.AutoSize = true;
            this.checkBoxReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.checkBoxReturn.Location = new System.Drawing.Point(13, 51);
            this.checkBoxReturn.Name = "checkBoxReturn";
            this.checkBoxReturn.Size = new System.Drawing.Size(165, 22);
            this.checkBoxReturn.TabIndex = 18;
            this.checkBoxReturn.Text = "Исключить возврат";
            this.checkBoxReturn.UseVisualStyleBackColor = true;
            this.checkBoxReturn.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBoxTax
            // 
            this.checkBoxTax.AutoSize = true;
            this.checkBoxTax.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxTax.Location = new System.Drawing.Point(13, 28);
            this.checkBoxTax.Name = "checkBoxTax";
            this.checkBoxTax.Size = new System.Drawing.Size(146, 22);
            this.checkBoxTax.TabIndex = 17;
            this.checkBoxTax.Text = "Учитывать налог";
            this.checkBoxTax.UseVisualStyleBackColor = true;
            this.checkBoxTax.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBoxOfactured
            // 
            this.checkBoxOfactured.AutoSize = true;
            this.checkBoxOfactured.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.checkBoxOfactured.Location = new System.Drawing.Point(13, 74);
            this.checkBoxOfactured.Name = "checkBoxOfactured";
            this.checkBoxOfactured.Size = new System.Drawing.Size(186, 22);
            this.checkBoxOfactured.TabIndex = 19;
            this.checkBoxOfactured.Text = "Только офактуренные";
            this.checkBoxOfactured.UseVisualStyleBackColor = true;
            this.checkBoxOfactured.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // comboBoxKUType
            // 
            this.comboBoxKUType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxKUType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxKUType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxKUType.FormattingEnabled = true;
            this.comboBoxKUType.Items.AddRange(new object[] {
            "Ретро-бонус",
            "Маркетинговая услуга"});
            this.comboBoxKUType.Location = new System.Drawing.Point(13, 177);
            this.comboBoxKUType.Name = "comboBoxKUType";
            this.comboBoxKUType.Size = new System.Drawing.Size(180, 26);
            this.comboBoxKUType.TabIndex = 21;
            this.comboBoxKUType.SelectedIndexChanged += new System.EventHandler(this.comboBoxKUType_SelectedIndexChanged);
            this.comboBoxKUType.TextChanged += new System.EventHandler(this.control_TextChanged);
            // 
            // labelKUType
            // 
            this.labelKUType.AutoSize = true;
            this.labelKUType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelKUType.Location = new System.Drawing.Point(10, 156);
            this.labelKUType.Name = "labelKUType";
            this.labelKUType.Size = new System.Drawing.Size(61, 18);
            this.labelKUType.TabIndex = 34;
            this.labelKUType.Text = "Тип КУ:";
            // 
            // labelPayMethod
            // 
            this.labelPayMethod.AutoSize = true;
            this.labelPayMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPayMethod.Location = new System.Drawing.Point(10, 99);
            this.labelPayMethod.Name = "labelPayMethod";
            this.labelPayMethod.Size = new System.Drawing.Size(122, 18);
            this.labelPayMethod.TabIndex = 36;
            this.labelPayMethod.Text = "Способ оплаты:";
            // 
            // comboBoxPayMethod
            // 
            this.comboBoxPayMethod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxPayMethod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxPayMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxPayMethod.FormattingEnabled = true;
            this.comboBoxPayMethod.Items.AddRange(new object[] {
            "Платеж",
            "Взаимозачет"});
            this.comboBoxPayMethod.Location = new System.Drawing.Point(13, 120);
            this.comboBoxPayMethod.Name = "comboBoxPayMethod";
            this.comboBoxPayMethod.Size = new System.Drawing.Size(180, 26);
            this.comboBoxPayMethod.TabIndex = 20;
            this.comboBoxPayMethod.TextChanged += new System.EventHandler(this.control_TextChanged);
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDescription.Location = new System.Drawing.Point(6, 76);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(80, 18);
            this.labelDescription.TabIndex = 37;
            this.labelDescription.Text = "Описание:";
            // 
            // textBoxVendAccount
            // 
            this.textBoxVendAccount.Enabled = false;
            this.textBoxVendAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxVendAccount.Location = new System.Drawing.Point(6, 225);
            this.textBoxVendAccount.Name = "textBoxVendAccount";
            this.textBoxVendAccount.Size = new System.Drawing.Size(180, 24);
            this.textBoxVendAccount.TabIndex = 6;
            // 
            // labelContract
            // 
            this.labelContract.AutoSize = true;
            this.labelContract.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelContract.Location = new System.Drawing.Point(205, 156);
            this.labelContract.Name = "labelContract";
            this.labelContract.Size = new System.Drawing.Size(77, 18);
            this.labelContract.TabIndex = 40;
            this.labelContract.Text = "Контракт:";
            // 
            // textBoxContract
            // 
            this.textBoxContract.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxContract.Location = new System.Drawing.Point(203, 177);
            this.textBoxContract.Name = "textBoxContract";
            this.textBoxContract.Size = new System.Drawing.Size(180, 24);
            this.textBoxContract.TabIndex = 5;
            this.textBoxContract.TextChanged += new System.EventHandler(this.control_TextChanged);
            // 
            // groupBoxDescription
            // 
            this.groupBoxDescription.Controls.Add(this.comboBoxProductType);
            this.groupBoxDescription.Controls.Add(this.comboBoxEntity);
            this.groupBoxDescription.Controls.Add(this.labelKUCode);
            this.groupBoxDescription.Controls.Add(this.textBoxKUCode);
            this.groupBoxDescription.Controls.Add(this.richTextBoxDescription);
            this.groupBoxDescription.Controls.Add(this.textBoxStatus);
            this.groupBoxDescription.Controls.Add(this.labelStatus);
            this.groupBoxDescription.Controls.Add(this.labelProductType);
            this.groupBoxDescription.Controls.Add(this.labelDescription);
            this.groupBoxDescription.Controls.Add(this.textBoxContract);
            this.groupBoxDescription.Controls.Add(this.labelContract);
            this.groupBoxDescription.Controls.Add(this.labelVendor);
            this.groupBoxDescription.Controls.Add(this.textBoxVendAccount);
            this.groupBoxDescription.Controls.Add(this.comboBoxVendor);
            this.groupBoxDescription.Controls.Add(this.labelEntity);
            this.groupBoxDescription.Controls.Add(this.labelVendAccount);
            this.groupBoxDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxDescription.Location = new System.Drawing.Point(6, 6);
            this.groupBoxDescription.Name = "groupBoxDescription";
            this.groupBoxDescription.Size = new System.Drawing.Size(401, 293);
            this.groupBoxDescription.TabIndex = 43;
            this.groupBoxDescription.TabStop = false;
            this.groupBoxDescription.Text = "Описание";
            // 
            // comboBoxProductType
            // 
            this.comboBoxProductType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxProductType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxProductType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxProductType.FormattingEnabled = true;
            this.comboBoxProductType.Items.AddRange(new object[] {
            "Продовльственные",
            "Непродовольственные"});
            this.comboBoxProductType.Location = new System.Drawing.Point(203, 223);
            this.comboBoxProductType.Name = "comboBoxProductType";
            this.comboBoxProductType.Size = new System.Drawing.Size(180, 26);
            this.comboBoxProductType.TabIndex = 7;
            // 
            // comboBoxEntity
            // 
            this.comboBoxEntity.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxEntity.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxEntity.Enabled = false;
            this.comboBoxEntity.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxEntity.FormattingEnabled = true;
            this.comboBoxEntity.Location = new System.Drawing.Point(83, 255);
            this.comboBoxEntity.Name = "comboBoxEntity";
            this.comboBoxEntity.Size = new System.Drawing.Size(300, 26);
            this.comboBoxEntity.TabIndex = 8;
            this.comboBoxEntity.TextChanged += new System.EventHandler(this.EntityChanged);
            // 
            // labelKUCode
            // 
            this.labelKUCode.AutoSize = true;
            this.labelKUCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelKUCode.Location = new System.Drawing.Point(6, 28);
            this.labelKUCode.Name = "labelKUCode";
            this.labelKUCode.Size = new System.Drawing.Size(64, 18);
            this.labelKUCode.TabIndex = 49;
            this.labelKUCode.Text = "Код КУ:";
            // 
            // textBoxKUCode
            // 
            this.textBoxKUCode.Enabled = false;
            this.textBoxKUCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxKUCode.Location = new System.Drawing.Point(6, 49);
            this.textBoxKUCode.Name = "textBoxKUCode";
            this.textBoxKUCode.Size = new System.Drawing.Size(180, 24);
            this.textBoxKUCode.TabIndex = 1;
            // 
            // richTextBoxDescription
            // 
            this.richTextBoxDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBoxDescription.Location = new System.Drawing.Point(6, 97);
            this.richTextBoxDescription.Name = "richTextBoxDescription";
            this.richTextBoxDescription.Size = new System.Drawing.Size(377, 56);
            this.richTextBoxDescription.TabIndex = 3;
            this.richTextBoxDescription.Text = "";
            this.richTextBoxDescription.TextChanged += new System.EventHandler(this.control_TextChanged);
            // 
            // labelProductType
            // 
            this.labelProductType.AutoSize = true;
            this.labelProductType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelProductType.Location = new System.Drawing.Point(205, 204);
            this.labelProductType.Name = "labelProductType";
            this.labelProductType.Size = new System.Drawing.Size(98, 18);
            this.labelProductType.TabIndex = 43;
            this.labelProductType.Text = "Тип товаров:";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // groupBoxPeriod
            // 
            this.groupBoxPeriod.Controls.Add(this.dateTimePickerDateTo);
            this.groupBoxPeriod.Controls.Add(this.dateTimePickerDateFrom);
            this.groupBoxPeriod.Controls.Add(this.labelDateTo);
            this.groupBoxPeriod.Controls.Add(this.labelDateFrom);
            this.groupBoxPeriod.Controls.Add(this.comboBoxPeriod);
            this.groupBoxPeriod.Controls.Add(this.labelPeriod);
            this.groupBoxPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxPeriod.Location = new System.Drawing.Point(1053, 6);
            this.groupBoxPeriod.Name = "groupBoxPeriod";
            this.groupBoxPeriod.Size = new System.Drawing.Size(203, 218);
            this.groupBoxPeriod.TabIndex = 44;
            this.groupBoxPeriod.TabStop = false;
            this.groupBoxPeriod.Text = "Период действия";
            // 
            // groupBoxSettings
            // 
            this.groupBoxSettings.Controls.Add(this.labelPayMethod);
            this.groupBoxSettings.Controls.Add(this.comboBoxPayMethod);
            this.groupBoxSettings.Controls.Add(this.labelKUType);
            this.groupBoxSettings.Controls.Add(this.comboBoxKUType);
            this.groupBoxSettings.Controls.Add(this.checkBoxOfactured);
            this.groupBoxSettings.Controls.Add(this.checkBoxTax);
            this.groupBoxSettings.Controls.Add(this.checkBoxReturn);
            this.groupBoxSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxSettings.Location = new System.Drawing.Point(830, 6);
            this.groupBoxSettings.Name = "groupBoxSettings";
            this.groupBoxSettings.Size = new System.Drawing.Size(217, 218);
            this.groupBoxSettings.TabIndex = 45;
            this.groupBoxSettings.TabStop = false;
            this.groupBoxSettings.Text = "Настройки";
            // 
            // groupBoxDocument
            // 
            this.groupBoxDocument.Controls.Add(this.richTextBoxDocSubject);
            this.groupBoxDocument.Controls.Add(this.labelDocSubject);
            this.groupBoxDocument.Controls.Add(this.dateTimePickerDocDate);
            this.groupBoxDocument.Controls.Add(this.labelDocDate);
            this.groupBoxDocument.Controls.Add(this.textBoxDocHeader);
            this.groupBoxDocument.Controls.Add(this.labelDocHeader);
            this.groupBoxDocument.Controls.Add(this.textBoxDocCode);
            this.groupBoxDocument.Controls.Add(this.labelDocCode);
            this.groupBoxDocument.Controls.Add(this.textBoxDocTitle);
            this.groupBoxDocument.Controls.Add(this.labelDocTitle);
            this.groupBoxDocument.Controls.Add(this.textBoxDocAccount);
            this.groupBoxDocument.Controls.Add(this.labelDocAccount);
            this.groupBoxDocument.Controls.Add(this.textBoxTransferTo);
            this.groupBoxDocument.Controls.Add(this.labelTransferTo);
            this.groupBoxDocument.Controls.Add(this.textBoxDocName);
            this.groupBoxDocument.Controls.Add(this.labelDocName);
            this.groupBoxDocument.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxDocument.Location = new System.Drawing.Point(413, 6);
            this.groupBoxDocument.Name = "groupBoxDocument";
            this.groupBoxDocument.Size = new System.Drawing.Size(411, 293);
            this.groupBoxDocument.TabIndex = 46;
            this.groupBoxDocument.TabStop = false;
            this.groupBoxDocument.Text = "Договор";
            // 
            // richTextBoxDocSubject
            // 
            this.richTextBoxDocSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBoxDocSubject.Location = new System.Drawing.Point(217, 157);
            this.richTextBoxDocSubject.Name = "richTextBoxDocSubject";
            this.richTextBoxDocSubject.Size = new System.Drawing.Size(180, 74);
            this.richTextBoxDocSubject.TabIndex = 16;
            this.richTextBoxDocSubject.Text = "";
            this.richTextBoxDocSubject.TextChanged += new System.EventHandler(this.control_TextChanged);
            // 
            // labelDocSubject
            // 
            this.labelDocSubject.AutoSize = true;
            this.labelDocSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDocSubject.Location = new System.Drawing.Point(214, 136);
            this.labelDocSubject.Name = "labelDocSubject";
            this.labelDocSubject.Size = new System.Drawing.Size(144, 18);
            this.labelDocSubject.TabIndex = 57;
            this.labelDocSubject.Text = "Предмет договора:";
            // 
            // dateTimePickerDocDate
            // 
            this.dateTimePickerDocDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePickerDocDate.Location = new System.Drawing.Point(217, 100);
            this.dateTimePickerDocDate.Name = "dateTimePickerDocDate";
            this.dateTimePickerDocDate.Size = new System.Drawing.Size(180, 24);
            this.dateTimePickerDocDate.TabIndex = 12;
            this.dateTimePickerDocDate.ValueChanged += new System.EventHandler(this.dateTimePicker3_ValueChanged);
            // 
            // labelDocDate
            // 
            this.labelDocDate.AutoSize = true;
            this.labelDocDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDocDate.Location = new System.Drawing.Point(214, 82);
            this.labelDocDate.Name = "labelDocDate";
            this.labelDocDate.Size = new System.Drawing.Size(47, 18);
            this.labelDocDate.TabIndex = 54;
            this.labelDocDate.Text = "Дата:";
            // 
            // textBoxDocHeader
            // 
            this.textBoxDocHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxDocHeader.Location = new System.Drawing.Point(217, 49);
            this.textBoxDocHeader.Name = "textBoxDocHeader";
            this.textBoxDocHeader.Size = new System.Drawing.Size(180, 24);
            this.textBoxDocHeader.TabIndex = 10;
            this.textBoxDocHeader.TextChanged += new System.EventHandler(this.control_TextChanged);
            // 
            // labelDocHeader
            // 
            this.labelDocHeader.AutoSize = true;
            this.labelDocHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDocHeader.Location = new System.Drawing.Point(214, 28);
            this.labelDocHeader.Name = "labelDocHeader";
            this.labelDocHeader.Size = new System.Drawing.Size(167, 18);
            this.labelDocHeader.TabIndex = 52;
            this.labelDocHeader.Text = "Заголовок документа:";
            // 
            // textBoxDocCode
            // 
            this.textBoxDocCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxDocCode.Location = new System.Drawing.Point(20, 255);
            this.textBoxDocCode.Name = "textBoxDocCode";
            this.textBoxDocCode.Size = new System.Drawing.Size(180, 24);
            this.textBoxDocCode.TabIndex = 15;
            this.textBoxDocCode.TextChanged += new System.EventHandler(this.control_TextChanged);
            // 
            // labelDocCode
            // 
            this.labelDocCode.AutoSize = true;
            this.labelDocCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDocCode.Location = new System.Drawing.Point(17, 234);
            this.labelDocCode.Name = "labelDocCode";
            this.labelDocCode.Size = new System.Drawing.Size(110, 18);
            this.labelDocCode.TabIndex = 50;
            this.labelDocCode.Text = "Код договора:";
            // 
            // textBoxDocTitle
            // 
            this.textBoxDocTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxDocTitle.Location = new System.Drawing.Point(20, 207);
            this.textBoxDocTitle.Name = "textBoxDocTitle";
            this.textBoxDocTitle.Size = new System.Drawing.Size(180, 24);
            this.textBoxDocTitle.TabIndex = 14;
            this.textBoxDocTitle.TextChanged += new System.EventHandler(this.control_TextChanged);
            // 
            // labelDocTitle
            // 
            this.labelDocTitle.AutoSize = true;
            this.labelDocTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDocTitle.Location = new System.Drawing.Point(17, 186);
            this.labelDocTitle.Name = "labelDocTitle";
            this.labelDocTitle.Size = new System.Drawing.Size(79, 18);
            this.labelDocTitle.TabIndex = 48;
            this.labelDocTitle.Text = "Название:";
            // 
            // textBoxDocAccount
            // 
            this.textBoxDocAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxDocAccount.Location = new System.Drawing.Point(20, 156);
            this.textBoxDocAccount.Name = "textBoxDocAccount";
            this.textBoxDocAccount.Size = new System.Drawing.Size(180, 24);
            this.textBoxDocAccount.TabIndex = 13;
            this.textBoxDocAccount.TextChanged += new System.EventHandler(this.control_TextChanged);
            // 
            // labelDocAccount
            // 
            this.labelDocAccount.AutoSize = true;
            this.labelDocAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDocAccount.Location = new System.Drawing.Point(17, 134);
            this.labelDocAccount.Name = "labelDocAccount";
            this.labelDocAccount.Size = new System.Drawing.Size(102, 18);
            this.labelDocAccount.TabIndex = 46;
            this.labelDocAccount.Text = "Номер счета:";
            // 
            // textBoxTransferTo
            // 
            this.textBoxTransferTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxTransferTo.Location = new System.Drawing.Point(20, 103);
            this.textBoxTransferTo.Name = "textBoxTransferTo";
            this.textBoxTransferTo.Size = new System.Drawing.Size(180, 24);
            this.textBoxTransferTo.TabIndex = 11;
            this.textBoxTransferTo.TextChanged += new System.EventHandler(this.control_TextChanged);
            // 
            // labelTransferTo
            // 
            this.labelTransferTo.AutoSize = true;
            this.labelTransferTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTransferTo.Location = new System.Drawing.Point(17, 81);
            this.labelTransferTo.Name = "labelTransferTo";
            this.labelTransferTo.Size = new System.Drawing.Size(163, 18);
            this.labelTransferTo.TabIndex = 44;
            this.labelTransferTo.Text = "Начислять бонусы на:";
            // 
            // textBoxDocName
            // 
            this.textBoxDocName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxDocName.Location = new System.Drawing.Point(20, 49);
            this.textBoxDocName.Name = "textBoxDocName";
            this.textBoxDocName.Size = new System.Drawing.Size(180, 24);
            this.textBoxDocName.TabIndex = 9;
            this.textBoxDocName.TextChanged += new System.EventHandler(this.control_TextChanged);
            // 
            // labelDocName
            // 
            this.labelDocName.AutoSize = true;
            this.labelDocName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDocName.Location = new System.Drawing.Point(17, 28);
            this.labelDocName.Name = "labelDocName";
            this.labelDocName.Size = new System.Drawing.Size(42, 18);
            this.labelDocName.TabIndex = 42;
            this.labelDocName.Text = "Имя:";
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageMain);
            this.tabControlMain.Controls.Add(this.tabPageBonus);
            this.tabControlMain.Controls.Add(this.tabPageServices);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControlMain.Location = new System.Drawing.Point(12, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1270, 344);
            this.tabControlMain.TabIndex = 47;
            // 
            // tabPageMain
            // 
            this.tabPageMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(250)))), ((int)(((byte)(200)))));
            this.tabPageMain.Controls.Add(this.groupBoxDescription);
            this.tabPageMain.Controls.Add(this.groupBoxSettings);
            this.tabPageMain.Controls.Add(this.groupBoxDocument);
            this.tabPageMain.Controls.Add(this.groupBoxPeriod);
            this.tabPageMain.Location = new System.Drawing.Point(4, 25);
            this.tabPageMain.Name = "tabPageMain";
            this.tabPageMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMain.Size = new System.Drawing.Size(1262, 315);
            this.tabPageMain.TabIndex = 0;
            this.tabPageMain.Text = "Разное";
            // 
            // tabPageBonus
            // 
            this.tabPageBonus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(250)))), ((int)(((byte)(200)))));
            this.tabPageBonus.Controls.Add(this.menuStripTerms);
            this.tabPageBonus.Controls.Add(this.dataGridViewTerms);
            this.tabPageBonus.Location = new System.Drawing.Point(4, 25);
            this.tabPageBonus.Name = "tabPageBonus";
            this.tabPageBonus.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBonus.Size = new System.Drawing.Size(1262, 315);
            this.tabPageBonus.TabIndex = 1;
            this.tabPageBonus.Text = "Условия бонуса";
            // 
            // menuStripTerms
            // 
            this.menuStripTerms.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStripTerms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemAddTerm,
            this.toolStripMenuItemDelTerm});
            this.menuStripTerms.Location = new System.Drawing.Point(3, 3);
            this.menuStripTerms.Name = "menuStripTerms";
            this.menuStripTerms.Size = new System.Drawing.Size(1256, 28);
            this.menuStripTerms.TabIndex = 36;
            this.menuStripTerms.Text = "menuStrip2";
            // 
            // toolStripMenuItemAddTerm
            // 
            this.toolStripMenuItemAddTerm.Name = "toolStripMenuItemAddTerm";
            this.toolStripMenuItemAddTerm.Size = new System.Drawing.Size(88, 24);
            this.toolStripMenuItemAddTerm.Text = "Добавить";
            this.toolStripMenuItemAddTerm.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItemDelTerm
            // 
            this.toolStripMenuItemDelTerm.Name = "toolStripMenuItemDelTerm";
            this.toolStripMenuItemDelTerm.Size = new System.Drawing.Size(77, 24);
            this.toolStripMenuItemDelTerm.Text = "Удалить";
            this.toolStripMenuItemDelTerm.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // dataGridViewTerms
            // 
            this.dataGridViewTerms.AllowUserToAddRows = false;
            this.dataGridViewTerms.AllowUserToDeleteRows = false;
            this.dataGridViewTerms.AllowUserToResizeRows = false;
            this.dataGridViewTerms.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewTerms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTerms.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FixSum,
            this.Criterion,
            this.PercentSum,
            this.Total});
            this.dataGridViewTerms.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dataGridViewTerms.Location = new System.Drawing.Point(6, 34);
            this.dataGridViewTerms.Name = "dataGridViewTerms";
            this.dataGridViewTerms.RowHeadersVisible = false;
            this.dataGridViewTerms.Size = new System.Drawing.Size(665, 275);
            this.dataGridViewTerms.TabIndex = 0;
            this.dataGridViewTerms.TabStop = false;
            this.dataGridViewTerms.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellValueChanged);
            this.dataGridViewTerms.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView_RowsAdded);
            this.dataGridViewTerms.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGridView_RowsRemoved);
            // 
            // FixSum
            // 
            this.FixSum.HeaderText = "Фиксированная сумма";
            this.FixSum.Name = "FixSum";
            this.FixSum.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FixSum.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Criterion
            // 
            this.Criterion.HeaderText = "Критерий";
            this.Criterion.Name = "Criterion";
            // 
            // PercentSum
            // 
            this.PercentSum.HeaderText = "Процент/Сумма за период";
            this.PercentSum.Name = "PercentSum";
            // 
            // Total
            // 
            this.Total.HeaderText = "Итого по премии";
            this.Total.Name = "Total";
            // 
            // tabPageServices
            // 
            this.tabPageServices.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(250)))), ((int)(((byte)(200)))));
            this.tabPageServices.Controls.Add(this.dataGridViewServices);
            this.tabPageServices.Controls.Add(this.menuStripServices);
            this.tabPageServices.Location = new System.Drawing.Point(4, 25);
            this.tabPageServices.Name = "tabPageServices";
            this.tabPageServices.Size = new System.Drawing.Size(1262, 315);
            this.tabPageServices.TabIndex = 2;
            this.tabPageServices.Text = "Оказываемые услуги";
            // 
            // dataGridViewServices
            // 
            this.dataGridViewServices.AllowUserToAddRows = false;
            this.dataGridViewServices.AllowUserToDeleteRows = false;
            this.dataGridViewServices.AllowUserToResizeRows = false;
            this.dataGridViewServices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewServices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ServiceId,
            this.NameService,
            this.Article,
            this.NameService2,
            this.Coeff});
            this.dataGridViewServices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewServices.Location = new System.Drawing.Point(0, 28);
            this.dataGridViewServices.MultiSelect = false;
            this.dataGridViewServices.Name = "dataGridViewServices";
            this.dataGridViewServices.RowHeadersVisible = false;
            this.dataGridViewServices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewServices.Size = new System.Drawing.Size(1262, 287);
            this.dataGridViewServices.TabIndex = 1;
            this.dataGridViewServices.TabStop = false;
            // 
            // ServiceId
            // 
            this.ServiceId.HeaderText = "Код услуги";
            this.ServiceId.Name = "ServiceId";
            this.ServiceId.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // NameService
            // 
            this.NameService.HeaderText = "Наименование услуги";
            this.NameService.Name = "NameService";
            this.NameService.ReadOnly = true;
            this.NameService.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Article
            // 
            this.Article.HeaderText = "Код статьи";
            this.Article.Name = "Article";
            this.Article.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // NameService2
            // 
            this.NameService2.HeaderText = "Наименование услуги";
            this.NameService2.Name = "NameService2";
            this.NameService2.ReadOnly = true;
            this.NameService2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Coeff
            // 
            this.Coeff.HeaderText = "Коэффициент";
            this.Coeff.Name = "Coeff";
            this.Coeff.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // menuStripServices
            // 
            this.menuStripServices.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStripServices.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemAddService,
            this.ToolStripMenuItemDelService});
            this.menuStripServices.Location = new System.Drawing.Point(0, 0);
            this.menuStripServices.Name = "menuStripServices";
            this.menuStripServices.Size = new System.Drawing.Size(1262, 28);
            this.menuStripServices.TabIndex = 0;
            this.menuStripServices.Text = "menuStrip2";
            // 
            // ToolStripMenuItemAddService
            // 
            this.ToolStripMenuItemAddService.Name = "ToolStripMenuItemAddService";
            this.ToolStripMenuItemAddService.Size = new System.Drawing.Size(88, 24);
            this.ToolStripMenuItemAddService.Text = "Добавить";
            this.ToolStripMenuItemAddService.Click += new System.EventHandler(this.добавитьToolStripMenuItem_Click);
            // 
            // ToolStripMenuItemDelService
            // 
            this.ToolStripMenuItemDelService.Name = "ToolStripMenuItemDelService";
            this.ToolStripMenuItemDelService.Size = new System.Drawing.Size(77, 24);
            this.ToolStripMenuItemDelService.Text = "Удалить";
            this.ToolStripMenuItemDelService.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelMain);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 29);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(12);
            this.panel1.Size = new System.Drawing.Size(1294, 50);
            this.panel1.TabIndex = 48;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControlMain);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 79);
            this.panel2.MaximumSize = new System.Drawing.Size(0, 450);
            this.panel2.MinimumSize = new System.Drawing.Size(0, 350);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(12, 0, 12, 6);
            this.panel2.Size = new System.Drawing.Size(1294, 350);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tabControlInEx);
            this.panel3.Controls.Add(this.buttonAddAll);
            this.panel3.Controls.Add(this.buttonAddProduct);
            this.panel3.Controls.Add(this.buttonAddCategory);
            this.panel3.Controls.Add(this.buttonDelete);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 429);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1294, 224);
            this.panel3.TabIndex = 49;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.buttonUnapprove);
            this.panel4.Controls.Add(this.buttonCancel);
            this.panel4.Controls.Add(this.buttonCreateNApprove);
            this.panel4.Controls.Add(this.buttonCreate);
            this.panel4.Controls.Add(this.buttonClose);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 678);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(12, 0, 12, 12);
            this.panel4.Size = new System.Drawing.Size(1294, 51);
            this.panel4.TabIndex = 50;
            // 
            // buttonUnapprove
            // 
            this.buttonUnapprove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonUnapprove.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonUnapprove.Location = new System.Drawing.Point(105, 12);
            this.buttonUnapprove.Name = "buttonUnapprove";
            this.buttonUnapprove.Size = new System.Drawing.Size(167, 27);
            this.buttonUnapprove.TabIndex = 30;
            this.buttonUnapprove.Text = "Отмена утверждения";
            this.buttonUnapprove.UseVisualStyleBackColor = true;
            this.buttonUnapprove.Visible = false;
            this.buttonUnapprove.Click += new System.EventHandler(this.buttonUnapprove_Click);
            // 
            // InputKUForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(238)))), ((int)(((byte)(168)))));
            this.ClientSize = new System.Drawing.Size(1294, 729);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStripMain);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStripServices;
            this.MinimumSize = new System.Drawing.Size(1310, 700);
            this.Name = "InputKUForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ввести коммерческое условие";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InputKUForm_FormClosing);
            this.Load += new System.EventHandler(this.InputKUForm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InputKUForm_KeyPress);
            this.Resize += new System.EventHandler(this.InputKUForm_Resize);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.tabControlInEx.ResumeLayout(false);
            this.tabPageToInclude.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIncluded)).EndInit();
            this.tabPageToExclude.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExcluded)).EndInit();
            this.groupBoxDescription.ResumeLayout(false);
            this.groupBoxDescription.PerformLayout();
            this.groupBoxPeriod.ResumeLayout(false);
            this.groupBoxPeriod.PerformLayout();
            this.groupBoxSettings.ResumeLayout(false);
            this.groupBoxSettings.PerformLayout();
            this.groupBoxDocument.ResumeLayout(false);
            this.groupBoxDocument.PerformLayout();
            this.tabControlMain.ResumeLayout(false);
            this.tabPageMain.ResumeLayout(false);
            this.tabPageBonus.ResumeLayout(false);
            this.tabPageBonus.PerformLayout();
            this.menuStripTerms.ResumeLayout(false);
            this.menuStripTerms.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTerms)).EndInit();
            this.tabPageServices.ResumeLayout(false);
            this.tabPageServices.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewServices)).EndInit();
            this.menuStripServices.ResumeLayout(false);
            this.menuStripServices.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelMain;
        private System.Windows.Forms.Label labelVendor;
        private System.Windows.Forms.ComboBox comboBoxVendor;
        private System.Windows.Forms.Label labelPeriod;
        private System.Windows.Forms.ComboBox comboBoxPeriod;
        private System.Windows.Forms.Label labelDateFrom;
        private System.Windows.Forms.Label labelDateTo;
        private System.Windows.Forms.DateTimePicker dateTimePickerDateFrom;
        private System.Windows.Forms.DateTimePicker dateTimePickerDateTo;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокКУToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поставщикиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem графикКУToolStripMenuItem;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonCreateNApprove;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.TabControl tabControlInEx;
        private System.Windows.Forms.TabPage tabPageToInclude;
        private System.Windows.Forms.DataGridView dataGridViewIncluded;
        private System.Windows.Forms.DataGridViewTextBoxColumn In_prod_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn KU_idP;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Attribute1P;
        private System.Windows.Forms.DataGridViewTextBoxColumn Attribute2P;
        private System.Windows.Forms.DataGridViewComboBoxColumn ProducerP;
        private System.Windows.Forms.DataGridViewComboBoxColumn BrandP;
        private System.Windows.Forms.TabPage tabPageToExclude;
        private System.Windows.Forms.DataGridView dataGridViewExcluded;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ex_prod_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn KU_idM;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeM;
        private System.Windows.Forms.DataGridViewTextBoxColumn Attribute1M;
        private System.Windows.Forms.DataGridViewTextBoxColumn Attribute2M;
        private System.Windows.Forms.DataGridViewComboBoxColumn ProducerM;
        private System.Windows.Forms.DataGridViewComboBoxColumn BrandM;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonAddCategory;
        private System.Windows.Forms.Button buttonAddProduct;
        private System.Windows.Forms.Button buttonAddAll;
        private System.Windows.Forms.Label labelEntity;
        private System.Windows.Forms.Label labelVendAccount;
        private System.Windows.Forms.CheckBox checkBoxReturn;
        private System.Windows.Forms.CheckBox checkBoxTax;
        private System.Windows.Forms.CheckBox checkBoxOfactured;
        private System.Windows.Forms.ComboBox comboBoxKUType;
        private System.Windows.Forms.Label labelKUType;
        private System.Windows.Forms.Label labelPayMethod;
        private System.Windows.Forms.ComboBox comboBoxPayMethod;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.TextBox textBoxVendAccount;
        private System.Windows.Forms.Label labelContract;
        private System.Windows.Forms.TextBox textBoxContract;
        private System.Windows.Forms.GroupBox groupBoxDescription;
        private System.Windows.Forms.Label labelProductType;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBoxPeriod;
        private System.Windows.Forms.GroupBox groupBoxSettings;
        private System.Windows.Forms.GroupBox groupBoxDocument;
        private System.Windows.Forms.TextBox textBoxTransferTo;
        private System.Windows.Forms.Label labelTransferTo;
        private System.Windows.Forms.TextBox textBoxDocName;
        private System.Windows.Forms.Label labelDocName;
        private System.Windows.Forms.TextBox textBoxDocTitle;
        private System.Windows.Forms.Label labelDocTitle;
        private System.Windows.Forms.TextBox textBoxDocAccount;
        private System.Windows.Forms.Label labelDocAccount;
        private System.Windows.Forms.TextBox textBoxDocCode;
        private System.Windows.Forms.Label labelDocCode;
        private System.Windows.Forms.Label labelDocSubject;
        private System.Windows.Forms.DateTimePicker dateTimePickerDocDate;
        private System.Windows.Forms.Label labelDocDate;
        private System.Windows.Forms.TextBox textBoxDocHeader;
        private System.Windows.Forms.Label labelDocHeader;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageMain;
        private System.Windows.Forms.TabPage tabPageBonus;
        private System.Windows.Forms.RichTextBox richTextBoxDescription;
        private System.Windows.Forms.RichTextBox richTextBoxDocSubject;
        private System.Windows.Forms.DataGridView dataGridViewTerms;
        private System.Windows.Forms.DataGridViewCheckBoxColumn FixSum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Criterion;
        private System.Windows.Forms.DataGridViewTextBoxColumn PercentSum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label labelKUCode;
        private System.Windows.Forms.TextBox textBoxKUCode;
        private System.Windows.Forms.Button buttonUnapprove;
        private System.Windows.Forms.ComboBox comboBoxEntity;
        private System.Windows.Forms.ComboBox comboBoxProductType;
        private System.Windows.Forms.TabPage tabPageServices;
        private System.Windows.Forms.DataGridView dataGridViewServices;
        private System.Windows.Forms.MenuStrip menuStripServices;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAddService;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemDelService;
        private System.Windows.Forms.DataGridViewComboBoxColumn ServiceId;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameService;
        private System.Windows.Forms.DataGridViewComboBoxColumn Article;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameService2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Coeff;
        private System.Windows.Forms.MenuStrip menuStripTerms;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAddTerm;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDelTerm;
    }
}