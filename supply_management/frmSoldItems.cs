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
                dataGridSoldItems.Rows.Clear();

                using (MySqlDataReader reader =  pos.showSoldItems(dateTimePicker1.Value.ToLongDateString(), dateTimePicker2.Value.ToLongDateString(), username.Text))
                {
                    while (reader.Read())
                    {
                        total += Convert.ToDouble(reader["total"].ToString());
                        dataGridSoldItems.Rows.Add(reader["transaction_id"].ToString(),
                            reader["transactionNo"].ToString(),
                            reader["products_id"].ToString(),
                            reader["description"].ToString(),
                            reader["price"].ToString(),
                            reader["quantity"].ToString(),
                            reader["discount"].ToString(),
                            reader["total"].ToString());
                    }
                }
                totalSales.Text = total.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
             

        }


        private void frmSoldItems_Load(object sender, EventArgs e)
        {
            loadSoldItems();
            ComboBox[] items = new ComboBox[] { username };
            pos.loadusername(items[0]);
            dataGridSoldItems.BorderStyle = BorderStyle.None;
            dataGridSoldItems.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridSoldItems.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridSoldItems.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridSoldItems.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;

            dataGridSoldItems.EnableHeadersVisualStyles = false;
            dataGridSoldItems.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridSoldItems.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(54, 54, 54);
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
    }
}
