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
    public partial class addVendor : Form
    {
        int moveStart;
        int moveStartX;
        int moveStartY;

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
        frmVendor ven;
        public addVendor(frmVendor vendor)
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn((CreateRoundRectRgn(0, 0, Width, Height, 20, 20)));
            ven = vendor;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(moveStart == 1)
            {
                this.SetDesktopLocation(MousePosition.X - moveStartX, MousePosition.Y - moveStartY);
            }
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

        private void submit_Click(object sender, EventArgs e)
        {
            TextBox[] vendors = new TextBox[]
            {
                txtVendors,
                txtAddress,
                txtContact,
                txtTelephone,
                txtEmail,
                txtFax
            };

            stocks.Insvendor(vendors, ven);
        }

        private void addVendor_Load(object sender, EventArgs e)
        {
            lblID.Hide();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            TextBox[] vendors = new TextBox[]
            {
                txtVendors,
                txtAddress,
                txtContact,
                txtTelephone,
                txtEmail,
                txtFax
            };

            stocks.updVendor(vendors, lblID.Text, this);
            ven.loadDataVendor();
        }
    }
}
