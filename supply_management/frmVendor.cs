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

    public partial class frmVendor : Form
    {
        Controller.stocksController stocks = new Controller.stocksController();
        public frmVendor()
        {
            InitializeComponent();
        }

        public void loadDataVendor()
        {
            try
            {
                dataGridVendors.Rows.Clear();
                using(MySqlDataReader reader = stocks.loadVendor())
                {
                    while(reader.Read())
                    {
                        dataGridVendors.Rows.Add(reader["vendor_id"].ToString(),
                            reader["vendor"].ToString(),
                            reader["address"].ToString(),
                            reader["contactPerson"].ToString(),
                            reader["telephoneNo"].ToString(),
                            reader["email"].ToString(),
                            reader["fax"].ToString());
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message); 
            }
        }

        public void searchVendor()
        {
            try
            {
                dataGridVendors.Rows.Clear();
                using (MySqlDataReader reader = stocks.searchVendor(txtSearch.text))
                {
                    while (reader.Read())
                    {
                        dataGridVendors.Rows.Add(reader["vendor_id"].ToString(),
                            reader["vendor"].ToString(),
                            reader["address"].ToString(),
                            reader["contactPerson"].ToString(),
                            reader["telephoneNo"].ToString(),
                            reader["email"].ToString(),
                            reader["fax"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmVendor_Load(object sender, EventArgs e)
        {
            dataGridVendors.BorderStyle = BorderStyle.None;
            dataGridVendors.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridVendors.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridVendors.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridVendors.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;

            dataGridVendors.EnableHeadersVisualStyles = false;
            dataGridVendors.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridVendors.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(67, 44, 122);
            dataGridVendors.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridVendors.ColumnHeadersDefaultCellStyle.Padding = new Padding(0, 7, 0, 7);

            loadDataVendor();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            addVendor add = new addVendor(this);
            add.Show();
            add.btnUpdate.Enabled = false;
        }

        private void txtSearch_OnTextChange(object sender, EventArgs e)
        {
            searchVendor();
        }

        private void dataGridVendors_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String colName = dataGridVendors.Columns[e.ColumnIndex].Name;
            addVendor add = new addVendor(this);
            if(colName == "Delete")
            {
                stocks.delVendor(dataGridVendors.Rows[e.RowIndex].Cells[0].Value.ToString());
                loadDataVendor();
            }

            if(colName == "update")
            {
                add.lblID.Text = dataGridVendors.Rows[e.RowIndex].Cells[0].Value.ToString();
                add.txtVendors.Text = dataGridVendors.Rows[e.RowIndex].Cells[1].Value.ToString();
                add.txtAddress.Text = dataGridVendors.Rows[e.RowIndex].Cells[2].Value.ToString();
                add.txtContact.Text = dataGridVendors.Rows[e.RowIndex].Cells[3].Value.ToString();
                add.txtTelephone.Text = dataGridVendors.Rows[e.RowIndex].Cells[4].Value.ToString();
                add.txtEmail.Text = dataGridVendors.Rows[e.RowIndex].Cells[5].Value.ToString();
                add.txtFax.Text = dataGridVendors.Rows[e.RowIndex].Cells[6].Value.ToString();

                add.submit.Enabled = false;
                add.btnUpdate.Enabled = true;
                add.Show();
            }
        }
    }
}
