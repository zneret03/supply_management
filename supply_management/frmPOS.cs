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
using Tulpep.NotificationWindow;

namespace supply_management
{
    public partial class frmPOS : Form
    {

        int moveStart;
        int moveStartX;
        int moveStartY;

        public String pcode;
        public double price;
        public double gainPrice;

        public int qty;
        public int cart_qty;

        public String _pcode;
        public double _price;
        public int _qty;
        String idDiscount;
        String priceDiscount;
        String totalPrice;
        String totalGainRow;

        Controller.ErrorHandler error = new Controller.ErrorHandler();
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
        String user;
        //public String todate = DateTime.Now.ToShortDateString();
        public frmPOS(String username)
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            user = username;
            loadCriticalStocks();
        }

        public void loadCriticalStocks()
        {
            try
            {
                String critcalVal = "";
                String count = pos.countCritical();
                int i = 0;
                using (MySqlDataReader reader = pos.loadCriticalStocks())
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
        private void Start()
        {
            if (moveStart == 1)
            {
                this.SetDesktopLocation(MousePosition.X - moveStartX, MousePosition.Y - moveStartY);
            }
        }

        private void StartUp()
        {
            moveStart = 0;
        }

        private void label1_Click(object sender, EventArgs e)
        {
       /*     this.Hide();*/
        }

        private void panel24_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void POS_Load(object sender, EventArgs e)
        {
            label1.Text = user;
            transactionNo();
            Time.Text = DateTime.Now.ToLongTimeString();
            currentDate.Text = DateTime.Now.ToLongDateString();
            timer1.Start();

            date.Text = DateTime.Now.ToLongDateString();

            dataGridTransaction.BorderStyle = BorderStyle.None;
            dataGridTransaction.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridTransaction.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridTransaction.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridTransaction.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;

            dataGridTransaction.EnableHeadersVisualStyles = false;
            dataGridTransaction.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridTransaction.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(54, 54, 54);
            dataGridTransaction.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridTransaction.ColumnHeadersDefaultCellStyle.Padding = new Padding(0, 6, 0, 6);

            Time.Text = DateTime.Now.ToLongTimeString();
            textBox6.SelectionStart = 0;
            textBox6.SelectionLength = textBox6.Text.Length;
        }
        

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            Start();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            moveStart = 1;
            moveStartX = e.X;
            moveStartY = e.Y;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            StartUp();
        }

        private void panel11_MouseMove(object sender, MouseEventArgs e)
        {
            Start();
        }

        private void panel11_MouseUp(object sender, MouseEventArgs e)
        {
            StartUp();
        }

        private void panel11_MouseDown(object sender, MouseEventArgs e)
        {
            moveStart = 1;
            moveStartX = e.X;
            moveStartY = e.Y;
        }

        //if product occur in table enable settle payment and discount else disable
        public void tableShow()
        {
            try
            {
                bool hasEnable = false;
                dataGridTransaction.Rows.Clear();
                MySqlDataReader reader = pos.displayRecord(Transactionlbl.Text);
                double total = 0;
                double isdiscount = 0;
                double totalGain = 0;
                while(reader.Read())
                {
                    total += Convert.ToDouble(reader["total"].ToString());
                    isdiscount += Convert.ToDouble(reader["discount"].ToString());
                    totalGain += Convert.ToDouble(reader["totalGain"].ToString());
                    cart_qty = int.Parse(reader["quantity"].ToString());

                    dataGridTransaction.Rows.Add(
                        reader["transaction_id"].ToString(),
                        reader["products_id"].ToString(),
                        reader["product_name"].ToString(),
                        reader["price"].ToString(),
                        reader["quantity"].ToString(),
                        reader["discount"].ToString(),
                        reader["gain"].ToString(),
                        reader["total"].ToString(),
                        reader["totalGain"].ToString());
                    hasEnable = true;
                }

                total_sales.Text = total.ToString("#,##0.00");
                txtGain.Text = totalGain.ToString("#,##0.00");
                txtdiscount.Text = isdiscount.ToString("#,##0.00");
                getTotal();

                if (hasEnable == true) 
                { 
                    settlePayment.Enabled = true; 
                    addDiscount.Enabled = true;
                }
                else 
                {
                    settlePayment.Enabled = false;
                    addDiscount.Enabled = false;
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //not final
        private void recoveryData()
        {
            try
            {
                bool hasEnable = false;
                double total = 0;
                double isdiscount = 0;
                double totalGain = 0;

                dataGridTransaction.Rows.Clear();
                MySqlDataReader reader = pos.displayRecoveryData();
                while(reader.Read())
                {
                        Transactionlbl.Text = reader["transactionNo"].ToString();
                        total += Convert.ToDouble(reader["total"].ToString());
                        isdiscount += Convert.ToDouble(reader["discount"].ToString());
                        totalGain += Convert.ToDouble(reader["totalGain"].ToString());
                        cart_qty = int.Parse(reader["quantity"].ToString());

                        dataGridTransaction.Rows.Add(
                            reader["transaction_id"].ToString(),
                            reader["products_id"].ToString(),
                            reader["product_name"].ToString(),
                            reader["price"].ToString(),
                            reader["quantity"].ToString(),
                            reader["discount"].ToString(),
                            reader["gain"].ToString(),
                            reader["total"].ToString(),
                            reader["totalGain"].ToString());
                        hasEnable = true;
                }

                total_sales.Text = total.ToString("#,##0.00");
                txtdiscount.Text = isdiscount.ToString("#,##0.00");
                txtGain.Text = totalGain.ToString("#,##0.00");
                getTotal();

                if (hasEnable == true)
                {
                    settlePayment.Enabled = true;
                    addDiscount.Enabled = true;
                }
                else
                {
                    settlePayment.Enabled = false;
                    addDiscount.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void getTotal()
        {
            double discount = Convert.ToDouble(txtdiscount.Text);
            double sales = Convert.ToDouble(total_sales.Text);
            double vat = sales * pos.vatable();
            double vatable = sales - vat;
            vatlbl.Text = vat.ToString("#,##0.00");
            lblvatable.Text = vatable.ToString("#,##0.00");
            lblDisplayTotal.Text = sales.ToString("#,##0.00");
            /*txtGain.Text = sales.ToString("#,##0.00");*/
        }       
        public void transactionNo()
        {
            
            String transactionNo = error.GenerateNumber(6);
            String sdate = DateTime.Now.ToString("yyyyMMdd");
            Transactionlbl.Text = transactionNo + sdate;
            
        }
        
        public void clearData()
        {
            lblDisplayTotal.Text = "0.00";
            total_sales.Text = "0.00";
            txtdiscount.Text = "0.00";
            vatlbl.Text = "0.00";
            lblvatable.Text = "0.00";
            transactionNo();
            dataGridTransaction.Rows.Clear();
        }
        private void newTransaction_Click(object sender, EventArgs e)
        {
            clearData();
        }
        
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
                DataTable dt = pos.barcode(textBox6.Text);
                if (dt.Rows.Count > 0)
                {
                    if (int.Parse(dt.Rows[0][6].ToString()) == 0)
                    {
                        MessageBox.Show(dt.Rows[0][2].ToString() + " item is out of order");
                    }
                    else
                    {
                        /*
                        product(dt.Rows[0][0].ToString(), Convert.ToDouble(dt.Rows[0][7].ToString()));
                        frmQuantity quantity = new frmQuantity(this);
                        quantity.Show();
                         * */
                        _pcode = dt.Rows[0][0].ToString();
                        _price = Double.Parse(dt.Rows[0][7].ToString());
                        _qty = int.Parse(dt.Rows[0][6].ToString());
                        addtoCart();
                    }

                }

        }

        private void addtoCart()
        {

          try
          {
              //error handler for numeric quantity
              bool result = error.checkNum(txtQty.Text);
              //searching through data
              bool found = pos.orderExist(Transactionlbl.Text, _pcode.ToString());
              if (_qty < int.Parse(txtQty.Text))
              {
                  MessageBox.Show("Unable to proceed", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                  return;
              }

              double total = Convert.ToDouble(txtQty.Text) * _price;
              double totalGain = Convert.ToDouble(txtQty.Text) * gainPrice;
              //if quantity is numeric execute if not throw an error message
              if (result == true)
              {
                  //Search through the data if product exist during transaction
                  if (found == true)
                  {
                      //if qty is lessthan from input qty show error
                      if (_qty < (int.Parse(txtQty.Text)) + cart_qty)
                      {
                          MessageBox.Show("Unable to proceed!", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                          return;
                      }

                      //adding quantity if already exist
                      pos.updateOrder(_pcode.ToString(), txtQty.Text, total, totalGain);
                      tableShow();
                      textBox6.SelectionStart = 0;
                      textBox6.SelectionLength = textBox6.Text.Length;
                      textBox6.Clear();
                  }
                  else
                  {
                      //execute if product is not duplicated during transaction
                      pos.insertTransact(_pcode.ToString(),
                          Transactionlbl.Text,
                          txtQty.Text, total, label1.Text, totalGain);

                      tableShow();
                      //pointOfSale.transactionNo();
                      textBox6.SelectionStart = 0;
                      textBox6.SelectionLength = textBox6.Text.Length;
                      textBox6.Clear();
                  }

              }
          }
          catch(Exception ex)
          {
              MessageBox.Show(ex.Message);
          }
        }

        public void product(String pcode, double price, double gain)
        {
            this.pcode = pcode;
            this.price = price;
            this.gainPrice = gain;
        }

        public void productQty(int qty)
        {
            this.qty = qty;
        }


        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Logout this application?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dataGridTransaction.Rows.Count > 0)
            {
                MessageBox.Show("Unable to logout appliation! please cancel sales", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (result == DialogResult.Yes)
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
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Time.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void searchProduct_Click(object sender, EventArgs e)
        {

            ProductLookUp prod = new ProductLookUp(this);
            prod.Show();
        }

        private void dataGridTransaction_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String colName = dataGridTransaction.Columns[e.ColumnIndex].Name;
            if(colName == "Delete")
            {
                if (e.RowIndex >= 0)
                {
                    pos.deleteData(dataGridTransaction.Rows[e.RowIndex].Cells[0].Value.ToString(), this);
                    dataGridTransaction.Rows.RemoveAt(dataGridTransaction.Rows[e.RowIndex].Cells[0].RowIndex);
                    tableShow();
                }
            }

            if (colName == "addqty")
            {
                pos.addQty(dataGridTransaction.Rows[e.RowIndex].Cells[1].Value.ToString(), 
                    Transactionlbl.Text, 
                    Double.Parse(dataGridTransaction.Rows[e.RowIndex].Cells[5].Value.ToString()),
                    int.Parse(dataGridTransaction.Rows[e.RowIndex].Cells[4].Value.ToString()),
                    int.Parse(txtQty.Text),
                    Double.Parse(dataGridTransaction.Rows[e.RowIndex].Cells[3].Value.ToString()),
                    int.Parse(dataGridTransaction.Rows[e.RowIndex].Cells[6].Value.ToString()));
                tableShow();
            }

            if(colName == "removeqty")
            {
                pos.removeQty(dataGridTransaction.Rows[e.RowIndex].Cells[1].Value.ToString(), 
                    Transactionlbl.Text,
                    Double.Parse(dataGridTransaction.Rows[e.RowIndex].Cells[5].Value.ToString()),
                    int.Parse(txtQty.Text), 
                    Double.Parse(dataGridTransaction.Rows[e.RowIndex].Cells[3].Value.ToString()),
                    int.Parse(dataGridTransaction.Rows[e.RowIndex].Cells[6].Value.ToString()));
                tableShow();
            }

        }

        private void addDiscount_Click(object sender, EventArgs e)
        {
            frmdiscount discount = new frmdiscount(this);
            discount.Show();
            discount.id.Text = idDiscount;
            discount.price.Text = priceDiscount;
            discount.lbltotalPrice.Text = totalPrice;
            discount.lblTotalGain.Text = totalGainRow;
            discount.gain.Text = totalGainRow;
        }

        private void dataGridTransaction_SelectionChanged(object sender, EventArgs e)
        {

            if (dataGridTransaction.CurrentCell != null)
            {
                idDiscount = dataGridTransaction.Rows[dataGridTransaction.CurrentRow.Index].Cells[0].Value.ToString();
                priceDiscount = dataGridTransaction.Rows[dataGridTransaction.CurrentRow.Index].Cells[7].Value.ToString();
                totalPrice = dataGridTransaction.Rows[dataGridTransaction.CurrentRow.Index].Cells[7].Value.ToString();
                totalGainRow = dataGridTransaction.Rows[dataGridTransaction.CurrentRow.Index].Cells[8].Value.ToString();
            }

        }

        private void settlePayment_Click(object sender, EventArgs e)
        {
            frmSettlePayment settle = new frmSettlePayment(this);
            settle.sale.Text = lblDisplayTotal.Text;
            settle.Show();
        }

        private void dailySales_Click(object sender, EventArgs e)
        {
            frmSoldItems sold = new frmSoldItems();
            sold.dateTimePicker1.Enabled = false;
            sold.dateTimePicker2.Enabled = false;
            sold.username.Enabled = false;
            sold.username.Text = label1.Text;
            sold.Show();
        }

        private void bunifuFlatButton1_Click_1(object sender, EventArgs e)
        {
            frmChangePassword change = new frmChangePassword(this);
            change.Show();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            clearData();
        }

        private void btn_recovery_Click(object sender, EventArgs e)
        {
            recoveryData();
        }

        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
