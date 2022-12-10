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
    public partial class frmSoldItems : Form
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
        public frmSoldItems()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
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

        public void loadSoldItems()
        {
            try
            {
                double total = 0;
                double gain = 0;
                dataGridSoldItems.Rows.Clear();
                using (MySqlDataReader reader = pos.showSoldItems(dateTimePicker1.Value.ToString("yyyy-MM-dd"), dateTimePicker2.Value.ToString("yyyy-MM-dd"), username.Text))
                {
                    while (reader.Read())
                    {
                        total += Convert.ToDouble(reader["total"].ToString());
                        gain += Convert.ToDouble(reader["totalGain"].ToString());

                        dataGridSoldItems.Rows.Add(reader["transaction_id"].ToString(),
                            reader["transactionNo"].ToString(),
                            reader["products_id"].ToString(),
                            reader["product_name"].ToString(),
                            reader["quantity"].ToString(),
                            reader["price"].ToString(),
                            reader["total"].ToString(),
                            reader["discount"].ToString(),
                            reader["totalGain"].ToString());
                    }
                }
                totalSales.Text = total.ToString("#,##0.00");
                totalGain.Text = gain.ToString("#,##0.00");
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmSoldItems_Load(object sender, EventArgs e)
        {
            loadSoldItems();
            username.Items.Add("all cashier sales");
            ComboBox[] items = new ComboBox[] { username };
            pos.loadusername(items[0]);
            dataGridSoldItems.BorderStyle = BorderStyle.None;
            dataGridSoldItems.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridSoldItems.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridSoldItems.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridSoldItems.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;

            dataGridSoldItems.EnableHeadersVisualStyles = false;
            dataGridSoldItems.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridSoldItems.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(67, 44, 122);
            dataGridSoldItems.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridSoldItems.ColumnHeadersDefaultCellStyle.Padding = new Padding(0, 6, 0, 6);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            loadSoldItems();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            loadSoldItems();
        }

        private void submit_Click(object sender, EventArgs e)
        {
            frmPrintSales print = new frmPrintSales(this);
            print.Show();
            print.loadPrintSaleData();
        }

        private void username_SelectedValueChanged(object sender, EventArgs e)
        {
            loadSoldItems();
        }

        private void dataGridSoldItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String colName = dataGridSoldItems.Columns[e.ColumnIndex].Name;
            
            if(colName == "Cancel")
            {
               
                frmcancelSales cancel = new frmcancelSales(this);
                cancel.txtId.Text = dataGridSoldItems.Rows[e.RowIndex].Cells[0].Value.ToString();
                cancel.txttransactioNo.Text = dataGridSoldItems.Rows[e.RowIndex].Cells[1].Value.ToString();
                cancel.txtpcode.Text = dataGridSoldItems.Rows[e.RowIndex].Cells[2].Value.ToString();
                cancel.txtdescription.Text = dataGridSoldItems.Rows[e.RowIndex].Cells[3].Value.ToString();
                cancel.txtqty.Text = dataGridSoldItems.Rows[e.RowIndex].Cells[4].Value.ToString();
                cancel.txtprice.Text = dataGridSoldItems.Rows[e.RowIndex].Cells[5].Value.ToString();
                cancel.txttotal.Text = dataGridSoldItems.Rows[e.RowIndex].Cells[6].Value.ToString();
                cancel.txtdiscount.Text = dataGridSoldItems.Rows[e.RowIndex].Cells[7].Value.ToString();

                cancel.txtcancelledBy.Text = username.Text;

                cancel.Show();
            }
        }

        private void username_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void totalGain_Click(object sender, EventArgs e)
        {

        }
    }
}
