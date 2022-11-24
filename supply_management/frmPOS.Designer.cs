namespace supply_management
{
    partial class frmPOS
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPOS));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.lblDisplayTotal = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.currentDate = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.Time = new System.Windows.Forms.Label();
            this.lblvatable = new System.Windows.Forms.TextBox();
            this.vatlbl = new System.Windows.Forms.TextBox();
            this.txtdiscount = new System.Windows.Forms.TextBox();
            this.total_sales = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_recovery = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuFlatButton2 = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuFlatButton1 = new Bunifu.Framework.UI.BunifuFlatButton();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.Logout = new Bunifu.Framework.UI.BunifuFlatButton();
            this.dailySales = new Bunifu.Framework.UI.BunifuFlatButton();
            this.settlePayment = new Bunifu.Framework.UI.BunifuFlatButton();
            this.addDiscount = new Bunifu.Framework.UI.BunifuFlatButton();
            this.searchProduct = new Bunifu.Framework.UI.BunifuFlatButton();
            this.newTransaction = new Bunifu.Framework.UI.BunifuFlatButton();
            this.dataGridTransaction = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.removeqty = new System.Windows.Forms.DataGridViewImageColumn();
            this.addqty = new System.Windows.Forms.DataGridViewImageColumn();
            this.Delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.date = new System.Windows.Forms.Label();
            this.Transactionlbl = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTransaction)).BeginInit();
            this.panel4.SuspendLayout();
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(44)))), ((int)(((byte)(122)))));
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lblDisplayTotal);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.ForeColor = System.Drawing.Color.Yellow;
            this.panel1.Location = new System.Drawing.Point(-8, -1);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1736, 95);
            this.panel1.TabIndex = 29;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(129, 46);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 28);
            this.label4.TabIndex = 20;
            this.label4.Text = "Cashier  | ";
            // 
            // lblDisplayTotal
            // 
            this.lblDisplayTotal.AutoSize = true;
            this.lblDisplayTotal.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblDisplayTotal.Font = new System.Drawing.Font("Consolas", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplayTotal.ForeColor = System.Drawing.Color.White;
            this.lblDisplayTotal.Location = new System.Drawing.Point(1574, 0);
            this.lblDisplayTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDisplayTotal.Name = "lblDisplayTotal";
            this.lblDisplayTotal.Size = new System.Drawing.Size(162, 70);
            this.lblDisplayTotal.TabIndex = 19;
            this.lblDisplayTotal.Text = "0.00";
            this.lblDisplayTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(191)))), ((int)(((byte)(213)))));
            this.label11.Location = new System.Drawing.Point(124, 12);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(194, 32);
            this.label11.TabIndex = 18;
            this.label11.Text = "POS SOFTWARE";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(224, 47);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 28);
            this.label1.TabIndex = 15;
            this.label1.Text = "Cashier";
            // 
            // panel5
            // 
            this.panel5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel5.BackgroundImage")));
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel5.Location = new System.Drawing.Point(27, 6);
            this.panel5.Margin = new System.Windows.Forms.Padding(4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(84, 76);
            this.panel5.TabIndex = 14;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.Control;
            this.panel6.Controls.Add(this.panel10);
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Controls.Add(this.lblvatable);
            this.panel6.Controls.Add(this.vatlbl);
            this.panel6.Controls.Add(this.txtdiscount);
            this.panel6.Controls.Add(this.total_sales);
            this.panel6.Controls.Add(this.label6);
            this.panel6.Controls.Add(this.label5);
            this.panel6.Controls.Add(this.label3);
            this.panel6.Controls.Add(this.label2);
            this.panel6.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel6.Location = new System.Drawing.Point(4, 524);
            this.panel6.Margin = new System.Windows.Forms.Padding(4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1396, 231);
            this.panel6.TabIndex = 3;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(191)))), ((int)(((byte)(213)))));
            this.panel10.Controls.Add(this.currentDate);
            this.panel10.Location = new System.Drawing.Point(1, 124);
            this.panel10.Margin = new System.Windows.Forms.Padding(4);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(501, 63);
            this.panel10.TabIndex = 9;
            // 
            // currentDate
            // 
            this.currentDate.AutoSize = true;
            this.currentDate.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentDate.ForeColor = System.Drawing.Color.White;
            this.currentDate.Location = new System.Drawing.Point(13, 12);
            this.currentDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.currentDate.Name = "currentDate";
            this.currentDate.Size = new System.Drawing.Size(121, 41);
            this.currentDate.TabIndex = 1;
            this.currentDate.Text = "label13";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(191)))), ((int)(((byte)(213)))));
            this.panel7.Controls.Add(this.Time);
            this.panel7.Location = new System.Drawing.Point(0, 28);
            this.panel7.Margin = new System.Windows.Forms.Padding(4);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(640, 89);
            this.panel7.TabIndex = 8;
            // 
            // Time
            // 
            this.Time.AutoSize = true;
            this.Time.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Time.ForeColor = System.Drawing.Color.White;
            this.Time.Location = new System.Drawing.Point(5, 5);
            this.Time.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Time.Name = "Time";
            this.Time.Size = new System.Drawing.Size(240, 81);
            this.Time.TabIndex = 0;
            this.Time.Text = "label12";
            // 
            // lblvatable
            // 
            this.lblvatable.BackColor = System.Drawing.SystemColors.Control;
            this.lblvatable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblvatable.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblvatable.Location = new System.Drawing.Point(1181, 151);
            this.lblvatable.Margin = new System.Windows.Forms.Padding(4);
            this.lblvatable.Name = "lblvatable";
            this.lblvatable.Size = new System.Drawing.Size(184, 35);
            this.lblvatable.TabIndex = 7;
            this.lblvatable.Text = "0.00";
            this.lblvatable.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // vatlbl
            // 
            this.vatlbl.BackColor = System.Drawing.SystemColors.Control;
            this.vatlbl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.vatlbl.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vatlbl.Location = new System.Drawing.Point(1181, 111);
            this.vatlbl.Margin = new System.Windows.Forms.Padding(4);
            this.vatlbl.Name = "vatlbl";
            this.vatlbl.Size = new System.Drawing.Size(184, 35);
            this.vatlbl.TabIndex = 6;
            this.vatlbl.Text = "0.00";
            this.vatlbl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtdiscount
            // 
            this.txtdiscount.BackColor = System.Drawing.SystemColors.Control;
            this.txtdiscount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtdiscount.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdiscount.Location = new System.Drawing.Point(1180, 69);
            this.txtdiscount.Margin = new System.Windows.Forms.Padding(4);
            this.txtdiscount.Name = "txtdiscount";
            this.txtdiscount.Size = new System.Drawing.Size(184, 35);
            this.txtdiscount.TabIndex = 5;
            this.txtdiscount.Text = "0.00";
            this.txtdiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // total_sales
            // 
            this.total_sales.BackColor = System.Drawing.SystemColors.Control;
            this.total_sales.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.total_sales.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.total_sales.Location = new System.Drawing.Point(1180, 30);
            this.total_sales.Margin = new System.Windows.Forms.Padding(4);
            this.total_sales.Name = "total_sales";
            this.total_sales.Size = new System.Drawing.Size(184, 35);
            this.total_sales.TabIndex = 4;
            this.total_sales.Text = "0.00";
            this.total_sales.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(1073, 151);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 28);
            this.label6.TabIndex = 3;
            this.label6.Text = "VATABLE :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1115, 116);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 28);
            this.label5.TabIndex = 2;
            this.label5.Text = "VAT :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1048, 75);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 28);
            this.label3.TabIndex = 1;
            this.label3.Text = "DISCOUNT :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1024, 32);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 28);
            this.label2.TabIndex = 0;
            this.label2.Text = "SALES  TOTAL :";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(191)))), ((int)(((byte)(213)))));
            this.panel3.Controls.Add(this.btn_recovery);
            this.panel3.Controls.Add(this.bunifuFlatButton2);
            this.panel3.Controls.Add(this.bunifuFlatButton1);
            this.panel3.Controls.Add(this.panel9);
            this.panel3.Controls.Add(this.panel8);
            this.panel3.Controls.Add(this.Logout);
            this.panel3.Controls.Add(this.dailySales);
            this.panel3.Controls.Add(this.settlePayment);
            this.panel3.Controls.Add(this.addDiscount);
            this.panel3.Controls.Add(this.searchProduct);
            this.panel3.Controls.Add(this.newTransaction);
            this.panel3.Location = new System.Drawing.Point(1396, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(331, 756);
            this.panel3.TabIndex = 0;
            // 
            // btn_recovery
            // 
            this.btn_recovery.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.btn_recovery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(191)))), ((int)(((byte)(213)))));
            this.btn_recovery.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_recovery.BorderRadius = 0;
            this.btn_recovery.ButtonText = "   RECOVERY";
            this.btn_recovery.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_recovery.DisabledColor = System.Drawing.Color.Gray;
            this.btn_recovery.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btn_recovery.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_recovery.Iconimage = ((System.Drawing.Image)(resources.GetObject("btn_recovery.Iconimage")));
            this.btn_recovery.Iconimage_right = null;
            this.btn_recovery.Iconimage_right_Selected = null;
            this.btn_recovery.Iconimage_Selected = null;
            this.btn_recovery.IconMarginLeft = 0;
            this.btn_recovery.IconMarginRight = 0;
            this.btn_recovery.IconRightVisible = true;
            this.btn_recovery.IconRightZoom = 0D;
            this.btn_recovery.IconVisible = true;
            this.btn_recovery.IconZoom = 50D;
            this.btn_recovery.IsTab = false;
            this.btn_recovery.Location = new System.Drawing.Point(0, 286);
            this.btn_recovery.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btn_recovery.Name = "btn_recovery";
            this.btn_recovery.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(191)))), ((int)(((byte)(213)))));
            this.btn_recovery.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(190)))), ((int)(((byte)(17)))));
            this.btn_recovery.OnHoverTextColor = System.Drawing.Color.White;
            this.btn_recovery.selected = false;
            this.btn_recovery.Size = new System.Drawing.Size(335, 47);
            this.btn_recovery.TabIndex = 24;
            this.btn_recovery.Text = "   RECOVERY";
            this.btn_recovery.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_recovery.Textcolor = System.Drawing.Color.White;
            this.btn_recovery.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_recovery.Click += new System.EventHandler(this.btn_recovery_Click);
            // 
            // bunifuFlatButton2
            // 
            this.bunifuFlatButton2.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.bunifuFlatButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(191)))), ((int)(((byte)(213)))));
            this.bunifuFlatButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuFlatButton2.BorderRadius = 0;
            this.bunifuFlatButton2.ButtonText = "   CLEAR CART";
            this.bunifuFlatButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuFlatButton2.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuFlatButton2.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.bunifuFlatButton2.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton2.Iconimage = ((System.Drawing.Image)(resources.GetObject("bunifuFlatButton2.Iconimage")));
            this.bunifuFlatButton2.Iconimage_right = null;
            this.bunifuFlatButton2.Iconimage_right_Selected = null;
            this.bunifuFlatButton2.Iconimage_Selected = null;
            this.bunifuFlatButton2.IconMarginLeft = 0;
            this.bunifuFlatButton2.IconMarginRight = 0;
            this.bunifuFlatButton2.IconRightVisible = true;
            this.bunifuFlatButton2.IconRightZoom = 0D;
            this.bunifuFlatButton2.IconVisible = true;
            this.bunifuFlatButton2.IconZoom = 50D;
            this.bunifuFlatButton2.IsTab = false;
            this.bunifuFlatButton2.Location = new System.Drawing.Point(0, 183);
            this.bunifuFlatButton2.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.bunifuFlatButton2.Name = "bunifuFlatButton2";
            this.bunifuFlatButton2.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(191)))), ((int)(((byte)(213)))));
            this.bunifuFlatButton2.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(190)))), ((int)(((byte)(17)))));
            this.bunifuFlatButton2.OnHoverTextColor = System.Drawing.Color.White;
            this.bunifuFlatButton2.selected = false;
            this.bunifuFlatButton2.Size = new System.Drawing.Size(331, 47);
            this.bunifuFlatButton2.TabIndex = 23;
            this.bunifuFlatButton2.Text = "   CLEAR CART";
            this.bunifuFlatButton2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bunifuFlatButton2.Textcolor = System.Drawing.Color.White;
            this.bunifuFlatButton2.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuFlatButton2.Click += new System.EventHandler(this.bunifuFlatButton2_Click);
            // 
            // bunifuFlatButton1
            // 
            this.bunifuFlatButton1.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.bunifuFlatButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(191)))), ((int)(((byte)(213)))));
            this.bunifuFlatButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuFlatButton1.BorderRadius = 0;
            this.bunifuFlatButton1.ButtonText = "   CHANGE PASSWORD";
            this.bunifuFlatButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuFlatButton1.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuFlatButton1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.bunifuFlatButton1.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton1.Iconimage = ((System.Drawing.Image)(resources.GetObject("bunifuFlatButton1.Iconimage")));
            this.bunifuFlatButton1.Iconimage_right = null;
            this.bunifuFlatButton1.Iconimage_right_Selected = null;
            this.bunifuFlatButton1.Iconimage_Selected = null;
            this.bunifuFlatButton1.IconMarginLeft = 0;
            this.bunifuFlatButton1.IconMarginRight = 0;
            this.bunifuFlatButton1.IconRightVisible = true;
            this.bunifuFlatButton1.IconRightZoom = 0D;
            this.bunifuFlatButton1.IconVisible = true;
            this.bunifuFlatButton1.IconZoom = 50D;
            this.bunifuFlatButton1.IsTab = false;
            this.bunifuFlatButton1.Location = new System.Drawing.Point(1, 336);
            this.bunifuFlatButton1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.bunifuFlatButton1.Name = "bunifuFlatButton1";
            this.bunifuFlatButton1.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(191)))), ((int)(((byte)(213)))));
            this.bunifuFlatButton1.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(190)))), ((int)(((byte)(17)))));
            this.bunifuFlatButton1.OnHoverTextColor = System.Drawing.Color.White;
            this.bunifuFlatButton1.selected = false;
            this.bunifuFlatButton1.Size = new System.Drawing.Size(335, 47);
            this.bunifuFlatButton1.TabIndex = 22;
            this.bunifuFlatButton1.Text = "   CHANGE PASSWORD";
            this.bunifuFlatButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bunifuFlatButton1.Textcolor = System.Drawing.Color.White;
            this.bunifuFlatButton1.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuFlatButton1.Click += new System.EventHandler(this.bunifuFlatButton1_Click_1);
            // 
            // panel9
            // 
            this.panel9.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel9.BackgroundImage")));
            this.panel9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel9.Location = new System.Drawing.Point(-1, 615);
            this.panel9.Margin = new System.Windows.Forms.Padding(4);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(333, 150);
            this.panel9.TabIndex = 21;
            // 
            // panel8
            // 
            this.panel8.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel8.BackgroundImage")));
            this.panel8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel8.Location = new System.Drawing.Point(-3, 447);
            this.panel8.Margin = new System.Windows.Forms.Padding(4);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(333, 171);
            this.panel8.TabIndex = 20;
            // 
            // Logout
            // 
            this.Logout.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.Logout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(72)))), ((int)(((byte)(64)))));
            this.Logout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Logout.BorderRadius = 0;
            this.Logout.ButtonText = "             LOGOUT";
            this.Logout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Logout.DisabledColor = System.Drawing.Color.Gray;
            this.Logout.Iconcolor = System.Drawing.Color.Transparent;
            this.Logout.Iconimage = ((System.Drawing.Image)(resources.GetObject("Logout.Iconimage")));
            this.Logout.Iconimage_right = null;
            this.Logout.Iconimage_right_Selected = null;
            this.Logout.Iconimage_Selected = null;
            this.Logout.IconMarginLeft = 0;
            this.Logout.IconMarginRight = 0;
            this.Logout.IconRightVisible = true;
            this.Logout.IconRightZoom = 0D;
            this.Logout.IconVisible = true;
            this.Logout.IconZoom = 50D;
            this.Logout.IsTab = false;
            this.Logout.Location = new System.Drawing.Point(-1, 400);
            this.Logout.Margin = new System.Windows.Forms.Padding(5);
            this.Logout.Name = "Logout";
            this.Logout.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(72)))), ((int)(((byte)(64)))));
            this.Logout.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(190)))), ((int)(((byte)(17)))));
            this.Logout.OnHoverTextColor = System.Drawing.Color.White;
            this.Logout.selected = false;
            this.Logout.Size = new System.Drawing.Size(333, 47);
            this.Logout.TabIndex = 19;
            this.Logout.Text = "             LOGOUT";
            this.Logout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Logout.Textcolor = System.Drawing.Color.White;
            this.Logout.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Logout.Click += new System.EventHandler(this.bunifuFlatButton1_Click);
            // 
            // dailySales
            // 
            this.dailySales.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.dailySales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(191)))), ((int)(((byte)(213)))));
            this.dailySales.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.dailySales.BorderRadius = 0;
            this.dailySales.ButtonText = "   DAILY SALES";
            this.dailySales.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dailySales.DisabledColor = System.Drawing.Color.Gray;
            this.dailySales.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.dailySales.Iconcolor = System.Drawing.Color.Transparent;
            this.dailySales.Iconimage = ((System.Drawing.Image)(resources.GetObject("dailySales.Iconimage")));
            this.dailySales.Iconimage_right = null;
            this.dailySales.Iconimage_right_Selected = null;
            this.dailySales.Iconimage_Selected = null;
            this.dailySales.IconMarginLeft = 0;
            this.dailySales.IconMarginRight = 0;
            this.dailySales.IconRightVisible = true;
            this.dailySales.IconRightZoom = 0D;
            this.dailySales.IconVisible = true;
            this.dailySales.IconZoom = 50D;
            this.dailySales.IsTab = false;
            this.dailySales.Location = new System.Drawing.Point(1, 234);
            this.dailySales.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.dailySales.Name = "dailySales";
            this.dailySales.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(191)))), ((int)(((byte)(213)))));
            this.dailySales.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(190)))), ((int)(((byte)(17)))));
            this.dailySales.OnHoverTextColor = System.Drawing.Color.White;
            this.dailySales.selected = false;
            this.dailySales.Size = new System.Drawing.Size(333, 47);
            this.dailySales.TabIndex = 13;
            this.dailySales.Text = "   DAILY SALES";
            this.dailySales.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dailySales.Textcolor = System.Drawing.Color.White;
            this.dailySales.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dailySales.Click += new System.EventHandler(this.dailySales_Click);
            // 
            // settlePayment
            // 
            this.settlePayment.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(191)))), ((int)(((byte)(213)))));
            this.settlePayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(191)))), ((int)(((byte)(213)))));
            this.settlePayment.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.settlePayment.BorderRadius = 0;
            this.settlePayment.ButtonText = "   SETTLE PAYMENTS";
            this.settlePayment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.settlePayment.DisabledColor = System.Drawing.Color.Gray;
            this.settlePayment.Enabled = false;
            this.settlePayment.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.settlePayment.Iconcolor = System.Drawing.Color.Transparent;
            this.settlePayment.Iconimage = ((System.Drawing.Image)(resources.GetObject("settlePayment.Iconimage")));
            this.settlePayment.Iconimage_right = null;
            this.settlePayment.Iconimage_right_Selected = null;
            this.settlePayment.Iconimage_Selected = null;
            this.settlePayment.IconMarginLeft = 0;
            this.settlePayment.IconMarginRight = 0;
            this.settlePayment.IconRightVisible = true;
            this.settlePayment.IconRightZoom = 0D;
            this.settlePayment.IconVisible = true;
            this.settlePayment.IconZoom = 50D;
            this.settlePayment.IsTab = false;
            this.settlePayment.Location = new System.Drawing.Point(0, 138);
            this.settlePayment.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.settlePayment.Name = "settlePayment";
            this.settlePayment.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(191)))), ((int)(((byte)(213)))));
            this.settlePayment.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(190)))), ((int)(((byte)(17)))));
            this.settlePayment.OnHoverTextColor = System.Drawing.Color.White;
            this.settlePayment.selected = false;
            this.settlePayment.Size = new System.Drawing.Size(331, 47);
            this.settlePayment.TabIndex = 13;
            this.settlePayment.Text = "   SETTLE PAYMENTS";
            this.settlePayment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.settlePayment.Textcolor = System.Drawing.Color.White;
            this.settlePayment.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settlePayment.Click += new System.EventHandler(this.settlePayment_Click);
            // 
            // addDiscount
            // 
            this.addDiscount.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(191)))), ((int)(((byte)(213)))));
            this.addDiscount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(191)))), ((int)(((byte)(213)))));
            this.addDiscount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.addDiscount.BorderRadius = 0;
            this.addDiscount.ButtonText = "   ADD DISCOUNTS";
            this.addDiscount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addDiscount.DisabledColor = System.Drawing.Color.Gray;
            this.addDiscount.Enabled = false;
            this.addDiscount.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.addDiscount.Iconcolor = System.Drawing.Color.Transparent;
            this.addDiscount.Iconimage = ((System.Drawing.Image)(resources.GetObject("addDiscount.Iconimage")));
            this.addDiscount.Iconimage_right = null;
            this.addDiscount.Iconimage_right_Selected = null;
            this.addDiscount.Iconimage_Selected = null;
            this.addDiscount.IconMarginLeft = 0;
            this.addDiscount.IconMarginRight = 0;
            this.addDiscount.IconRightVisible = true;
            this.addDiscount.IconRightZoom = 0D;
            this.addDiscount.IconVisible = true;
            this.addDiscount.IconZoom = 50D;
            this.addDiscount.IsTab = false;
            this.addDiscount.Location = new System.Drawing.Point(-1, 92);
            this.addDiscount.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.addDiscount.Name = "addDiscount";
            this.addDiscount.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(191)))), ((int)(((byte)(213)))));
            this.addDiscount.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(190)))), ((int)(((byte)(17)))));
            this.addDiscount.OnHoverTextColor = System.Drawing.Color.White;
            this.addDiscount.selected = false;
            this.addDiscount.Size = new System.Drawing.Size(331, 47);
            this.addDiscount.TabIndex = 10;
            this.addDiscount.Text = "   ADD DISCOUNTS";
            this.addDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addDiscount.Textcolor = System.Drawing.Color.White;
            this.addDiscount.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addDiscount.Click += new System.EventHandler(this.addDiscount_Click);
            // 
            // searchProduct
            // 
            this.searchProduct.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(191)))), ((int)(((byte)(213)))));
            this.searchProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(191)))), ((int)(((byte)(213)))));
            this.searchProduct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.searchProduct.BorderRadius = 0;
            this.searchProduct.ButtonText = "   SEARCH PRODUCTS";
            this.searchProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.searchProduct.DisabledColor = System.Drawing.Color.Gray;
            this.searchProduct.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.searchProduct.Iconcolor = System.Drawing.Color.Transparent;
            this.searchProduct.Iconimage = ((System.Drawing.Image)(resources.GetObject("searchProduct.Iconimage")));
            this.searchProduct.Iconimage_right = null;
            this.searchProduct.Iconimage_right_Selected = null;
            this.searchProduct.Iconimage_Selected = null;
            this.searchProduct.IconMarginLeft = 0;
            this.searchProduct.IconMarginRight = 0;
            this.searchProduct.IconRightVisible = true;
            this.searchProduct.IconRightZoom = 0D;
            this.searchProduct.IconVisible = true;
            this.searchProduct.IconZoom = 50D;
            this.searchProduct.IsTab = false;
            this.searchProduct.Location = new System.Drawing.Point(-1, 47);
            this.searchProduct.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.searchProduct.Name = "searchProduct";
            this.searchProduct.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(191)))), ((int)(((byte)(213)))));
            this.searchProduct.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(190)))), ((int)(((byte)(17)))));
            this.searchProduct.OnHoverTextColor = System.Drawing.Color.White;
            this.searchProduct.selected = false;
            this.searchProduct.Size = new System.Drawing.Size(331, 47);
            this.searchProduct.TabIndex = 15;
            this.searchProduct.Text = "   SEARCH PRODUCTS";
            this.searchProduct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.searchProduct.Textcolor = System.Drawing.Color.White;
            this.searchProduct.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchProduct.Click += new System.EventHandler(this.searchProduct_Click);
            // 
            // newTransaction
            // 
            this.newTransaction.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(190)))), ((int)(((byte)(17)))));
            this.newTransaction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(191)))), ((int)(((byte)(213)))));
            this.newTransaction.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.newTransaction.BorderRadius = 0;
            this.newTransaction.ButtonText = "   NEW TRANSACTION";
            this.newTransaction.Cursor = System.Windows.Forms.Cursors.Hand;
            this.newTransaction.DisabledColor = System.Drawing.Color.Gray;
            this.newTransaction.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newTransaction.Iconcolor = System.Drawing.Color.Transparent;
            this.newTransaction.Iconimage = ((System.Drawing.Image)(resources.GetObject("newTransaction.Iconimage")));
            this.newTransaction.Iconimage_right = null;
            this.newTransaction.Iconimage_right_Selected = null;
            this.newTransaction.Iconimage_Selected = null;
            this.newTransaction.IconMarginLeft = 0;
            this.newTransaction.IconMarginRight = 0;
            this.newTransaction.IconRightVisible = true;
            this.newTransaction.IconRightZoom = 0D;
            this.newTransaction.IconVisible = true;
            this.newTransaction.IconZoom = 50D;
            this.newTransaction.IsTab = false;
            this.newTransaction.Location = new System.Drawing.Point(0, 1);
            this.newTransaction.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.newTransaction.Name = "newTransaction";
            this.newTransaction.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(191)))), ((int)(((byte)(213)))));
            this.newTransaction.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(190)))), ((int)(((byte)(17)))));
            this.newTransaction.OnHoverTextColor = System.Drawing.Color.White;
            this.newTransaction.selected = false;
            this.newTransaction.Size = new System.Drawing.Size(331, 47);
            this.newTransaction.TabIndex = 8;
            this.newTransaction.Text = "   NEW TRANSACTION";
            this.newTransaction.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.newTransaction.Textcolor = System.Drawing.Color.White;
            this.newTransaction.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newTransaction.Click += new System.EventHandler(this.newTransaction_Click);
            // 
            // dataGridTransaction
            // 
            this.dataGridTransaction.AllowUserToAddRows = false;
            this.dataGridTransaction.BackgroundColor = System.Drawing.Color.White;
            this.dataGridTransaction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridTransaction.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column7,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.removeqty,
            this.addqty,
            this.Delete});
            this.dataGridTransaction.Location = new System.Drawing.Point(20, 187);
            this.dataGridTransaction.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridTransaction.Name = "dataGridTransaction";
            this.dataGridTransaction.RowHeadersWidth = 51;
            this.dataGridTransaction.Size = new System.Drawing.Size(1369, 330);
            this.dataGridTransaction.TabIndex = 1;
            this.dataGridTransaction.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridTransaction_CellContentClick);
            this.dataGridTransaction.SelectionChanged += new System.EventHandler(this.dataGridTransaction_SelectionChanged);
            // 
            // Column1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column1.HeaderText = "#";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 125;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "PRODUCT #";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.Width = 125;
            // 
            // Column2
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column2.HeaderText = "DESCRIPTION";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 310;
            // 
            // Column3
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column3.HeaderText = "PRICE";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 125;
            // 
            // Column4
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column4.HeaderText = "QTY";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 125;
            // 
            // Column5
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Column5.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column5.HeaderText = "DISCOUNT";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Width = 125;
            // 
            // Column6
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Column6.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column6.HeaderText = "TOTAL";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.Width = 125;
            // 
            // removeqty
            // 
            this.removeqty.HeaderText = "";
            this.removeqty.Image = ((System.Drawing.Image)(resources.GetObject("removeqty.Image")));
            this.removeqty.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.removeqty.MinimumWidth = 6;
            this.removeqty.Name = "removeqty";
            this.removeqty.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.removeqty.Width = 20;
            // 
            // addqty
            // 
            this.addqty.HeaderText = "";
            this.addqty.Image = ((System.Drawing.Image)(resources.GetObject("addqty.Image")));
            this.addqty.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.addqty.MinimumWidth = 6;
            this.addqty.Name = "addqty";
            this.addqty.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.addqty.Width = 20;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "";
            this.Delete.Image = ((System.Drawing.Image)(resources.GetObject("Delete.Image")));
            this.Delete.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.Delete.MinimumWidth = 6;
            this.Delete.Name = "Delete";
            this.Delete.Width = 20;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtQty);
            this.panel4.Controls.Add(this.textBox6);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.date);
            this.panel4.Controls.Add(this.Transactionlbl);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Location = new System.Drawing.Point(20, 16);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1367, 164);
            this.panel4.TabIndex = 2;
            // 
            // txtQty
            // 
            this.txtQty.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQty.ForeColor = System.Drawing.Color.Gray;
            this.txtQty.Location = new System.Drawing.Point(795, 103);
            this.txtQty.Margin = new System.Windows.Forms.Padding(4);
            this.txtQty.Name = "txtQty";
            this.txtQty.ReadOnly = true;
            this.txtQty.Size = new System.Drawing.Size(49, 39);
            this.txtQty.TabIndex = 14;
            this.txtQty.Text = "1";
            this.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox6
            // 
            this.textBox6.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox6.Location = new System.Drawing.Point(208, 103);
            this.textBox6.Margin = new System.Windows.Forms.Padding(4);
            this.textBox6.MaxLength = 14;
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(577, 39);
            this.textBox6.TabIndex = 13;
            this.textBox6.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(40, 111);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(129, 28);
            this.label9.TabIndex = 12;
            this.label9.Text = "Identification :";
            // 
            // date
            // 
            this.date.AutoSize = true;
            this.date.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date.Location = new System.Drawing.Point(203, 64);
            this.date.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(142, 28);
            this.date.TabIndex = 11;
            this.date.Text = "0000000000000";
            // 
            // Transactionlbl
            // 
            this.Transactionlbl.AutoSize = true;
            this.Transactionlbl.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Transactionlbl.ForeColor = System.Drawing.Color.Red;
            this.Transactionlbl.Location = new System.Drawing.Point(203, 26);
            this.Transactionlbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Transactionlbl.Name = "Transactionlbl";
            this.Transactionlbl.Size = new System.Drawing.Size(142, 28);
            this.Transactionlbl.TabIndex = 10;
            this.Transactionlbl.Text = "0000000000000";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(40, 64);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 28);
            this.label8.TabIndex = 9;
            this.label8.Text = "Date :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(40, 23);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(145, 28);
            this.label7.TabIndex = 8;
            this.label7.Text = "Transaction No :";
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.White;
            this.MainPanel.Controls.Add(this.panel4);
            this.MainPanel.Controls.Add(this.dataGridTransaction);
            this.MainPanel.Controls.Add(this.panel3);
            this.MainPanel.Controls.Add(this.panel6);
            this.MainPanel.Location = new System.Drawing.Point(-4, 89);
            this.MainPanel.Margin = new System.Windows.Forms.Padding(4);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1728, 756);
            this.MainPanel.TabIndex = 31;
            // 
            // frmPOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1723, 844);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.MainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmPOS";
            this.Text = "User";
            this.Load += new System.EventHandler(this.POS_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTransaction)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.MainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblDisplayTotal;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label currentDate;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label Time;
        public System.Windows.Forms.TextBox lblvatable;
        public System.Windows.Forms.TextBox vatlbl;
        public System.Windows.Forms.TextBox txtdiscount;
        public System.Windows.Forms.TextBox total_sales;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuFlatButton2;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuFlatButton1;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel8;
        public Bunifu.Framework.UI.BunifuFlatButton Logout;
        private Bunifu.Framework.UI.BunifuFlatButton dailySales;
        private Bunifu.Framework.UI.BunifuFlatButton searchProduct;
        private Bunifu.Framework.UI.BunifuFlatButton newTransaction;
        public System.Windows.Forms.DataGridView dataGridTransaction;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewImageColumn removeqty;
        private System.Windows.Forms.DataGridViewImageColumn addqty;
        private System.Windows.Forms.DataGridViewImageColumn Delete;
        private System.Windows.Forms.Panel panel4;
        public System.Windows.Forms.TextBox txtQty;
        public System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.Label date;
        public System.Windows.Forms.Label Transactionlbl;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel MainPanel;
        private Bunifu.Framework.UI.BunifuFlatButton btn_recovery;
        public Bunifu.Framework.UI.BunifuFlatButton settlePayment;
        public Bunifu.Framework.UI.BunifuFlatButton addDiscount;


    }
}