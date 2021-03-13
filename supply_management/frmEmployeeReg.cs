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
    public partial class frmEmployeeReg : Form
    {
        Controller.userAccount user = new Controller.userAccount();
        private int moveStart;
        private int moveStartX;
        private int moveStartY;
        String id;
 
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

        Main min;
        public frmEmployeeReg(Main main)
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            min = main;
            //MessageBox.Show(min.user.Text);
        }

        public void SelectDeleteUser()
        {
            try
            {
                using(MySqlDataReader reader = user.getuserData(txtUsername.Text))
                {
                    while(reader.Read())
                    {
                        String usertype = reader["usertype"].ToString();
                        if(usertype == "Employee")
                        {
                            lblId.Text = reader["user_id"].ToString();
                            txtPassword.Text = reader["password"].ToString();
                            txtFirstName.Text = reader["fname"].ToString();
                            txtMiddleName.Text = reader["mname"].ToString();
                            txtLastName.Text = reader["lname"].ToString();
                            txtAddress.Text = reader["address"].ToString();
                            txtAge.Text = reader["age"].ToString();
                            cmbGender.Text = reader["gender"].ToString();
                            cmbUsertype.Text = reader["usertype"].ToString();
                            return;
                        }

                        
                        MessageBox.Show("This is an admin account!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        clearTheWay();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void clearTheWay()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtFirstName.Clear();
            txtMiddleName.Clear();
            txtLastName.Clear();
            txtAddress.Clear();
            txtAge.Clear();

            cmbGender.Items.Clear();
            cmbGender.ResetText();
            cmbUsertype.Items.Clear();
            cmbUsertype.ResetText();
        }

        private void EmployeeReg_Load(object sender, EventArgs e)
        {
            Random rand = new Random();
            int ratio = 012345;
            int ran = rand.Next(1, 1000);
            id = ran * ratio + "2020";

            lblId.Hide();

            password.UseSystemPasswordChar = true;
            txtOldPassword.UseSystemPasswordChar = true;
            txtNewPassword.UseSystemPasswordChar = true;
            txtConfirmPassword.UseSystemPasswordChar = true;
            txtPassword.UseSystemPasswordChar = true;
            cmbGender.Enabled = false;
            cmbUsertype.Enabled = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(moveStart == 1)
            {
                this.SetDesktopLocation(MousePosition.X - moveStartX, MousePosition.Y - moveStartY);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            moveStart = 0;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            moveStart = 1;
            moveStartX = e.X;
            moveStartY = e.Y;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void submit_Click(object sender, EventArgs e)
        {
            TextBox[] text = new TextBox[]
            {
                   username,
                   password,
                   firstname,
                   middlename,
                   Lastname,
                   address,
                   age
            };

            ComboBox[] combo = new ComboBox[]
            {
                Gender,
                usertype
            };

            String ifExist = user.duplicated(text);

            if(ifExist == text[0].Text)
            {
                MessageBox.Show("Username already exist please try another one");
            }
            else
            {
                
                if (usertype.SelectedIndex == -1 || Gender.SelectedIndex == -1)
                {
                    MessageBox.Show("Please check your usertype or gender if empty or not");
                }
                else
                {
                    user.employeeCredentials(id, text, combo);
                }
                 
            }
            
        }

        private void Gender_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void usertype_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {

            try
            {
               
                 String oldPassword = user.getPass(min.user.Text);
                if (oldPassword != txtOldPassword.Text)
                {
                    MessageBox.Show("Your password didnt match!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtNewPassword.Text != txtConfirmPassword.Text)
                {
                    MessageBox.Show("Your new password didnt match!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show("Do you really want to change your password?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                     user.changePass(min.user.Text, txtNewPassword.Text);
                     txtConfirmPassword.Clear();
                     txtNewPassword.Clear();
                     txtOldPassword.Clear();
                }
                else
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //user.update(Id.Text, text, combo, this);
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void panel1_MouseMove_1(object sender, MouseEventArgs e)
        {
            if(moveStart == 1)
            {
                this.SetDesktopLocation(MousePosition.X - moveStartX, MousePosition.Y - moveStartY);
            }
        }

        private void panel1_MouseUp_1(object sender, MouseEventArgs e)
        {
            moveStart = 0;
        }

        private void panel1_MouseDown_1(object sender, MouseEventArgs e)
        {
            moveStart = 1;
            moveStartX = e.X;
            moveStartY = e.Y;
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            
            if(txtUsername.Text == string.Empty)
            {
                clearTheWay();
                return;
            }

            SelectDeleteUser();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            user.DelCashier(lblId.Text, this);
        }
    }
}
