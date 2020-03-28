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

namespace supply_management
{
    public partial class EmployeeReg : Form
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
        Register register;
        public EmployeeReg(Register reg)
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            register = reg;
        }

        private void EmployeeReg_Load(object sender, EventArgs e)
        {
            Random rand = new Random();
            int ratio = 012345;
            int ran = rand.Next(1, 1000);
            id = ran * ratio + "2020";

            password.UseSystemPasswordChar = true;
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
            Register reg = new Register();
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
                    register.getData();
                }
                 
            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
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

             user.update(Id.Text, text, combo, this);
             register.getData();
           
        }

        private void checkedDelete_OnChange(object sender, EventArgs e)
        {
            if (checkedDelete.Checked == true)
            {
                user.isDelete(Id.Text, this);
                register.getData();
            }
        }
    }
}
