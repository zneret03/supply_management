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
    public partial class frmCategory : Form
    {
        Controller.CategoryController category = new Controller.CategoryController();
        
        public frmCategory()
        {
            InitializeComponent();
        }

        private void Category_Load(object sender, EventArgs e)
        {
            
            dataGridCategory.BorderStyle = BorderStyle.None;
            dataGridCategory.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridCategory.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridCategory.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridCategory.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;

            dataGridCategory.EnableHeadersVisualStyles = false;
            dataGridCategory.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridCategory.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(54 ,54 ,54);
            dataGridCategory.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridCategory.ColumnHeadersDefaultCellStyle.Padding = new Padding(0, 7, 0, 7);

            getData();
        }

        public void getData()
        {
            try
            {
                dataGridCategory.DataSource = category.loadCategory();
                dataGridCategory.Columns[0].Width = 150;
                dataGridCategory.Columns[1].Width = 500;
                dataGridCategory.Columns[2].Width = 150;
                dataGridCategory.Columns[3].Width = 150;

                dataGridCategory.Columns[0].HeaderText = "#";
                dataGridCategory.Columns[1].HeaderText = "Category";
                dataGridCategory.Columns[2].HeaderText = "Date created";
                dataGridCategory.Columns[3].HeaderText = "Date updated";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
        }

        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
            addCategory addCategory = new addCategory(this);
            addCategory.btnUpdate.Enabled = false;
            addCategory.Show();
        }

        private void dataGridCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            addCategory add = new addCategory(this);
            if(e.RowIndex >= 0)
            {
                DataGridViewRow dt = this.dataGridCategory.Rows[e.RowIndex];
                add.ID.Text = dt.Cells[0].Value.ToString();
                add.txtCategory.Text = dt.Cells[1].Value.ToString();
                add.submit.Enabled = false;
                add.btnUpdate.Enabled = true;
                add.Show();
                add.label4.Show();
                add.checkDelete.Show();
            }
        }

        private void categorySearch_OnTextChange(object sender, EventArgs e)
        {
            dataGridCategory.DataSource = category.search(categorySearch.text);
        }
    }
}
