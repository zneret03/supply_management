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
using System.Windows.Forms.DataVisualization.Charting;

namespace supply_management
{
    public partial class frmTopItems : Form
    {
        Controller.stocksController stocks = new Controller.stocksController();
        Controller.posController pos = new Controller.posController();
        public frmTopItems()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void loadCriticalStocks()
        {
            try
            {
                dataGridCritical.Rows.Clear();
                int i = 0;
                using(MySqlDataReader reader = pos.loadCriticalStocks())
                {
                    while(reader.Read())
                    {
                        i++;
                        dataGridCritical.Rows.Add(i,reader[0].ToString(),
                            reader[1].ToString(),
                            reader[2].ToString(),
                            reader[3].ToString(),
                            reader[4].ToString(),
                            reader[5].ToString(),
                            reader[6].ToString(),
                            int.Parse(reader[7].ToString()),
                            reader[8].ToString());
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
             
        }
        public void loadTopSeller()
        {
            try
            {
                dataTopSelling.Rows.Clear();
                int i = 0;
                using (MySqlDataReader reader = pos.loadTopSales(dateTimePicker1.Value.ToString("yyyy-MM-dd"), dateTimePicker2.Value.ToString("yyyy-MM-dd"), topSalesSorting.Text))
               {
                    while(reader.Read())
                    {
                        i++;
                        dataTopSelling.Rows.Add(i,reader["transaction_id"].ToString(),
                            reader["products_id"].ToString(),
                            reader["description"].ToString(),
                            reader["quantity"].ToString(),
                            reader["total"].ToString());
                    }
               }
               
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void loadSoldItems()
        {
            try
            {
                dataGridView1.Rows.Clear();
                int i = 0;
                double totalSold = 0;
                using (MySqlDataReader reader = pos.loadSoldItems(dateTimePicker4.Value.ToString("yyyy-MM-dd"), dateTimePicker3.Value.ToString("yyyy-MM-dd")))
                {
                    
                    while (reader.Read())
                    {
                        i++;
                        totalSold += Convert.ToDouble(reader["total"].ToString());
                        dataGridView1.Rows.Add(i, reader["products_id"].ToString(),
                            reader["description"].ToString(),
                            Double.Parse(reader["price"].ToString()).ToString("#,##0.00"),
                            reader["qty"].ToString(),
                            reader["disc"].ToString(),
                            Double.Parse(reader["total"].ToString()).ToString("#,##0.00"));
                    }
                }

                total.Text = totalSold.ToString("#,##0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void loadProductInventory()
        {
            try
            {
                dataProductInventory.Rows.Clear();
                int i = 0;
                int qty = 0;
                using(MySqlDataReader reader = pos.loadProductInventory())
                {
                    while(reader.Read())
                    {
                        i++;
                        qty += int.Parse(reader[8].ToString());
                        dataProductInventory.Rows.Add(i, reader[0].ToString(),
                            reader[1].ToString(),
                            reader[2].ToString(),
                            reader[3].ToString(),
                            reader[4].ToString(),
                            reader[5].ToString(),
                            reader[6].ToString(),
                            int.Parse(reader[7].ToString()),
                            reader[8].ToString());
                    }

                    txtTotalQty.Text = qty.ToString("#,##0.00");
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void loadCancelSales()
        {
            try
            {
                int i = 0;
                dataCancelSales.Rows.Clear();
                using (MySqlDataReader reader = pos.loadCancel(dateCancel1.Value.ToShortDateString(),dateCancel2.Value.ToShortDateString()))
                {
                    while(reader.Read())
                    {
                        i++;
                        dataCancelSales.Rows.Add(i,
                            reader["transaction_id"].ToString(),
                            reader["products_id"].ToString(),
                            reader["description"].ToString(),
                            reader["price"].ToString(),
                            reader["quantity"].ToString(),
                            reader["total"].ToString(),
                            reader["date_cancel"].ToString(),
                            reader["voidby"].ToString(),
                            reader["cancelBy"].ToString(),
                            reader["reason"].ToString(),
                            reader["action"].ToString());
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void loadStockHistory()
        {
            try
            {
                TableStockHistory.Rows.Clear();
                using (MySqlDataReader reader = stocks.loadStockHistory(dateTimePicker6.Value.ToShortDateString(), dateTimePicker5.Value.ToShortDateString(), status.Text))
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
                            reader["status"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void frmTopItems_Load(object sender, EventArgs e)
        {
            loadSoldItems();
            loadTopSeller();
            loadCriticalStocks();
            loadProductInventory();
            loadCancelSales();
            loadStockHistory();

            data(TableStockHistory);
            data(dataCancelSales);
            data(dataProductInventory);
            data(dataGridCritical);
            data(dataGridView1);
            data(dataTopSelling);
        }

        public void data(DataGridView dataGrid)
        {
            dataGrid.BorderStyle = BorderStyle.None;
            dataGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGrid.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGrid.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;

            dataGrid.EnableHeadersVisualStyles = false;
            dataGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(54, 54, 54);
            dataGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGrid.ColumnHeadersDefaultCellStyle.Padding = new Padding(0, 7, 0, 7);
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            loadTopSeller();
            loadTop();
        }

        public void loadTop()
        {
            try
            {
                MySqlDataAdapter sda = pos.loadChartTopSell(dateTimePicker1.Value.ToString("yyyy-MM-dd"), dateTimePicker2.Value.ToString("yyyy-MM-dd"), topSalesSorting.Text);
                DataSet data = new DataSet();
                sda.Fill(data, "TOPSALES");
                chart1.DataSource = data.Tables["TOPSALES"];
                Series series = chart1.Series[0];
                series.LabelForeColor = Color.White;
                series.ChartType = SeriesChartType.Doughnut;

                series.Name = "TOP SELLING";
                var chart = chart1;
                chart1.Series[0].XValueMember = "description";
                if (topSalesSorting.Text == "SORT BY QTY") { chart1.Series[0].YValueMembers = "quantity"; } else { chart1.Series[0].YValueMembers = "total"; }
                
                chart.Series[0].IsValueShownAsLabel = true;
                if (topSalesSorting.Text == "SORT BY QTY") { chart.Series[0].LabelFormat = "{#,##0}"; } else { chart.Series[0].LabelFormat = "{#,##0.00}"; }
                

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            loadSoldItems();
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            loadCancelSales();
        }

        private void loadData_Click(object sender, EventArgs e)
        {
            loadStockHistory();
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            frmPrintSoldItems print = new frmPrintSoldItems(this);
            print.Show();
            print.loadSoldItems();
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            frmprintCriticalStocks print = new frmprintCriticalStocks(this);
            print.Show();
            print.loadCriticalStocks();
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            frmPrintInventory inventory = new frmPrintInventory(this);
            inventory.loadInvetory();
            inventory.Show();
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            frmPrintCancelSales cancel = new frmPrintCancelSales(this);
            cancel.Show();
            cancel.loadCancelSales();
        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            frmPrintStockInHistory stockIn = new frmPrintStockInHistory(this);
            stockIn.Show();
            stockIn.loadStochInHistory();
        }

        private void bunifuImageButton7_Click(object sender, EventArgs e)
        {
            frmPrintTopSelling frm = new frmPrintTopSelling(this);
            frm.Show();
            frm.loadTopSelling();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            frmChartSoldItems frm = new frmChartSoldItems(this);
            frm.Show();
            frm.loadChartSoldItems();
        }
    }
}
