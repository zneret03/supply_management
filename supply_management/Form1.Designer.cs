﻿namespace supply_management
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.username = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.password = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.Login = new Bunifu.Framework.UI.BunifuFlatButton();
            this.Cancel = new Bunifu.Framework.UI.BunifuFlatButton();
            this.showPassword = new Bunifu.Framework.UI.BunifuCheckbox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1060, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "x";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(703, 73);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(237, 46);
            this.label2.TabIndex = 2;
            this.label2.Text = "GEBZ Bikehub";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(0, -1);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1100, 49);
            this.panel2.TabIndex = 3;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseMove);
            this.panel2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(647, 121);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(355, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Make sure you remember your password";
            // 
            // username
            // 
            this.username.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.username.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.username.HintForeColor = System.Drawing.Color.Empty;
            this.username.HintText = "";
            this.username.isPassword = false;
            this.username.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(44)))), ((int)(((byte)(122)))));
            this.username.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.username.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(44)))), ((int)(((byte)(122)))));
            this.username.LineThickness = 4;
            this.username.Location = new System.Drawing.Point(643, 186);
            this.username.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(381, 41);
            this.username.TabIndex = 1;
            this.username.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // password
            // 
            this.password.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.password.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.password.HintForeColor = System.Drawing.Color.Empty;
            this.password.HintText = "";
            this.password.isPassword = false;
            this.password.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(44)))), ((int)(((byte)(122)))));
            this.password.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.password.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(44)))), ((int)(((byte)(122)))));
            this.password.LineThickness = 4;
            this.password.Location = new System.Drawing.Point(643, 262);
            this.password.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(381, 41);
            this.password.TabIndex = 2;
            this.password.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.password.OnValueChanged += new System.EventHandler(this.password_OnValueChanged);
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel3.BackgroundImage")));
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Location = new System.Drawing.Point(595, 190);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(40, 37);
            this.panel3.TabIndex = 5;
            // 
            // panel4
            // 
            this.panel4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel4.BackgroundImage")));
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.Location = new System.Drawing.Point(595, 265);
            this.panel4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(40, 37);
            this.panel4.TabIndex = 6;
            // 
            // Login
            // 
            this.Login.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(61)))), ((int)(((byte)(86)))));
            this.Login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(44)))), ((int)(((byte)(122)))));
            this.Login.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Login.BorderRadius = 7;
            this.Login.ButtonText = "Login";
            this.Login.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Login.DisabledColor = System.Drawing.Color.Gray;
            this.Login.Iconcolor = System.Drawing.Color.Transparent;
            this.Login.Iconimage = null;
            this.Login.Iconimage_right = null;
            this.Login.Iconimage_right_Selected = null;
            this.Login.Iconimage_Selected = null;
            this.Login.IconMarginLeft = 0;
            this.Login.IconMarginRight = 0;
            this.Login.IconRightVisible = true;
            this.Login.IconRightZoom = 0D;
            this.Login.IconVisible = true;
            this.Login.IconZoom = 90D;
            this.Login.IsTab = false;
            this.Login.Location = new System.Drawing.Point(643, 353);
            this.Login.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Login.Name = "Login";
            this.Login.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(44)))), ((int)(((byte)(122)))));
            this.Login.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(72)))), ((int)(((byte)(156)))));
            this.Login.OnHoverTextColor = System.Drawing.Color.White;
            this.Login.selected = false;
            this.Login.Size = new System.Drawing.Size(391, 42);
            this.Login.TabIndex = 8;
            this.Login.Text = "Login";
            this.Login.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Login.Textcolor = System.Drawing.Color.White;
            this.Login.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Login.Click += new System.EventHandler(this.Login_Click);
            // 
            // Cancel
            // 
            this.Cancel.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.Cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(72)))), ((int)(((byte)(156)))));
            this.Cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Cancel.BorderRadius = 7;
            this.Cancel.ButtonText = "Exit";
            this.Cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Cancel.DisabledColor = System.Drawing.Color.Gray;
            this.Cancel.Iconcolor = System.Drawing.Color.Transparent;
            this.Cancel.Iconimage = null;
            this.Cancel.Iconimage_right = null;
            this.Cancel.Iconimage_right_Selected = null;
            this.Cancel.Iconimage_Selected = null;
            this.Cancel.IconMarginLeft = 0;
            this.Cancel.IconMarginRight = 0;
            this.Cancel.IconRightVisible = true;
            this.Cancel.IconRightZoom = 0D;
            this.Cancel.IconVisible = true;
            this.Cancel.IconZoom = 90D;
            this.Cancel.IsTab = false;
            this.Cancel.Location = new System.Drawing.Point(643, 410);
            this.Cancel.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Cancel.Name = "Cancel";
            this.Cancel.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(72)))), ((int)(((byte)(156)))));
            this.Cancel.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(44)))), ((int)(((byte)(122)))));
            this.Cancel.OnHoverTextColor = System.Drawing.Color.White;
            this.Cancel.selected = false;
            this.Cancel.Size = new System.Drawing.Size(391, 42);
            this.Cancel.TabIndex = 9;
            this.Cancel.Text = "Exit";
            this.Cancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Cancel.Textcolor = System.Drawing.Color.White;
            this.Cancel.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // showPassword
            // 
            this.showPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.showPassword.ChechedOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.showPassword.Checked = false;
            this.showPassword.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(205)))), ((int)(((byte)(117)))));
            this.showPassword.ForeColor = System.Drawing.Color.White;
            this.showPassword.Location = new System.Drawing.Point(1033, 273);
            this.showPassword.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.showPassword.Name = "showPassword";
            this.showPassword.Size = new System.Drawing.Size(20, 20);
            this.showPassword.TabIndex = 10;
            this.showPassword.OnChange += new System.EventHandler(this.bunifuCheckbox1_OnChange);
            // 
            // panel5
            // 
            this.panel5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel5.BackgroundImage")));
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel5.Location = new System.Drawing.Point(71, 66);
            this.panel5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(439, 389);
            this.panel5.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1095, 511);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.showPassword);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.password);
            this.Controls.Add(this.username);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label2);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private Bunifu.Framework.UI.BunifuFlatButton Login;
        private Bunifu.Framework.UI.BunifuFlatButton Cancel;
        private Bunifu.Framework.UI.BunifuCheckbox showPassword;
        private System.Windows.Forms.Panel panel5;
        public Bunifu.Framework.UI.BunifuMaterialTextbox username;
        public Bunifu.Framework.UI.BunifuMaterialTextbox password;
    }
}

