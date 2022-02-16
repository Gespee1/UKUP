
namespace РасчетКУ
{
    partial class ListForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокКУToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.графикКУToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelMain = new System.Windows.Forms.Label();
            this.buttonVendors = new System.Windows.Forms.Button();
            this.service_button = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonCustomers = new System.Windows.Forms.Button();
            this.buttonInvoices = new System.Windows.Forms.Button();
            this.labelRows = new System.Windows.Forms.Label();
            this.buttonAllProducts = new System.Windows.Forms.Button();
            this.buttonEntities = new System.Windows.Forms.Button();
            this.buttonClassifier = new System.Windows.Forms.Button();
            this.advancedDataGridView = new EDGV.ExtendedDataGridView();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(934, 29);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.списокКУToolStripMenuItem,
            this.графикКУToolStripMenuItem});
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(84, 25);
            this.открытьToolStripMenuItem.Text = "Открыть";
            // 
            // списокКУToolStripMenuItem
            // 
            this.списокКУToolStripMenuItem.Name = "списокКУToolStripMenuItem";
            this.списокКУToolStripMenuItem.Size = new System.Drawing.Size(155, 26);
            this.списокКУToolStripMenuItem.Text = "Список КУ";
            this.списокКУToolStripMenuItem.Click += new System.EventHandler(this.списокКУToolStripMenuItem_Click);
            // 
            // графикКУToolStripMenuItem
            // 
            this.графикКУToolStripMenuItem.Name = "графикКУToolStripMenuItem";
            this.графикКУToolStripMenuItem.Size = new System.Drawing.Size(155, 26);
            this.графикКУToolStripMenuItem.Text = "График КУ";
            this.графикКУToolStripMenuItem.Click += new System.EventHandler(this.графикКУToolStripMenuItem_Click);
            // 
            // labelMain
            // 
            this.labelMain.AutoSize = true;
            this.labelMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMain.Location = new System.Drawing.Point(305, 12);
            this.labelMain.Name = "labelMain";
            this.labelMain.Size = new System.Drawing.Size(155, 25);
            this.labelMain.TabIndex = 11;
            this.labelMain.Text = "Справочники";
            // 
            // buttonVendors
            // 
            this.buttonVendors.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonVendors.Location = new System.Drawing.Point(12, 72);
            this.buttonVendors.Name = "buttonVendors";
            this.buttonVendors.Size = new System.Drawing.Size(113, 27);
            this.buttonVendors.TabIndex = 1;
            this.buttonVendors.Text = "Поставщики";
            this.buttonVendors.UseVisualStyleBackColor = true;
            this.buttonVendors.Click += new System.EventHandler(this.vend_button_Click);
            // 
            // service_button
            // 
            this.service_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.service_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.service_button.Location = new System.Drawing.Point(748, 72);
            this.service_button.Name = "service_button";
            this.service_button.Size = new System.Drawing.Size(171, 27);
            this.service_button.TabIndex = 5;
            this.service_button.Text = "Оказываемые услуги";
            this.service_button.UseVisualStyleBackColor = true;
            this.service_button.Click += new System.EventHandler(this.service_button_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.advancedDataGridView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 243);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(12, 0, 12, 12);
            this.panel2.Size = new System.Drawing.Size(934, 308);
            this.panel2.TabIndex = 21;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonCustomers);
            this.panel1.Controls.Add(this.buttonInvoices);
            this.panel1.Controls.Add(this.labelRows);
            this.panel1.Controls.Add(this.buttonAllProducts);
            this.panel1.Controls.Add(this.buttonEntities);
            this.panel1.Controls.Add(this.buttonClassifier);
            this.panel1.Controls.Add(this.buttonVendors);
            this.panel1.Controls.Add(this.service_button);
            this.panel1.Controls.Add(this.labelMain);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 29);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(12, 12, 12, 5);
            this.panel1.Size = new System.Drawing.Size(934, 107);
            this.panel1.TabIndex = 22;
            // 
            // buttonCustomers
            // 
            this.buttonCustomers.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCustomers.Location = new System.Drawing.Point(131, 72);
            this.buttonCustomers.Name = "buttonCustomers";
            this.buttonCustomers.Size = new System.Drawing.Size(109, 27);
            this.buttonCustomers.TabIndex = 26;
            this.buttonCustomers.Text = "Клиенты";
            this.buttonCustomers.UseVisualStyleBackColor = true;
            this.buttonCustomers.Click += new System.EventHandler(this.buttonCustomers_Click);
            // 
            // buttonInvoices
            // 
            this.buttonInvoices.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonInvoices.Location = new System.Drawing.Point(603, 72);
            this.buttonInvoices.Name = "buttonInvoices";
            this.buttonInvoices.Size = new System.Drawing.Size(109, 27);
            this.buttonInvoices.TabIndex = 25;
            this.buttonInvoices.Text = "Накладные";
            this.buttonInvoices.UseVisualStyleBackColor = true;
            this.buttonInvoices.Click += new System.EventHandler(this.buttonInvoices_Click);
            // 
            // labelRows
            // 
            this.labelRows.AutoSize = true;
            this.labelRows.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelRows.Location = new System.Drawing.Point(12, 53);
            this.labelRows.Name = "labelRows";
            this.labelRows.Size = new System.Drawing.Size(178, 16);
            this.labelRows.TabIndex = 24;
            this.labelRows.Text = "Кол-во выведенных строк:";
            this.labelRows.Visible = false;
            // 
            // buttonAllProducts
            // 
            this.buttonAllProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAllProducts.Location = new System.Drawing.Point(348, 72);
            this.buttonAllProducts.Name = "buttonAllProducts";
            this.buttonAllProducts.Size = new System.Drawing.Size(109, 27);
            this.buttonAllProducts.TabIndex = 4;
            this.buttonAllProducts.Text = "Все товары";
            this.buttonAllProducts.UseVisualStyleBackColor = true;
            this.buttonAllProducts.Click += new System.EventHandler(this.buttonAllProducts_Click);
            // 
            // buttonEntities
            // 
            this.buttonEntities.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonEntities.Location = new System.Drawing.Point(246, 72);
            this.buttonEntities.Name = "buttonEntities";
            this.buttonEntities.Size = new System.Drawing.Size(96, 27);
            this.buttonEntities.TabIndex = 3;
            this.buttonEntities.Text = "Юр. лица";
            this.buttonEntities.UseVisualStyleBackColor = true;
            this.buttonEntities.Click += new System.EventHandler(this.buttonEntities_Click);
            // 
            // buttonClassifier
            // 
            this.buttonClassifier.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonClassifier.Location = new System.Drawing.Point(463, 72);
            this.buttonClassifier.Name = "buttonClassifier";
            this.buttonClassifier.Size = new System.Drawing.Size(134, 27);
            this.buttonClassifier.TabIndex = 2;
            this.buttonClassifier.Text = "Классификатор";
            this.buttonClassifier.UseVisualStyleBackColor = true;
            this.buttonClassifier.Click += new System.EventHandler(this.buttonClassifier_Click);
            // 
            // advancedDataGridView
            // 
            this.advancedDataGridView.AllowUserToAddRows = false;
            this.advancedDataGridView.AllowUserToDeleteRows = false;
            this.advancedDataGridView.AllowUserToResizeRows = false;
            this.advancedDataGridView.AutoGenerateContextFilters = true;
            this.advancedDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.advancedDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridView.DateWithTime = false;
            this.advancedDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advancedDataGridView.Location = new System.Drawing.Point(12, 0);
            this.advancedDataGridView.MultiSelect = false;
            this.advancedDataGridView.Name = "advancedDataGridView";
            this.advancedDataGridView.ReadOnly = true;
            this.advancedDataGridView.RowHeadersVisible = false;
            this.advancedDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.advancedDataGridView.Size = new System.Drawing.Size(910, 296);
            this.advancedDataGridView.TabIndex = 13;
            this.advancedDataGridView.TabStop = false;
            this.advancedDataGridView.Tag = "";
            this.advancedDataGridView.TimeFilter = false;
            this.advancedDataGridView.FilterStringChanged += new System.EventHandler(this.advancedDataGridView1_FilterStringChanged);
            this.advancedDataGridView.SortStringChanged += new System.EventHandler(this.advancedDataGridView1_SortStringChanged);
            this.advancedDataGridView.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.advancedDataGridView_CellMouseDoubleClick);
            // 
            // ListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(238)))), ((int)(((byte)(168)))));
            this.ClientSize = new System.Drawing.Size(934, 551);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(950, 200);
            this.Name = "ListForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Справочники";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VendorsListForm_FormClosing);
            this.Load += new System.EventHandler(this.VendorsListForm_Load);
            this.Resize += new System.EventHandler(this.ListForm_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокКУToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem графикКУToolStripMenuItem;
        private System.Windows.Forms.Label labelMain;
        private EDGV.ExtendedDataGridView advancedDataGridView;
        private System.Windows.Forms.Button buttonVendors;
        private System.Windows.Forms.Button service_button;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonClassifier;
        private System.Windows.Forms.Button buttonEntities;
        private System.Windows.Forms.Button buttonAllProducts;
        private System.Windows.Forms.Label labelRows;
        private System.Windows.Forms.Button buttonCustomers;
        private System.Windows.Forms.Button buttonInvoices;
    }
}

