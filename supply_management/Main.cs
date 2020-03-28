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
    public partial class Main : Form
    {
        private int moveStart;
        private int moveStartX;
        private int moveStartY;
        Form1 form = new Form1();
        Register reg = new Register();
        frmCategory category = new frmCategory();
        frmBrand brand = new frmBrand();
        frmProduct product = new frmProduct();
        frmStock stock = new frmStock();
        

        Controller.userAccount uses = new Controller.userAccount();
        Controller.productController prod = new Controller.productController();
        Controller.stocksController stocks = new Controller.stocksController();

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

        public void Register()
        {
            Register reg = new Register();
            reg.Show();
        }

        public Main(String message)
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            user.Text = message;
        }

        private void Mousestart()
        {
            if (moveStart == 1)
            {
                this.SetDesktopLocation(MousePosition.X - moveStartX, MousePosition.Y - moveStartY);
            }
        }



        private void loadTextBox()
        {
            CountEmployee.Text = uses.countRegistered().ToString();
            countInventory.Text = prod.count().ToString();
            countStocks.Text = stocks.countStocks().ToString();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            MainPanel.AutoScroll = true;
            loadTextBox();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            moveStart = 1;
            moveStartX = e.X;
            moveStartY = e.Y;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            moveStart = 0;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            Mousestart();
        }

        private void Option_onItemSelected(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Register();
        }

        private void panel24_MouseClick(object sender, MouseEventArgs e)
        {
            Register();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            Register();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            
            reg.TopLevel = false;
            MainPanel.Controls.Add(reg);
            reg.BringToFront();
            reg.Show();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            MainPanel.Controls.Remove(reg);
            MainPanel.Controls.Remove(category);
            MainPanel.Controls.Remove(brand);
            MainPanel.Controls.Remove(product);
            MainPanel.Controls.Remove(stock);

            loadTextBox();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            product.TopLevel = false;
            MainPanel.Controls.Add(product);
            product.BringToFront();
            product.Show();
            product.getData();
        }

        private void panel24_Click(object sender, EventArgs e)
        {
            
        }

        private void ManageCategory_Click(object sender, EventArgs e)
        {
            category.TopLevel = false;
            MainPanel.Controls.Add(category);
            category.BringToFront();
            category.Show();
        }

        private void ManageBrand_Click(object sender, EventArgs e)
        {
            brand.TopLevel = false;
            MainPanel.Controls.Add(brand);
            brand.BringToFront();
            brand.Show();
        }
        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            stock.TopLevel = false;
            MainPanel.Controls.Add(stock);
            stock.BringToFront();
            stock.Show();
        }

        private void panel11_MouseMove(object sender, MouseEventArgs e)
        {
            Mousestart();
        }

        private void panel11_MouseUp(object sender, MouseEventArgs e)
        {
            moveStart = 0;
        }

        private void panel11_MouseDown(object sender, MouseEventArgs e)
        {
            moveStart = 1;
            moveStartX = e.X;
            moveStartY = e.Y;
        }


        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            frmPOS sale = new frmPOS(user.Text);
            sale.Logout.Hide();
            sale.Show();
            this.Hide();
        }

        private void bunifuFlatButton3_Click_1(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }
    }
}
