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
    public partial class ProductLookUp : Form
    {
        int moveStart;
        int moveStartX;
        int moveStarY;

        public String pcode;
        public double price;

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
        frmPOS f;
        public ProductLookUp(frmPOS form)
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            f = form;
            
        }

        private void ProductLookUp_Load(object sender, EventArgs e)
        {

            dataLookup.BorderStyle = BorderStyle.None;
            dataLookup.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataLookup.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataLookup.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataLookup.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;

            dataLookup.EnableHeadersVisualStyles = false;
            dataLookup.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataLookup.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(54, 54, 54);
            dataLookup.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataLookup.ColumnHeadersDefaultCellStyle.Padding = new Padding(0, 7, 0, 7);
            getData();
        }

        public void getData()
        {
            dataLookup.DataSource = pos.loadProductLookup();

            dataLookup.Columns[0].Width = 150;
            dataLookup.Columns[1].Width = 150;
            dataLookup.Columns[2].Width = 150;
            dataLookup.Columns[3].Width = 150;
            dataLookup.Columns[4].Width = 150;
            dataLookup.Columns[5].Width = 150;
            dataLookup.Columns[6].Width = 150;
            dataLookup.Columns[7].Width = 150;

            dataLookup.Columns[0].HeaderText = "#";
            dataLookup.Columns[1].HeaderText = "BARCODE";
            dataLookup.Columns[2].HeaderText = "PRODUCT NAME";
            dataLookup.Columns[3].HeaderText = "CATEGORY NAME";
            dataLookup.Columns[4].HeaderText = "BRAND NAME";
            dataLookup.Columns[5].HeaderText = "DESCRIPTION";
            dataLookup.Columns[6].HeaderText = "QTY";
            dataLookup.Columns[7].HeaderText = "PRICE";
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(moveStart == 1)
            {
                this.SetDesktopLocation(MousePosition.X - moveStartX, MousePosition.Y - moveStarY);
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            moveStart = 1;
            moveStartX = e.X;
            moveStarY = e.Y;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            moveStart = 0;
        }

        private void txtSearch_OnTextChange(object sender, EventArgs e)
        {
            dataLookup.DataSource = pos.SearchProducts(txtSearch.text);
        }

        private void dataLookup_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)   
            {
                DataGridViewRow dt = this.dataLookup.Rows[e.RowIndex];
                f.product(dt.Cells[0].Value.ToString(), Convert.ToDouble(dt.Cells[7].Value.ToString()));
                frmQuantity quantity = new frmQuantity(f);
                quantity.Show();
            }
        }

    }
}
