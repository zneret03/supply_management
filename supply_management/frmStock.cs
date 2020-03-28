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
    public partial class frmStock : Form
    {

        Controller.stocksController stocks = new Controller.stocksController();
        public frmStock()
        {
            InitializeComponent();
        }

        public void GridProducts()
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
        }

        public void GridStocks()
        {
            dataGridStock.BorderStyle = BorderStyle.None;
            dataGridStock.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridStock.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridStock.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridStock.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;

            dataGridStock.EnableHeadersVisualStyles = false;
            dataGridStock.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridStock.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(54, 54, 54);
            dataGridStock.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridStock.ColumnHeadersDefaultCellStyle.Padding = new Padding(0, 6, 0, 6);
        }

        public void tablestockHistory_Design()
        {
            TableStockHistory.BorderStyle = BorderStyle.None;
            TableStockHistory.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            TableStockHistory.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            TableStockHistory.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            TableStockHistory.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;

            TableStockHistory.EnableHeadersVisualStyles = false;
            TableStockHistory.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            TableStockHistory.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(54, 54, 54);
            TableStockHistory.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            TableStockHistory.ColumnHeadersDefaultCellStyle.Padding = new Padding(0, 6, 0, 6);
        }

        private void frmStock_Load(object sender, EventArgs e)
        {
            tablestockHistory_Design();
            GridProducts();
            GridStocks();
            getDataProducts();
            loadStocks();
        }

        public void getDataProducts()
        {
            dataGridProducts.DataSource = stocks.loadProducts();

            dataGridProducts.Columns[0].Width = 100;
            dataGridProducts.Columns[1].Width = 150;
            dataGridProducts.Columns[2].Width = 150;
            dataGridProducts.Columns[3].Width = 100;

            dataGridProducts.Columns[0].HeaderText = "PCODE";
            dataGridProducts.Columns[1].HeaderText = "PRODUCT NAME";
            dataGridProducts.Columns[2].HeaderText = "DESCRIPTION";
            dataGridProducts.Columns[3].HeaderText = "QTY";

            dataGridProducts.Columns[0].ReadOnly = true;
            dataGridProducts.Columns[1].ReadOnly = true;
            dataGridProducts.Columns[2].ReadOnly = true;
            dataGridProducts.Columns[3].ReadOnly = true;
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
            dataGridStock.Columns[7].Width = 150;

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
            
            TableStockHistory.DataSource = stocks.loadStockHistory(this);

            TableStockHistory.Columns[0].Width = 50;
            TableStockHistory.Columns[1].Width = 120;
            TableStockHistory.Columns[2].Width = 100;
            TableStockHistory.Columns[3].Width = 150;
            TableStockHistory.Columns[4].Width = 150;
            TableStockHistory.Columns[5].Width = 65;
            TableStockHistory.Columns[6].Width = 130;
            TableStockHistory.Columns[7].Width = 150;
            TableStockHistory.Columns[8].Width = 150;

            for (int i = 0; i < TableStockHistory.Rows.Count; i++)
            {
                TableStockHistory.Columns[i].ReadOnly = true;
            }

            TableStockHistory.Columns[0].HeaderText = "#";
            TableStockHistory.Columns[0].Name = "Id";
            TableStockHistory.Columns[1].HeaderText = "REF #";
            TableStockHistory.Columns[2].HeaderText = "PCODE";
            TableStockHistory.Columns[3].HeaderText = "PRODUCT NAME";
            TableStockHistory.Columns[4].HeaderText = "DESCRIPTION";
            TableStockHistory.Columns[5].HeaderText = "QTY";
            TableStockHistory.Columns[6].HeaderText = "STOCK DATE";
            TableStockHistory.Columns[7].HeaderText = "STOCK IN BY";
            TableStockHistory.Columns[8].HeaderText = "STATUS";
        }


        private void dataGridProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String pcode = " ";
            TextBox[] text = new TextBox[]
            {
                referenceNo,
                StockInBy
            };


            if(e.RowIndex >= 0)
            {
                DataGridViewRow dt = dataGridProducts.Rows[e.RowIndex];
                pcode = dt.Cells[0].Value.ToString();
            }

           

            stocks.insertProduct(pcode, this, text, stockDate.Value.Date);
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

        private void txtSearch_OnTextChange(object sender, EventArgs e)
        {
           dataGridProducts.DataSource = stocks.searchData(txtSearch.text);

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

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }   
    }
}
