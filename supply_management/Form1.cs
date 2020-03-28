using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;

namespace supply_management
{
    public partial class Form1 : Form
    {

        int moveStart;
        int moveStartX;
        int moveStartY;

        Controller.userAccount account = new Controller.userAccount();

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        public void hide()
        {
            this.hide();
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            
            moveStart = 1;
            moveStartX = e.X;
            moveStartY = e.Y;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if(moveStart == 1)
            {
                this.SetDesktopLocation(MousePosition.X - moveStartX, MousePosition.Y - moveStartY);
            }
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            moveStart = 0;
        }

        private void password_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void bunifuCheckbox1_OnChange(object sender, EventArgs e)
        {
            if(showPassword.Checked == true)
            {
                password.isPassword = false;
            }
            else
            {
                password.isPassword = true;
            }
        }

        private void Login_Click(object sender, EventArgs e) 
        {
                
                String[] empty = new String[]
                {
                    username.Text,
                    password.Text
                };

                foreach (String emp in empty)
                {
                    if (string.IsNullOrEmpty(emp))
                    {
                        MessageBox.Show("Please fill the empty fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                    else
                    {
                        account.userCred(username.Text.ToString(), password.Text.ToString(), this);
                        break;
                    }
                }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void password_OnValueChanged(object sender, EventArgs e)
        {
            password.isPassword = true;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            username.Text = string.Empty;
            password.Text = string.Empty;
        }

    }
}
