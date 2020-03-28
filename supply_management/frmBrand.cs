using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace supply_management
{
    public partial class frmBrand : Form
    {
        Controller.BrandController brand = new Controller.BrandController();
        public frmBrand()
        {
            InitializeComponent();
        }

        private void Brand_Load(object sender, EventArgs e)
        {

            dataGridBrand.BorderStyle = BorderStyle.None;
            dataGridBrand.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridBrand.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridBrand.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridBrand.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;

            dataGridBrand.EnableHeadersVisualStyles = false;
            dataGridBrand.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridBrand.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(54, 54, 54);
            dataGridBrand.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridBrand.ColumnHeadersDefaultCellStyle.Padding = new Padding(0, 7, 0, 7);

            getData();
        }

        public void getData()
        {
            dataGridBrand.DataSource = brand.getData();
            dataGridBrand.Columns[0].Width = 150;
            dataGridBrand.Columns[1].Width = 500;
            dataGridBrand.Columns[2].Width = 150;
            dataGridBrand.Columns[3].Width = 150;

            dataGridBrand.Columns[0].HeaderText = "#";
            dataGridBrand.Columns[1].HeaderText = "Brand name";
            dataGridBrand.Columns[2].HeaderText = "Date Created";
            dataGridBrand.Columns[3].HeaderText = "Date Updated";
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            addBrand add = new addBrand(this);
            add.Show();
            add.ID.Hide();
            add.btnUpdate.Enabled = false;
            add.checkDelete.Hide();
            add.label4.Hide();
        }

        private void dataGridBrand_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            addBrand add = new addBrand(this);
            if(e.RowIndex >= 0)
            {
                DataGridViewRow dt = this.dataGridBrand.Rows[e.RowIndex];
                add.ID.Text = dt.Cells[0].Value.ToString();
                add.txtBrand.Text = dt.Cells[1].Value.ToString();
                add.submit.Enabled = false;
                add.ID.Hide();
                add.Show();
            }
        }

        private void txtSearch_OnTextChange(object sender, EventArgs e)
        {
           dataGridBrand.DataSource = brand.getDataSearch(txtSearch.text);
        }
    }
}
