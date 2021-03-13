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
    public partial class frmcancelSales : Form
    {
        int moveStart;
        int moveStartX;
        int moveStartY;


        Controller.BrandController brand = new Controller.BrandController();
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
        frmSoldItems items;
        public frmcancelSales(frmSoldItems sold)
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            items = sold;
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

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void inventory_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        public void refreshRecords()
        {
            items.loadSoldItems();
        }

        private void submit_Click(object sender, EventArgs e)
        {
            try
            {
                if(inventory.Text != string.Empty && txtcancelQty.Text != string.Empty && txtdescription.Text != string.Empty)
                {
                    if(int.Parse(txtqty.Text) >= int.Parse(txtcancelQty.Text))
                    {
                        frmVoid Uservoid = new frmVoid(this);
                        Uservoid.Show();
                        
                    }
                  
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmcancelSales_Load(object sender, EventArgs e)
        {

        }
    }
}
