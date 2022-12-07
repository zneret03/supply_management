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
    public partial class frmStockAdjustment : Form
    {
        int moveStart;
        int moveStartX;
        int moveStartY;

        Controller.posController pos = new Controller.posController();
        Controller.ErrorHandler error = new Controller.ErrorHandler();
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
        Main min;
        public frmStockAdjustment(Main main)
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            min = main;
        }

        public void generateReferenceNo()
        {
            String generate = error.GenerateNumber(3);
            txtReferenceNo.Text = generate + DateTime.Now.Date.ToString("yyyy");
        }
        public void loadProductInventory()
        {
            try
            {
                dataGridStockAdjustment.Rows.Clear();
                int i = 0;
                using (MySqlDataReader reader = pos.loadProductInventory())
                {
                    while (reader.Read())
                    {
                        i++;
                        dataGridStockAdjustment.Rows.Add(i, reader["products_id"].ToString(),
                            reader["product_name"].ToString(),
                            reader["category_name"].ToString(),
                            reader["description"].ToString(),
                            reader["price"].ToString(),
                            reader["quantity"].ToString());
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void searchProductInventory()
        {
            try
            {
                dataGridStockAdjustment.Rows.Clear();
                int i = 0;
                using (MySqlDataReader reader = pos.SearchProductsAdjustment(txtSearch.text))
                {
                    while (reader.Read())
                    {
                        i++;
                        dataGridStockAdjustment.Rows.Add(i, reader["products_id"].ToString(),
                            reader["brand_name"].ToString(),
                            reader["category_name"].ToString(),
                            reader["description"].ToString(),
                            reader["price"].ToString(),
                            reader["quantity"].ToString());
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void frmStockAdjustment_Load(object sender, EventArgs e)
        {
            loadProductInventory();

            generateReferenceNo();

            dataGridStockAdjustment.BorderStyle = BorderStyle.None;
            dataGridStockAdjustment.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridStockAdjustment.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridStockAdjustment.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridStockAdjustment.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;

            dataGridStockAdjustment.EnableHeadersVisualStyles = false;
            dataGridStockAdjustment.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridStockAdjustment.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(67, 44, 122);
            dataGridStockAdjustment.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridStockAdjustment.ColumnHeadersDefaultCellStyle.Padding = new Padding(0, 7, 0, 7);
            txtUsers.Text = min.user.Text;
        }

        private void submit_Click(object sender, EventArgs e)
        {
            TextBox[] adjustment = new TextBox[]
            {
                txtReferenceNo,
                txtPcode,
                txtQty,
                txtRemarks,
                txtUsers
            };

            stocks.stockadjustment(adjustment, cmbCommands.Text);
            generateReferenceNo();
            loadProductInventory();

            txtPcode.Clear();
            txtProductName.Clear();
            txtQty.Clear();
            txtRemarks.Clear();
        }

        private void txtSearch_OnTextChange(object sender, EventArgs e)
        {
            searchProductInventory();
        }

        private void dataGridStockAdjustment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String colName = dataGridStockAdjustment.Columns[e.ColumnIndex].Name;

            if(colName == "import")
            {
                txtPcode.Text = dataGridStockAdjustment.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtProductName.Text = dataGridStockAdjustment.Rows[e.RowIndex].Cells[2].Value.ToString();

                // + " " + dataGridStockAdjustment.Rows[e.RowIndex].Cells[4].Value.ToString() + " " + dataGridStockAdjustment.Rows[e.RowIndex].Cells[5].Value.ToString()
            }
        }
    }
}
