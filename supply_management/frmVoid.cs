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
    public partial class frmVoid : Form
    {
        int moveStart;
        int moveStartX;
        int moveStartY;

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
        frmcancelSales cancelSales;
        public frmVoid(frmcancelSales cancel)
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            cancelSales = cancel;
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

        private void frmVoid_Load(object sender, EventArgs e)
        {
            this.voidPassword.UseSystemPasswordChar = true;
        }

        private void submit_Click(object sender, EventArgs e)
        {
            try
            {
                if(voidPassword.Text != string.Empty)
                {
                    TextBox[] cancel = new TextBox[]
                    {
                        cancelSales.txtId,
                        cancelSales.txtpcode,
                        cancelSales.txtqty,
                        cancelSales.txtcancelledBy,
                        cancelSales.txtreasons,
                        cancelSales.txtcancelQty,
                        cancelSales.txtprice
                        
                    };

                    ComboBox[] inventory = new ComboBox[]{ cancelSales.inventory };
                    pos.cancelItems(voidUsername.Text, voidPassword.Text, cancel, inventory);
                    cancelSales.refreshRecords();
                    cancelSales.Hide();
                    this.Hide();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
