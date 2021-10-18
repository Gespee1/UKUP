
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
            this.label1 = new System.Windows.Forms.Label();
            this.advancedDataGridView1 = new ADGV.AdvancedDataGridView();
            this.vend_button = new System.Windows.Forms.Button();
            this.service_button = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(760, 29);
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
            this.списокКУToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.списокКУToolStripMenuItem.Text = "Список КУ";
            this.списокКУToolStripMenuItem.Click += new System.EventHandler(this.списокКУToolStripMenuItem_Click);
            // 
            // графикКУToolStripMenuItem
            // 
            this.графикКУToolStripMenuItem.Name = "графикКУToolStripMenuItem";
            this.графикКУToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.графикКУToolStripMenuItem.Text = "График КУ";
            this.графикКУToolStripMenuItem.Click += new System.EventHandler(this.графикКУToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Book Antiqua", 15.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(305, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 26);
            this.label1.TabIndex = 11;
            this.label1.Text = "Справочники";
            // 
            // advancedDataGridView1
            // 
            this.advancedDataGridView1.AllowUserToAddRows = false;
            this.advancedDataGridView1.AllowUserToDeleteRows = false;
            this.advancedDataGridView1.AllowUserToResizeRows = false;
            this.advancedDataGridView1.AutoGenerateContextFilters = true;
            this.advancedDataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.advancedDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridView1.DateWithTime = false;
            this.advancedDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advancedDataGridView1.Location = new System.Drawing.Point(12, 0);
            this.advancedDataGridView1.MultiSelect = false;
            this.advancedDataGridView1.Name = "advancedDataGridView1";
            this.advancedDataGridView1.ReadOnly = true;
            this.advancedDataGridView1.RowHeadersVisible = false;
            this.advancedDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.advancedDataGridView1.Size = new System.Drawing.Size(736, 296);
            this.advancedDataGridView1.TabIndex = 13;
            this.advancedDataGridView1.Tag = "";
            this.advancedDataGridView1.TimeFilter = false;
            this.advancedDataGridView1.SortStringChanged += new System.EventHandler(this.advancedDataGridView1_SortStringChanged);
            this.advancedDataGridView1.FilterStringChanged += new System.EventHandler(this.advancedDataGridView1_FilterStringChanged);
            // 
            // vend_button
            // 
            this.vend_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.vend_button.Location = new System.Drawing.Point(12, 72);
            this.vend_button.Name = "vend_button";
            this.vend_button.Size = new System.Drawing.Size(113, 27);
            this.vend_button.TabIndex = 19;
            this.vend_button.Text = "Поставщики";
            this.vend_button.UseVisualStyleBackColor = true;
            this.vend_button.Click += new System.EventHandler(this.vend_button_Click);
            // 
            // service_button
            // 
            this.service_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.service_button.Location = new System.Drawing.Point(131, 72);
            this.service_button.Name = "service_button";
            this.service_button.Size = new System.Drawing.Size(171, 27);
            this.service_button.TabIndex = 20;
            this.service_button.Text = "Оказываемые услуги";
            this.service_button.UseVisualStyleBackColor = true;
            this.service_button.Click += new System.EventHandler(this.service_button_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.advancedDataGridView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 142);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(12, 0, 12, 12);
            this.panel2.Size = new System.Drawing.Size(760, 308);
            this.panel2.TabIndex = 21;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.vend_button);
            this.panel1.Controls.Add(this.service_button);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 29);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(12, 12, 12, 5);
            this.panel1.Size = new System.Drawing.Size(760, 107);
            this.panel1.TabIndex = 22;
            // 
            // ListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(238)))), ((int)(((byte)(168)))));
            this.ClientSize = new System.Drawing.Size(760, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(370, 300);
            this.Name = "ListForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Справочники";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VendorsListForm_FormClosing);
            this.Load += new System.EventHandler(this.VendorsListForm_Load);
            this.Resize += new System.EventHandler(this.ListForm_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокКУToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem графикКУToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private ADGV.AdvancedDataGridView advancedDataGridView1;
        private System.Windows.Forms.Button vend_button;
        private System.Windows.Forms.Button service_button;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
    }
}

