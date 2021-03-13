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
    public partial class frmdiscount : Form
    {
        int moveStart;
        int moveStartX;
        int moveStartY;

        double totalPrice;
        Controller.ErrorHandler error = new Controller.ErrorHandler();
        Controller.posController pos = new Controller.posController();
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
        frmPOS pointOfSale;
        public frmdiscount(frmPOS pos)
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            pointOfSale = pos;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
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

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (moveStart == 1)
            {
                this.SetDesktopLocation(MousePosition.X - moveStartX, MousePosition.Y - moveStartY);
            }
        }

        private void frmdiscount_Load(object sender, EventArgs e)
        {
            id.Hide();
            lbltotalPrice.Hide();
            
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double discount = Convert.ToDouble(price.Text) * Convert.ToDouble(txtDiscount.Text);
                totalPrice = Convert.ToDouble(lbltotalPrice.Text) - discount;
                discountAmount.Text = discount.ToString("#,##0.00");
            }
            catch(Exception ex)
            {
                discountAmount.Text = "0.00";
            }
        }

        private void submit_Click(object sender, EventArgs e)
        {
                //MessageBox.Show(totalPrice.ToString());
                pos.discount(id.Text, discountAmount.Text, txtDiscount.Text, this, totalPrice);
                pointOfSale.tableShow();
        }
    }
}
