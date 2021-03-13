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
using Tulpep.NotificationWindow;
using MySql.Data.MySqlClient;
using System.Windows.Forms.DataVisualization.Charting;

namespace supply_management
{
    public partial class Main : Form
    {
        private int moveStart;
        private int moveStartX;
        private int moveStartY;

        Form1 form = new Form1();
        frmEmployeeReg reg;
        frmCategory category = new frmCategory();
        frmBrand brand = new frmBrand();
        frmProduct product = new frmProduct();
        frmStock stock = new frmStock();
        frmTopItems top = new frmTopItems();
        frmVendor vendor = new frmVendor();

        Controller.posController pos = new Controller.posController();
        Controller.userAccount uses = new Controller.userAccount();
        Controller.productController prod = new Controller.productController();
        Controller.stocksController stocks = new Controller.stocksController();

        MySqlDataReader reader;
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

        Form1 form1;
        public Main(Form1 message)
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            form1 = message;
            user.Text = form1.username.Text.ToString();
            loadCriticalStocks();
            loadChart();


        }
        
        public void loadChart()
        {
            try
            {
                Model.ConnectionSql connect = new Model.ConnectionSql();
                MySqlConnection conn = new MySqlConnection(connect.connection());
                conn.Open();
                MySqlDataAdapter sda = new MySqlDataAdapter("SELECT YEAR(date_created) as year, SUM(TOTAL) as total FROM transaction GROUP BY YEAR(date_created)", conn);
                DataSet data = new DataSet();
                sda.Fill(data, "Sales");
                chart1.DataSource = data.Tables["Sales"];
                Series Series1 = chart1.Series["Series1"];
                Series1.ChartType = SeriesChartType.Doughnut;
                Series1.LabelForeColor = Color.White;
                Series1.Name = "Sales";

                var chart = chart1;
                chart1.Series[Series1.Name].XValueMember = "year";
                chart1.Series[Series1.Name].YValueMembers = "total";
                chart.Series[0].IsValueShownAsLabel = true;
                chart.Series[0].LabelFormat = "Php{#,##0.00}";
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Mousestart()
        {
            if (moveStart == 1)
            {
                this.SetDesktopLocation(MousePosition.X - moveStartX, MousePosition.Y - moveStartY);
            }
        }
        public void loadUserData()
        {
            try
            {
                using (MySqlDataReader reader = uses.getuserData(user.Text))
                {
                    while (reader.Read())
                    {
                        label14.Text = reader["user_id"].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void loadCriticalStocks()
        {
            try
            {
                String critcalVal = "";
                String count = pos.countCritical();
                int i = 0;


                using (reader = pos.loadCriticalStocks())
                {
                    
                    while (reader.Read())
                    {
                        i++;
                        critcalVal += i + "." + reader["description"].ToString() + Environment.NewLine;
                    }
                }

                PopupNotifier pop = new PopupNotifier();
                pop.Image = Properties.Resources.ekis;
                pop.TitleText = count + " CRITACAL ITEM(S)";
                pop.ContentText = critcalVal;
                pop.Popup();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadTextBox()
        {
            CountCritical.Text = pos.countCritical();
            countDailySales.Text = pos.dailySales().ToString(); 
            countInventory.Text = prod.count().ToString();
            countStocks.Text = stocks.countStocks().ToString();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            label14.Hide();
            loadUserData();
            MainPanel.AutoScroll = true;
            loadTextBox();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
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

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            Mousestart();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            reg = new frmEmployeeReg(this);
            reg.Show();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            
            MainPanel.Controls.Remove(reg);
            MainPanel.Controls.Remove(category);
            MainPanel.Controls.Remove(brand);
            MainPanel.Controls.Remove(product);
            MainPanel.Controls.Remove(stock);
            MainPanel.Controls.Remove(top);
            MainPanel.Controls.Remove(vendor);
            loadTextBox();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            product.TopLevel = false;
            MainPanel.Controls.Add(product);
            product.BringToFront();
            product.Show();
            product.getData();
        }

        private void panel24_Click(object sender, EventArgs e)
        {
            
        }

        private void ManageCategory_Click(object sender, EventArgs e)
        {
            category.TopLevel = false;
            MainPanel.Controls.Add(category);
            category.BringToFront();
            category.Show();
        }

        private void ManageBrand_Click(object sender, EventArgs e)
        {
            brand.TopLevel = false;
            MainPanel.Controls.Add(brand);
            brand.BringToFront();
            
            brand.Show();
        }
        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            stock.TopLevel = false;
            MainPanel.Controls.Add(stock);
            stock.BringToFront();
            stock.loadStocks();
            stock.vendorsData();
            stock.Show();
        }

        private void panel11_MouseMove(object sender, MouseEventArgs e)
        {
            Mousestart();
        }

        private void panel11_MouseUp(object sender, MouseEventArgs e)
        {
            moveStart = 0;
        }

        private void panel11_MouseDown(object sender, MouseEventArgs e)
        {
            moveStart = 1;
            moveStartX = e.X;
            moveStartY = e.Y;
        }


        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            frmPOS sale = new frmPOS(user.Text);
            sale.Logout.Hide();
            sale.Show();
            this.Hide();
        }

        private void bunifuFlatButton3_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Logout this application?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                Form1 form = new Form1();
                form.Show();
                this.Hide();
            }
            else
            {
                return;
            }
           
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            frmSoldItems sales = new frmSoldItems();
            sales.username.Enabled = true;
            sales.dateTimePicker1.Enabled = true;
            sales.dateTimePicker2.Enabled = true;
            sales.submit.Normalcolor = Color.FromArgb(54, 54, 54);
            sales.panel1.BackColor = Color.FromArgb(54, 54, 54);
            sales.Show();
        }

        //CREATE VIEW viewcance_sales AS SELECT c.transaction_id, c.products_id, p.description, p.price as Pprice, p.quantity, p.price, (p.price * p.quantity) as total, c.date_cancel FROM cancel_sales AS c INNER JOIN transaction AS t ON t.transaction_id = c.transaction_id INNER JOIN product AS p ON p.products_id = c.products_id ;

        private void bunifuFlatButton7_Click_1(object sender, EventArgs e)
        {
            top.TopLevel = false;
            top.loadCriticalStocks();
            MainPanel.Controls.Add(top);
            top.BringToFront();
            top.loadCancelSales();
            top.Show();
        }

        private void bunifuFlatButton2_Click_1(object sender, EventArgs e)
        {
            vendor.TopLevel = false;
            MainPanel.Controls.Add(vendor);
            vendor.BringToFront();
            vendor.Show();
        }

        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {
            uses.isDelete(label14.Text, form1, this);
        }

        private void bunifuFlatButton9_Click(object sender, EventArgs e)
        {
            frmStockAdjustment adjustment = new frmStockAdjustment(this);
            adjustment.Show();
        }
    }
}
