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
    public partial class frmProductImport : Form
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
        frmStock stock;
        public frmProductImport(frmStock stockss)
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            stock = stockss;
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

        private void frmProductImport_Load(object sender, EventArgs e)
        {
            dataGridProducts.BorderStyle = BorderStyle.None;
            dataGridProducts.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridProducts.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridProducts.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridProducts.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;

            dataGridProducts.EnableHeadersVisualStyles = false;
            dataGridProducts.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridProducts.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(54, 54, 54);
            dataGridProducts.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridProducts.ColumnHeadersDefaultCellStyle.Padding = new Padding(0, 7, 0, 7);

            stock.getDataProducts();
        }

        private void txtSearch_OnTextChange(object sender, EventArgs e)
        {
            dataGridProducts.DataSource = stocks.searchData(txtSearch.text);
        }

        private void dataGridProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String pcode = " ";
            TextBox[] text = new TextBox[]
            {
                stock.referenceNo,
                stock.StockInBy,
                
            };


            if (e.RowIndex >= 0)
            {
                DataGridViewRow dt = dataGridProducts.Rows[e.RowIndex];
                pcode = dt.Cells[0].Value.ToString();
            }

            stocks.insertProduct(pcode, stock, text, stock.stockDate.Value.ToShortDateString(), stock.vendors_id);
        }
    }
}
