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
    public partial class frmQuantity : Form
    {
        int moveStart;
        int moveStartX;
        int moveStartY;
        Controller.posController pos = new Controller.posController();
        Controller.ErrorHandler error = new Controller.ErrorHandler();
        frmPOS pointOfSale;
        public frmQuantity(frmPOS pos)
        {
            InitializeComponent();
            pointOfSale = pos;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(moveStart == 1)
            {
                this.SetDesktopLocation(MousePosition.X - moveStartX, MousePosition.Y - moveStartY);
            }
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

        private void frmQuantity_Load(object sender, EventArgs e)
        {
            quantity.Text = "0";
        }

        private void quantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool result = error.checkNum(quantity.Text);

                if ((e.KeyChar == 13) && (quantity.Text != string.Empty))
                {
                    if (result == true)
                    {
                        double total = Convert.ToDouble(quantity.Text) * pointOfSale.price;

                        pos.insertTransact(pointOfSale.pcode.ToString(),
                            pointOfSale.Transactionlbl.Text,
                            quantity.Text, total,
                            pointOfSale.date.Text, pointOfSale.label1.Text);

                        this.Hide();
                        pointOfSale.tableShow();
                        //pointOfSale.transactionNo();
                        pointOfSale.textBox6.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Quantity should be numeric!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
        }

        private void quantity_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
