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

namespace supply_management
{
    public partial class frmSettlePayment : Form
    {
        int moveStart;
        int movetStartX;
        int moveStartY;

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

        frmPOS pointOfSale;
        public frmSettlePayment(frmPOS pos)
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn( 0, 0, Width, Height, 20, 20));
            pointOfSale = pos;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(moveStart == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movetStartX, MousePosition.Y - moveStartY);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            moveStart = 0;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            moveStart = 1;
            movetStartX = e.X;
            moveStartY = e.Y;

        }

        private void cash_TextChanged(object sender, EventArgs e)
        {
            try
            {
                    double totalSale = Convert.ToDouble(sale.Text);
                    double Cash = Convert.ToDouble(cash.Text);
                    double Cashchange = Cash - totalSale;
                    change.Text = Cashchange.ToString("#,##0.00");
               
            }
            catch(Exception ex)
            {
                change.Text = "0.00";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cash.Text += btn1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cash.Text += button2.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cash.Text += button3.Text;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            cash.Text += button8.Text;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            cash.Text += button7.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            cash.Text += button6.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            cash.Text += btn0.Text;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            cash.Text += button12.Text;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            cash.Text += button11.Text;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            cash.Text += button10.Text;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            cash.Text += button9.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cash.Clear();
            cash.Focus();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                if ((Convert.ToDouble(change.Text) < 0) || (string.IsNullOrEmpty(cash.Text)))
                {
                    MessageBox.Show("insuffecient amount please enter the right amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    for(int i = 0; i < pointOfSale.dataGridTransaction.Rows.Count; i++)
                    {
                         pos.updQty(pointOfSale.dataGridTransaction.Rows[i].Cells[4].Value.ToString(),
                             pointOfSale.dataGridTransaction.Rows[i].Cells[1].Value.ToString());

                        pos.outOfOrder(pointOfSale.dataGridTransaction.Rows[i].Cells[1].Value.ToString());
                    }
                    this.Hide();
                    frmReceipt receipt = new frmReceipt(pointOfSale);
                    receipt.loadData(cash.Text, change.Text);
                    receipt.Show();
                    pos.updTransactionStat(pointOfSale.Transactionlbl.Text);
                    pointOfSale.transactionNo();
                    pointOfSale.clearData();
                    pointOfSale.settlePayment.Enabled = false;
                    pointOfSale.addDiscount.Enabled = false;
                    MessageBox.Show("Payment Successfully Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
    }
}
