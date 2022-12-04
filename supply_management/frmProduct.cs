using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace supply_management
{
    public partial class frmProduct : Form
    {
        Controller.productController product = new Controller.productController();
        Controller.ErrorHandler error = new Controller.ErrorHandler();
        public frmProduct()
        {
            InitializeComponent();
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {

            dataGridProducts.BorderStyle = BorderStyle.None;
            dataGridProducts.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridProducts.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridProducts.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridProducts.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;

            dataGridProducts.EnableHeadersVisualStyles = false;
            dataGridProducts.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridProducts.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(67, 44, 122);
            dataGridProducts.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridProducts.ColumnHeadersDefaultCellStyle.Padding = new Padding(0, 7, 0, 7);

            getData();
        }

        public void getData()
        {
            dataGridProducts.DataSource = product.loadDataGrid();

            dataGridProducts.Columns[0].Width = 150;
            dataGridProducts.Columns[1].Width = 150;
            dataGridProducts.Columns[2].Width = 150;
            dataGridProducts.Columns[3].Width = 150;
            dataGridProducts.Columns[4].Width = 150;
            dataGridProducts.Columns[5].Width = 200;
            dataGridProducts.Columns[6].Width = 100;
            dataGridProducts.Columns[7].Width = 100;
            dataGridProducts.Columns[8].Width = 150;
            dataGridProducts.Columns[9].Width = 150;
            dataGridProducts.Columns[10].Width = 150;
            dataGridProducts.Columns[11].Width = 150;
            dataGridProducts.Columns[12].Width = 150;
            dataGridProducts.Columns[13].Width = 150;

            dataGridProducts.Columns[0].HeaderText = "#";
            dataGridProducts.Columns[1].HeaderText = "IDENTIFICATION";
            dataGridProducts.Columns[2].HeaderText = "PRODUCT NAME";
            dataGridProducts.Columns[3].HeaderText = "CATEGORY NAME";
            dataGridProducts.Columns[4].HeaderText = "BRAND NAME";
            dataGridProducts.Columns[5].HeaderText = "DESCRIPTION";
            dataGridProducts.Columns[6].HeaderText = "QUANTITY";
            dataGridProducts.Columns[7].HeaderText = "PRICE";
            dataGridProducts.Columns[8].HeaderText = "REORDER";
            dataGridProducts.Columns[8].Visible = false;
            dataGridProducts.Columns[9].HeaderText = "CAPITAL";
            dataGridProducts.Columns[10].HeaderText = "GAIN";
            dataGridProducts.Columns[11].HeaderText = "PERCENTAGE";
            dataGridProducts.Columns[12].HeaderText = "DATE CREATED";
            dataGridProducts.Columns[13].HeaderText = "DATE UPDATED";
        }

        private void txtSearch_OnTextChange(object sender, EventArgs e)
        {
            dataGridProducts.DataSource = product.searchData(txtSearch.text);
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            addProducts products = new addProducts(this);
            products.checkDelete.Hide();
            products.IdLabel.Hide();
            products.label5.Hide();
            String value = error.GenerateNumber(8);

            products.barcode.Text = "1111" + value.ToString();
            products.Show();
            products.btnUpdate.Enabled = false;

        }

        private void dataGridProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            addProducts add = new addProducts(this);
            if(e.RowIndex >= 0)
            {
                DataGridViewRow dt = this.dataGridProducts.Rows[e.RowIndex];

                add.IdLabel.Text = dt.Cells[0].Value.ToString();
                add.barcode.Text = dt.Cells[1].Value.ToString();
                add.productName.Text = dt.Cells[2].Value.ToString();
                add.categoryName.Text = dt.Cells[3].Value.ToString();
                add.brandName.Text = dt.Cells[4].Value.ToString();
                add.description.Text = dt.Cells[5].Value.ToString();
                add.quantity.Text = dt.Cells[6].Value.ToString();
                add.price.Text = dt.Cells[7].Value.ToString();
                add.capital.Text = dt.Cells[9].Value.ToString();
                add.gain.Text = dt.Cells[10].Value.ToString();
                add.txtPercentage.Text = dt.Cells[11].Value.ToString();

                add.submit.Enabled = false;
                add.checkDelete.Show();
                add.IdLabel.Hide();
                add.Show();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            getData();
            timer1.Start();
        }
    }
}
