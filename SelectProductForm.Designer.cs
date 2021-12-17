
namespace РасчетКУ
{
    partial class SelectProductForm
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
            this.buttonAddSelected = new System.Windows.Forms.Button();
            this.advancedDataGridViewProducts = new ADGV.AdvancedDataGridView();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelShownProducts = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridViewProducts)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelMain
            // 
            this.labelMain.AutoSize = true;
            this.labelMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMain.Location = new System.Drawing.Point(15, 12);
            this.labelMain.Name = "labelMain";
            this.labelMain.Size = new System.Drawing.Size(213, 25);
            this.labelMain.TabIndex = 1;
            this.labelMain.Text = "Товары поставщика";
            // 
            // buttonAddSelected
            // 
            this.buttonAddSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddSelected.Location = new System.Drawing.Point(732, 488);
            this.buttonAddSelected.Name = "buttonAddSelected";
            this.buttonAddSelected.Size = new System.Drawing.Size(194, 32);
            this.buttonAddSelected.TabIndex = 3;
            this.buttonAddSelected.Text = "Добавить выбранное";
            this.buttonAddSelected.UseVisualStyleBackColor = true;
            this.buttonAddSelected.Click += new System.EventHandler(this.button1_Click);
            // 
            // advancedDataGridViewProducts
            // 
            this.advancedDataGridViewProducts.AllowUserToAddRows = false;
            this.advancedDataGridViewProducts.AllowUserToDeleteRows = false;
            this.advancedDataGridViewProducts.AllowUserToResizeRows = false;
            this.advancedDataGridViewProducts.AutoGenerateContextFilters = true;
            this.advancedDataGridViewProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.advancedDataGridViewProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridViewProducts.DateWithTime = false;
            this.advancedDataGridViewProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advancedDataGridViewProducts.Location = new System.Drawing.Point(12, 0);
            this.advancedDataGridViewProducts.MultiSelect = false;
            this.advancedDataGridViewProducts.Name = "advancedDataGridViewProducts";
            this.advancedDataGridViewProducts.RowHeadersVisible = false;
            this.advancedDataGridViewProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.advancedDataGridViewProducts.Size = new System.Drawing.Size(914, 427);
            this.advancedDataGridViewProducts.TabIndex = 5;
            this.advancedDataGridViewProducts.TimeFilter = false;
            this.advancedDataGridViewProducts.SortStringChanged += new System.EventHandler(this.advancedDataGridView1_SortStringChanged);
            this.advancedDataGridViewProducts.FilterStringChanged += new System.EventHandler(this.advancedDataGridView1_FilterStringChanged);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCancel.Location = new System.Drawing.Point(632, 488);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(94, 32);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.button2_Click);
            // 
            // labelShownProducts
            // 
            this.labelShownProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelShownProducts.AutoSize = true;
            this.labelShownProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelShownProducts.Location = new System.Drawing.Point(12, 494);
            this.labelShownProducts.Name = "labelShownProducts";
            this.labelShownProducts.Size = new System.Drawing.Size(175, 20);
            this.labelShownProducts.TabIndex = 7;
            this.labelShownProducts.Text = "Отображено товаров:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelMain);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(12);
            this.panel1.Size = new System.Drawing.Size(938, 52);
            this.panel1.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.advancedDataGridViewProducts);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 52);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(12, 0, 12, 12);
            this.panel2.Size = new System.Drawing.Size(938, 439);
            this.panel2.TabIndex = 9;
            // 
            // SelectProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(238)))), ((int)(((byte)(168)))));
            this.ClientSize = new System.Drawing.Size(938, 532);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelShownProducts);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonAddSelected);
            this.MinimumSize = new System.Drawing.Size(540, 260);
            this.Name = "SelectProductForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Форма выбора товара";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SelectForm_FormClosing);
            this.Load += new System.EventHandler(this.SelectForm_Load);
            this.Resize += new System.EventHandler(this.SelectProductForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridViewProducts)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelMain;
        private System.Windows.Forms.Button buttonAddSelected;
        private ADGV.AdvancedDataGridView advancedDataGridViewProducts;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelShownProducts;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}