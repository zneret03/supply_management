namespace supply_management
{
    partial class frmVoid
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.voidUsername = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.voidPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.submit = new Bunifu.Framework.UI.BunifuFlatButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(191)))), ((int)(((byte)(213)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(561, 57);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(16, 14);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 28);
            this.label2.TabIndex = 39;
            this.label2.Text = "Confirmation";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(527, 2);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 37);
            this.label1.TabIndex = 38;
            this.label1.Text = "x";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // voidUsername
            // 
            this.voidUsername.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.voidUsername.Location = new System.Drawing.Point(153, 87);
            this.voidUsername.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.voidUsername.Name = "voidUsername";
            this.voidUsername.Size = new System.Drawing.Size(317, 34);
            this.voidUsername.TabIndex = 46;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(28, 90);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 28);
            this.label3.TabIndex = 45;
            this.label3.Text = "Username :";
            // 
            // voidPassword
            // 
            this.voidPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.voidPassword.Location = new System.Drawing.Point(153, 139);
            this.voidPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.voidPassword.Name = "voidPassword";
            this.voidPassword.Size = new System.Drawing.Size(317, 34);
            this.voidPassword.TabIndex = 48;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(28, 142);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 28);
            this.label4.TabIndex = 47;
            this.label4.Text = "Password";
            // 
            // submit
            // 
            this.submit.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(44)))), ((int)(((byte)(122)))));
            this.submit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(44)))), ((int)(((byte)(122)))));
            this.submit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.submit.BorderRadius = 5;
            this.submit.ButtonText = "Void";
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
            this.submit.IconZoom = 90D;
            this.submit.IsTab = false;
            this.submit.Location = new System.Drawing.Point(153, 196);
            this.submit.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.submit.Name = "submit";
            this.submit.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(44)))), ((int)(((byte)(122)))));
            this.submit.OnHovercolor = System.Drawing.Color.Silver;
            this.submit.OnHoverTextColor = System.Drawing.Color.White;
            this.submit.selected = false;
            this.submit.Size = new System.Drawing.Size(319, 50);
            this.submit.TabIndex = 71;
            this.submit.Text = "Void";
            this.submit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.submit.Textcolor = System.Drawing.Color.White;
            this.submit.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submit.Click += new System.EventHandler(this.submit_Click);
            // 
            // frmVoid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(561, 286);
            this.Controls.Add(this.submit);
            this.Controls.Add(this.voidPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.voidUsername);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmVoid";
            this.Text = "frmVoid";
            this.Load += new System.EventHandler(this.frmVoid_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox voidUsername;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox voidPassword;
        private System.Windows.Forms.Label label4;
        public Bunifu.Framework.UI.BunifuFlatButton submit;
    }
}