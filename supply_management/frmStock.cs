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
    public partial class frmStock : Form
    {

        Controller.stocksController stocks = new Controller.stocksController();
        Controller.ErrorHandler error = new Controller.ErrorHandler();
        public String vendors_id = "";
        public frmStock()
        {
            InitializeComponent();
        }

        frmProductImport frmproduct;
        public void data(DataGridView data)
        {
            data.BorderStyle = BorderStyle.None;
            data.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            data.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            data.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            data.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;

            data.EnableHeadersVisualStyles = false;
            data.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            data.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(54, 54, 54);
            data.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            data.ColumnHeadersDefaultCellStyle.Padding = new Padding(0, 7, 0, 7);
        }

        public void vendorsData()
        {
            try
            {
                cmbVendors.Items.Clear();
                using(MySqlDataReader reader = stocks.returnData())
                {
                    while(reader.Read())
                    {
                        cmbVendors.Items.Add(reader.GetString("vendor"));
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void extractVendorsData()
        {
            try
            {
                using(MySqlDataReader reader = stocks.extractdata(cmbVendors.Text))
                {
                    while(reader.Read())
                    {
                        txtContactPerson.Text = reader["contactPerson"].ToString();
                        txtAddress.Text = reader["address"].ToString();
                        vendors_id = reader["vendor_id"].ToString();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void frmStock_Load(object sender, EventArgs e)
        {
            data(TableStockHistory);
            data(dataGridStock);
            loadStocks();
            loadStockHistory();
            generateReferenceNo();
            vendorsData();
           
        }

        public void getDataProducts()
        {
                if(frmproduct == null)
                {
                    return;
                }

                frmproduct.dataGridProducts.DataSource = stocks.loadProducts();

                frmproduct.dataGridProducts.Columns[0].Width = 100;
                frmproduct.dataGridProducts.Columns[1].Width = 150;
                frmproduct.dataGridProducts.Columns[2].Width = 450;
                frmproduct.dataGridProducts.Columns[3].Width = 100;

                frmproduct.dataGridProducts.Columns[0].HeaderText = "PCODE";
                frmproduct.dataGridProducts.Columns[1].HeaderText = "PRODUCT NAME";
                frmproduct.dataGridProducts.Columns[2].HeaderText = "DESCRIPTION";
                frmproduct.dataGridProducts.Columns[3].HeaderText = "QTY";

                frmproduct.dataGridProducts.Columns[0].ReadOnly = true;
                frmproduct.dataGridProducts.Columns[1].ReadOnly = true;
                frmproduct.dataGridProducts.Columns[2].ReadOnly = true;
                frmproduct.dataGridProducts.Columns[3].ReadOnly = true;
        }

        public void generateReferenceNo()
        {
            String refNo = error.GenerateNumber(12);
            referenceNo.Text = refNo;
        }
        public void loadStocks()
        {
            dataGridStock.DataSource = stocks.loadStocks();

            dataGridStock.Columns[0].Width = 100;
            dataGridStock.Columns[1].Width = 120;
            dataGridStock.Columns[2].Width = 100;
            dataGridStock.Columns[3].Width = 150;
            dataGridStock.Columns[4].Width = 150;
            dataGridStock.Columns[5].Width = 65;
            dataGridStock.Columns[6].Width = 130;
            dataGridStock.Columns[7].Width = 150;
            dataGridStock.Columns[8].Width = 150;
            dataGridStock.Columns[9].Width = 150;

            dataGridStock.Columns[0].HeaderText = "#";
            dataGridStock.Columns[0].Name = "Id";
            dataGridStock.Columns[1].HeaderText = "REF #";
            dataGridStock.Columns[2].HeaderText = "PCODE";
            dataGridStock.Columns[3].HeaderText = "PRODUCT NAME";
            dataGridStock.Columns[4].HeaderText = "DESCRIPTION";
            dataGridStock.Columns[5].HeaderText = "QTY";
            dataGridStock.Columns[6].HeaderText = "STOCK DATE";
            dataGridStock.Columns[7].HeaderText = "STOCK IN BY";
            dataGridStock.Columns[8].HeaderText = "STATUS";
            dataGridStock.Columns[9].HeaderText = "VENDOR";

            dataGridStock.Columns[0].ReadOnly = true;
            dataGridStock.Columns[1].Name = "REF";
            dataGridStock.Columns[2].ReadOnly = true;
            dataGridStock.Columns[3].ReadOnly = true;
            dataGridStock.Columns[4].ReadOnly = true;
            dataGridStock.Columns[5].Name = "QTY";
            dataGridStock.Columns[6].ReadOnly = true;
            dataGridStock.Columns[7].Name = "STOCKINBY";
        }

        public void loadStockHistory()
        {
            try
            {
                TableStockHistory.Rows.Clear();
                using(MySqlDataReader reader = stocks.loadStockHistory(dateTimePicker1.Value.ToShortDateString(),dateTimePicker2.Value.ToShortDateString(), status.Text))
                {
                    while (reader.Read())
                    {
                        TableStockHistory.Rows.Add(reader["stock_id"].ToString(),
                            reader["referenceNo"].ToString(),
                            reader["products_id"].ToString(),
                            reader["product_name"].ToString(),
                            reader["description"].ToString(),
                            reader["quantity"].ToString(),
                            reader["stockDATE"].ToString(),
                            reader["stockInBy"].ToString(),
                            reader["status"].ToString(),
                            reader["vendor"].ToString());
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void dataGridProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridStock_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow dt = dataGridStock.Rows[e.RowIndex];
                stocks.updateDataStocks(dt.Cells["QTY"].Value.ToString(),dt.Cells["REF"].Value.ToString()
                    , dt.Cells["STOCKINBY"].Value.ToString(), dt.Cells[0].Value.ToString(), this);

                stocks.notOrder(dataGridStock.Rows[e.RowIndex].Cells[0].Value.ToString(), this);
            }
        }

        private void submit_Click(object sender, EventArgs e)
        {
            referenceNo.Clear();
            StockInBy.Clear();
        }

        private void dataGridStock_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String colName = dataGridStock.Columns[e.ColumnIndex].Name;

            if(colName == "Id")
            {
                if (e.RowIndex >= 0)
                {
                    stocks.isDelete(dataGridStock.Rows[e.RowIndex].Cells[0].Value.ToString(), this);
                }
            }
           
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            loadStockHistory();
        }


        private void TableStockHistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
             frmproduct = new frmProductImport(this);
            frmproduct.Show();
            
        }

        private void label9_Click(object sender, EventArgs e)
        {
            generateReferenceNo();
        }

        private void cmbVendors_SelectedValueChanged(object sender, EventArgs e)
        {
            extractVendorsData();
        }

    }
}
