namespace supply_management
{
    partial class frmSoldItems
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSoldItems));
            this.panel1 = new System.Windows.Forms.Panel();
            this.totalGain = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.totalSales = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridSoldItems = new System.Windows.Forms.DataGridView();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.submit = new Bunifu.Framework.UI.BunifuFlatButton();
            this.username = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cancel = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSoldItems)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(191)))), ((int)(((byte)(213)))));
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.totalGain);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.totalSales);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1591, 54);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // totalGain
            // 
            this.totalGain.AutoSize = true;
            this.totalGain.Font = new System.Drawing.Font("Consolas", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalGain.ForeColor = System.Drawing.Color.White;
            this.totalGain.Location = new System.Drawing.Point(534, 6);
            this.totalGain.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.totalGain.Name = "totalGain";
            this.totalGain.Size = new System.Drawing.Size(99, 43);
            this.totalGain.TabIndex = 41;
            this.totalGain.Text = "0.00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(227, 50);
            this.label3.TabIndex = 40;
            this.label3.Text = "Total Sales :";
            // 
            // totalSales
            // 
            this.totalSales.AutoSize = true;
            this.totalSales.Font = new System.Drawing.Font("Consolas", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalSales.ForeColor = System.Drawing.Color.White;
            this.totalSales.Location = new System.Drawing.Point(229, 6);
            this.totalSales.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.totalSales.Name = "totalSales";
            this.totalSales.Size = new System.Drawing.Size(99, 43);
            this.totalSales.TabIndex = 39;
            this.totalSales.Text = "0.00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(1553, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 37);
            this.label1.TabIndex = 37;
            this.label1.Text = "x";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dataGridSoldItems
            // 
            this.dataGridSoldItems.AllowUserToAddRows = false;
            this.dataGridSoldItems.BackgroundColor = System.Drawing.Color.White;
            this.dataGridSoldItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridSoldItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column9,
            this.Column8,
            this.Cancel});
            this.dataGridSoldItems.Location = new System.Drawing.Point(21, 132);
            this.dataGridSoldItems.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridSoldItems.Name = "dataGridSoldItems";
            this.dataGridSoldItems.RowHeadersWidth = 51;
            this.dataGridSoldItems.Size = new System.Drawing.Size(1553, 690);
            this.dataGridSoldItems.TabIndex = 1;
            this.dataGridSoldItems.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridSoldItems_CellClick);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(287, 75);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(268, 34);
            this.dateTimePicker1.TabIndex = 10;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(564, 75);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(249, 34);
            this.dateTimePicker2.TabIndex = 11;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label5.Location = new System.Drawing.Point(23, 78);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(242, 28);
            this.label5.TabIndex = 22;
            this.label5.Text = "Filter By Date (From - to) : ";
            // 
            // submit
            // 
            this.submit.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.submit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(191)))), ((int)(((byte)(213)))));
            this.submit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.submit.BorderRadius = 5;
            this.submit.ButtonText = "Print Preview";
            this.submit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.submit.DisabledColor = System.Drawing.Color.Gray;
            this.submit.Iconcolor = System.Drawing.Color.Transparent;
            this.submit.Iconimage = null;
            this.submit.Iconimage_right = null;
            this.submit.Iconimage_right_Selected = null;
            this.submit.Iconimage_Selected = null;
            this.submit.IconMarginLeft = 0;
            this.submit.IconMarginRight = 0;
            this.submit.IconRightVisible = true;
            this.submit.IconRightZoom = 0D;
            this.submit.IconVisible = true;
            this.submit.IconZoom = 50D;
            this.submit.IsTab = false;
            this.submit.Location = new System.Drawing.Point(1083, 73);
            this.submit.Margin = new System.Windows.Forms.Padding(5);
            this.submit.Name = "submit";
            this.submit.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(191)))), ((int)(((byte)(213)))));
            this.submit.OnHovercolor = System.Drawing.Color.Silver;
            this.submit.OnHoverTextColor = System.Drawing.Color.White;
            this.submit.selected = false;
            this.submit.Size = new System.Drawing.Size(163, 39);
            this.submit.TabIndex = 46;
            this.submit.Text = "Print Preview";
            this.submit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.submit.Textcolor = System.Drawing.Color.White;
            this.submit.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submit.Click += new System.EventHandler(this.submit_Click);
            // 
            // username
            // 
            this.username.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username.FormattingEnabled = true;
            this.username.Location = new System.Drawing.Point(827, 75);
            this.username.Margin = new System.Windows.Forms.Padding(4);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(243, 36);
            this.username.TabIndex = 47;
            this.username.SelectedValueChanged += new System.EventHandler(this.username_SelectedValueChanged);
            this.username.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.username_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(409, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 51);
            this.label4.TabIndex = 48;
            this.label4.Text = "Gain :";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "#";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 25;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "INVOICE #";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 125;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "PRODUCTS #";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 125;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "DESCRIPTION";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 540;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "PRICE";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Width = 80;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "QTY";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.Width = 80;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "DISCOUNT";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.Width = 80;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "GAIN";
            this.Column9.MinimumWidth = 6;
            this.Column9.Name = "Column9";
            this.Column9.Width = 125;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "TOTAL";
            this.Column8.MinimumWidth = 6;
            this.Column8.Name = "Column8";
            this.Column8.Width = 80;
            // 
            // Cancel
            // 
            this.Cancel.HeaderText = "";
            this.Cancel.Image = ((System.Drawing.Image)(resources.GetObject("Cancel.Image")));
            this.Cancel.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.Cancel.MinimumWidth = 6;
            this.Cancel.Name = "Cancel";
            this.Cancel.Width = 20;
            // 
            // frmSoldItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1591, 837);
            this.Controls.Add(this.username);
            this.Controls.Add(this.submit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.dataGridSoldItems);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmSoldItems";
            this.Text = "frmSoldItems";
            this.Load += new System.EventHandler(this.frmSoldItems_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSoldItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridSoldItems;
        private System.Windows.Forms.Label totalSales;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        public Bunifu.Framework.UI.BunifuFlatButton submit;
        public System.Windows.Forms.DateTimePicker dateTimePicker1;
        public System.Windows.Forms.DateTimePicker dateTimePicker2;
        public System.Windows.Forms.ComboBox username;
        public System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label totalGain;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewImageColumn Cancel;
    }
}